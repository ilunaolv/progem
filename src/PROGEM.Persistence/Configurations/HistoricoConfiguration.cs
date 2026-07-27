using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PROGEM.Domain.Entities;

namespace PROGEM.Persistence.Configurations;

public class HistoricoConfiguration : IEntityTypeConfiguration<Historico>
{
    public void Configure(EntityTypeBuilder<Historico> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).ValueGeneratedOnAdd();
        builder.Property(e => e.ProcessoId).IsRequired();
        builder.Property(e => e.CampoAlterado).IsRequired().HasMaxLength(200);
        builder.Property(e => e.ValorAnterior).HasMaxLength(500);
        builder.Property(e => e.ValorNovo).HasMaxLength(500);
        builder.Property(e => e.Usuario).IsRequired().HasMaxLength(200);
        builder.Property(e => e.Data).IsRequired();
        builder.Property(e => e.IP).HasMaxLength(50);
        builder.Property(e => e.CriadoEm).IsRequired();

        builder.ToTable("Historicos");
    }
}