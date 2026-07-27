using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PROGEM.Domain.Entities;

namespace PROGEM.Persistence.Configurations;

public class DocumentoConfiguration : IEntityTypeConfiguration<Documento>
{
    public void Configure(EntityTypeBuilder<Documento> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).ValueGeneratedOnAdd();
        builder.Property(e => e.ProcessoId).IsRequired();
        builder.Property(e => e.Nome).IsRequired().HasMaxLength(300);
        builder.Property(e => e.Caminho).IsRequired().HasMaxLength(500);
        builder.Property(e => e.Tipo).HasConversion<int>().IsRequired();
        builder.Property(e => e.TamanhoBytes).IsRequired();
        builder.Property(e => e.MimeType).HasMaxLength(100);
        builder.Property(e => e.UploadedPor).IsRequired().HasMaxLength(200);
        builder.Property(e => e.CriadoEm).IsRequired();

        builder.ToTable("Documentos");
    }
}