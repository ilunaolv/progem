namespace PROGEM.Application.DTOs;

public class DocumentoDto
{
    public Guid Id { get; set; }
    public Guid ProcessoId { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Caminho { get; set; } = string.Empty;
    public TipoDocumento Tipo { get; set; }
    public long TamanhoBytes { get; set; }
    public string MimeType { get; set; } = string.Empty;
    public string UploadedPor { get; set; } = string.Empty;
    public DateTime CriadoEm { get; set; }
}