using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PROGEM.Domain.Entities;
using PROGEM.Domain.Enums;

namespace PROGEM.Persistence.Configurations;

public class ProcessoConfiguration : IEntityTypeConfiguration<Processo>
{
    public void Configure(EntityTypeBuilder<Processo> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).ValueGeneratedOnAdd();

        builder.OwnsOne(e => e.Numero, owned =>
        {
            owned.Property(v => v.Valor).HasColumnName("NumeroValor").HasMaxLength(20);
        });

        builder.Property(e => e.Ano).IsRequired();
        builder.Property(e => e.Codigo).HasMaxLength(50);
        builder.Property(e => e.Anexo).HasMaxLength(500);
        builder.Property(e => e.Volume).HasMaxLength(100);

        builder.Property(e => e.Natureza)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(e => e.Categoria)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(e => e.Subcategoria)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(e => e.Tipo)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(e => e.Status)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(e => e.Requerente).IsRequired().HasMaxLength(200);
        builder.Property(e => e.Local).IsRequired().HasMaxLength(200);
        builder.Property(e => e.Assunto).IsRequired().HasMaxLength(500);
        builder.Property(e => e.Observacoes).HasMaxLength(2000);
        builder.Property(e => e.MotivoEncerramento).HasMaxLength(500);

        builder.Property(e => e.DataIrregularidade).IsRequired();
        builder.Property(e => e.DataInstalacao).IsRequired();
        builder.Property(e => e.DataPrescricao).IsRequired();
        builder.Property(e => e.DataEncerramento);

        builder.Property(e => e.CriadoEm).IsRequired();
        builder.Property(e => e.AtualizadoEm).IsRequired();

        builder.HasMany(e => e.Envolvidos)
            .WithOne()
            .HasForeignKey("ProcessoId")
            .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);

        builder.HasMany(e => e.Tramitacoes)
            .WithOne()
            .HasForeignKey("ProcessoId")
            .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);

        builder.HasMany(e => e.Prorrogacoes)
            .WithOne()
            .HasForeignKey("ProcessoId")
            .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);

        builder.HasMany(e => e.Historicos)
            .WithOne()
            .HasForeignKey("ProcessoId")
            .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);

        builder.HasMany(e => e.Documentos)
            .WithOne()
            .HasForeignKey("ProcessoId")
            .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);

        builder.ToTable("Processos");
    }
}