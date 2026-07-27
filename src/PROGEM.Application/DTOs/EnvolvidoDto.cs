namespace PROGEM.Application.DTOs;

public class EnvolvidoDto
{
    public Guid Id { get; set; }
    public Guid ProcessoId { get; set; }
    public Guid ServidorId { get; set; }
    public string ServidorNome { get; set; } = string.Empty;
    public string ServidorRF { get; set; } = string.Empty;
    public ResultadoEnvolvido Resultado { get; set; }
    public int DiasSuspensao { get; set; }
    public string? Observacao { get; set; }
    public DateTime CriadoEm { get; set; }
}