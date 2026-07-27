using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PROGEM.Domain.Entities;

namespace PROGEM.Persistence.Configurations;

public class TramitacaoConfiguration : IEntityTypeConfiguration<Tramitacao>
{
    public void Configure(EntityTypeBuilder<Tramitacao> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).ValueGeneratedOnAdd();
        builder.Property(e => e.ProcessoId).IsRequired();
        builder.Property(e => e.Origem).IsRequired().HasMaxLength(200);
        builder.Property(e => e.Destino).IsRequired().HasMaxLength(200);
        builder.Property(e => e.Responsavel).HasMaxLength(200);
        builder.Property(e => e.Data).IsRequired();
        builder.Property(e => e.Observacao).HasMaxLength(1000);
        builder.Property(e => e.Tipo).HasConversion<int>().IsRequired();
        builder.Property(e => e.CriadoEm).IsRequired();

        builder.ToTable("Tramitacoes");
    }
}