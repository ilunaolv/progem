namespace PROGEM.Application.DTOs;

public class TramitacaoDto
{
    public Guid Id { get; set; }
    public Guid ProcessoId { get; set; }
    public string Origem { get; set; } = string.Empty;
    public string Destino { get; set; } = string.Empty;
    public string Responsavel { get; set; } = string.Empty;
    public DateTime Data { get; set; }
    public string Observacao { get; set; } = string.Empty;
    public TipoTramitacao Tipo { get; set; }
    public DateTime CriadoEm { get; set; }
}