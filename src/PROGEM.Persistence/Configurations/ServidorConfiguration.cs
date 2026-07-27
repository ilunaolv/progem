using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PROGEM.Domain.Entities;

namespace PROGEM.Persistence.Configurations;

public class ServidorConfiguration : IEntityTypeConfiguration<Servidor>
{
    public void Configure(EntityTypeBuilder<Servidor> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Nome)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(s => s.RF)
            .IsRequired();

        builder.Property(s => s.Cargo)
            .HasMaxLength(100);

        builder.Property(s => s.Secretaria)
            .HasMaxLength(200);

        builder.Property(s => s.Email)
            .IsRequired()
            .HasMaxLength(256);

        builder.Property(s => s.Telefone)
            .HasMaxLength(20);

        builder.Property(s => s.Ativo)
            .IsRequired();
    }
}