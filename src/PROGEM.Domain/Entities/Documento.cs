using PROGEM.Domain.Enums;

namespace PROGEM.Domain.Entities;

public class Documento
{
    public Guid Id { get; private set; }
    public Guid ProcessoId { get; private set; }
    public string Nome { get; private set; }
    public string Caminho { get; private set; }
    public TipoDocumento Tipo { get; private set; }
    public long TamanhoBytes { get; private set; }
    public string MimeType { get; private set; }
    public string UploadedPor { get; private set; }
    public DateTime CriadoEm { get; private set; }

    private Documento() { }

    public static Documento Criar(Guid processoId, string nome, string caminho, TipoDocumento tipo, long tamanhoBytes, string mimeType, string uploadedPor)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new DomainException("Document nome is required.");

        if (string.IsNullOrWhiteSpace(caminho))
            throw new DomainException("Document caminho is required.");

        return new Documento
        {
            Id = Guid.NewGuid(),
            ProcessoId = processoId,
            Nome = nome,
            Caminho = caminho,
            Tipo = tipo,
            TamanhoBytes = tamanhoBytes,
            MimeType = mimeType ?? "application/octet-stream",
            UploadedPor = uploadedPor ?? throw new DomainException("UploadedPor is required."),
            CriadoEm = DateTime.UtcNow
        };
    }
}