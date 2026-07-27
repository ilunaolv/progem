using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PROGEM.Domain.Entities;
using PROGEM.Persistence.Configurations;

namespace PROGEM.Persistence.Data;

public class PROGEMDbContext : IdentityDbContext
{
    public DbSet<Processo> Processos { get; set; } = null!;
    public DbSet<Servidor> Servidores { get; set; } = null!;
    public DbSet<Envolvido> Envolvidos { get; set; } = null!;
    public DbSet<Tramitacao> Tramitacoes { get; set; } = null!;
    public DbSet<Prorrogacao> Prorrogacoes { get; set; } = null!;
    public DbSet<Historico> Historicos { get; set; } = null!;
    public DbSet<Documento> Documentos { get; set; } = null!;

    public PROGEMDbContext(DbContextOptions<PROGEMDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new ProcessoConfiguration());
        modelBuilder.ApplyConfiguration(new ServidorConfiguration());
        modelBuilder.ApplyConfiguration(new EnvolvidoConfiguration());
        modelBuilder.ApplyConfiguration(new TramitacaoConfiguration());
        modelBuilder.ApplyConfiguration(new ProrrogacaoConfiguration());
        modelBuilder.ApplyConfiguration(new HistoricoConfiguration());
        modelBuilder.ApplyConfiguration(new DocumentoConfiguration());

        modelBuilder.Entity<Processo>(entity =>
        {
            entity.Property(e => e.Numero).IsRequired().HasMaxLength(20);
            entity.Property(e => e.Requerente).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Local).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Assunto).IsRequired().HasMaxLength(500);
            entity.Property(e => e.Observacoes).HasMaxLength(2000);
            entity.Property(e => e.MotivoEncerramento).HasMaxLength(500);
            entity.Property(e => e.Anexo).HasMaxLength(500);
            entity.Property(e => e.Volume).HasMaxLength(100);
            entity.Property(e => e.Codigo).HasMaxLength(50);
        });

        modelBuilder.Entity<Servidor>(entity =>
        {
            entity.Property(e => e.Nome).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Cargo).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Secretaria).IsRequired().HasMaxLength(100);
        });
    }
}