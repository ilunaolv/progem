using PROGEM.Domain.Enums;

namespace PROGEM.Domain.Entities;

public class Tramitacao
{
    public Guid Id { get; private set; }
    public Guid ProcessoId { get; private set; }
    public string Origem { get; private set; }
    public string Destino { get; private set; }
    public string Responsavel { get; private set; }
    public DateTime Data { get; private set; }
    public string Observacao { get; private set; }
    public TipoTramitacao Tipo { get; private set; }
    public DateTime CriadoEm { get; private set; }

    private Tramitacao() { }

    public static Tramitacao Criar(string origem, string destino, string responsavel, DateTime data, string observacao, TipoTramitacao tipo)
    {
        if (string.IsNullOrWhiteSpace(origem))
            throw new DomainException("Origem is required.");

        if (string.IsNullOrWhiteSpace(destino))
            throw new DomainException("Destino is required.");

        return new Tramitacao
        {
            Id = Guid.NewGuid(),
            ProcessoId = Guid.Empty,
            Origem = origem,
            Destino = destino,
            Responsavel = responsavel ?? "Sistema",
            Data = data,
            Observacao = observacao ?? string.Empty,
            Tipo = tipo,
            CriadoEm = DateTime.UtcNow
        };
    }
}