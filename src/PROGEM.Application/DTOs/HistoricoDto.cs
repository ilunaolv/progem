namespace PROGEM.Application.DTOs;

public class HistoricoDto
{
    public Guid Id { get; set; }
    public Guid ProcessoId { get; set; }
    public string CampoAlterado { get; set; } = string.Empty;
    public string ValorAnterior { get; set; } = string.Empty;
    public string ValorNovo { get; set; } = string.Empty;
    public string Usuario { get; set; } = string.Empty;
    public DateTime Data { get; set; }
    public string IP { get; set; } = string.Empty;
    public DateTime CriadoEm { get; set; }
}