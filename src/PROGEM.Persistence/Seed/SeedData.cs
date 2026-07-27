using PROGEM.Domain.Entities;
using PROGEM.Persistence.Data;

namespace PROGEM.Persistence.Seed;

public static class SeedData
{
    public static async Task SeedAsync(PROGEMDbContext context)
    {
        if (!context.Servidores.Any())
        {
            var servidor = Servidor.Criar(
                "Administrador Padrao",
                RF.Create("1234567"),
                "Administrador",
                "Procuradoria Geral",
                null,
                null
            );

            context.Servidores.Add(servidor);
            await context.SaveChangesAsync();
        }
    }
}