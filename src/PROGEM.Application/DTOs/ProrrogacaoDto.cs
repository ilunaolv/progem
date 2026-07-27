namespace PROGEM.Application.DTOs;

public class ProrrogacaoDto
{
    public Guid Id { get; set; }
    public Guid ProcessoId { get; set; }
    public int QuantidadeDias { get; set; }
    public DateTime DataAnterior { get; set; }
    public DateTime NovaData { get; set; }
    public string Motivo { get; set; } = string.Empty;
    public string Usuario { get; set; } = string.Empty;
    public DateTime CriadoEm { get; set; }
}