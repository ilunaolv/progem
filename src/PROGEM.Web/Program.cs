using PROGEM.Infrastructure;
using PROGEM.Infrastructure.Auth;
using PROGEM.Infrastructure.Logging;
using PROGEM.Infrastructure.Notifications;
using PROGEM.Infrastructure.Repositories;
using PROGEM.Persistence;
using PROGEM.Persistence.Data;
using PROGEM.Application.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.ResponseCompression;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, services, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration)
        .WriteTo.Console()
        .WriteTo.File("logs/progem-.txt", rollingInterval: RollingInterval.Day)
);

builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(new Microsoft.AspNetCore.Mvc.AutoValidateAntiforgeryTokenAttribute());
});

builder.Services.AddRazorComponents();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Convert.FromBase64String(builder.Configuration["Jwt:Secret"] ?? throw new InvalidOperationException("Jwt:Secret not configured.")))
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Administrador"));
    options.AddPolicy("ProcuradorOnly", policy => policy.RequireRole("Procurador"));
    options.AddPolicy("ServidorOnly", policy => policy.RequireRole("Servidor"));
});

builder.Services.AddScoped<IProcessoRepository, ProcessoRepository>();
builder.Services.AddScoped<IEnvolvidoRepository, EnvolvidoRepository>();
builder.Services.AddScoped<ITramitacaoRepository, TramitacaoRepository>();
builder.Services.AddScoped<IProrrogacaoRepository, ProrrogacaoRepository>();
builder.Services.AddScoped<IHistoricoRepository, HistoricoRepository>();
builder.Services.AddScoped<IDocumentoRepository, DocumentoRepository>();
builder.Services.AddScoped<IServidorRepository, ServidorRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IAuthService, JwtAuthService>();
builder.Services.AddScoped<ILoggerService, SerilogLoggerService>();
builder.Services.AddScoped<INotificationService, EmailNotificationService>();
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateProcessoCommand).Assembly));
builder.Services.AddValidatorsFromAssembly(typeof(CreateProcessoCommandValidator).Assembly);
builder.Services.AddHttpContextAccessor();
builder.Services.AddResponseCompression(options =>
{
    options.EnableForHttps = true;
});
builder.Services.AddAntiforgery(options =>
{
    options.HeaderName = "X-XSRF-TOKEN";
});

builder.Services.AddDbContext<PROGEMDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection") ?? "server=localhost;database=progem;user=root;password=;",
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection") ?? "server=localhost;database=progem;user=root;password=;")
    )
);

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseResponseCompression();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Index}/{id?}");

try
{
    using (var scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<PROGEMDbContext>();
        await context.Database.MigrateAsync();
        await SeedData.SeedAsync(context);
    }
}
catch
{
}

app.Run();