using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PROGEM.Domain.Entities;

namespace PROGEM.Persistence.Configurations;

public class EnvolvidoConfiguration : IEntityTypeConfiguration<Envolvido>
{
    public void Configure(EntityTypeBuilder<Envolvido> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).ValueGeneratedOnAdd();
        builder.Property(e => e.ProcessoId).IsRequired();
        builder.Property(e => e.ServidorId).IsRequired();
        builder.Property(e => e.Resultado).HasConversion<int>().IsRequired();
        builder.Property(e => e.DiasSuspensao).IsRequired();
        builder.Property(e => e.Observacao).HasMaxLength(1000);
        builder.Property(e => e.CriadoEm).IsRequired();

        builder.ToTable("Envolvidos");
    }
}