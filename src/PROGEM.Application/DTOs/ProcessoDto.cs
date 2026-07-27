using PROGEM.Domain.Enums;

namespace PROGEM.Application.DTOs;

public class ProcessoDto
{
    public Guid Id { get; set; }
    public string Numero { get; set; } = string.Empty;
    public int Ano { get; set; }
    public string? Codigo { get; set; }
    public string? Anexo { get; set; }
    public string? Volume { get; set; }
    public NaturalezaProcesso Natureza { get; set; }
    public CategoriaProcesso Categoria { get; set; }
    public SubcategoriaProcesso Subcategoria { get; set; }
    public string Requerente { get; set; } = string.Empty;
    public string Local { get; set; } = string.Empty;
    public TipoProcesso Tipo { get; set; }
    public StatusProcesso Status { get; set; }
    public string Assunto { get; set; } = string.Empty;
    public DateTime DataIrregularidade { get; set; }
    public DateTime DataInstalacao { get; set; }
    public DateTime DataPrescricao { get; set; }
    public DateTime? DataEncerramento { get; set; }
    public string? MotivoEncerramento { get; set; }
    public string? Observacoes { get; set; }
    public DateTime CriadoEm { get; set; }
    public DateTime AtualizadoEm { get; set; }
}