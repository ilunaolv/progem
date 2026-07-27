using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PROGEM.Domain.Entities;

namespace PROGEM.Persistence.Configurations;

public class ProrrogacaoConfiguration : IEntityTypeConfiguration<Prorrogacao>
{
    public void Configure(EntityTypeBuilder<Prorrogacao> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).ValueGeneratedOnAdd();
        builder.Property(e => e.ProcessoId).IsRequired();
        builder.Property(e => e.QuantidadeDias).IsRequired();
        builder.Property(e => e.DataAnterior).IsRequired();
        builder.Property(e => e.NovaData).IsRequired();
        builder.Property(e => e.Motivo).IsRequired().HasMaxLength(500);
        builder.Property(e => e.Usuario).IsRequired().HasMaxLength(200);
        builder.Property(e => e.CriadoEm).IsRequired();

        builder.ToTable("Prorrogacoes");
    }
}