namespace PROGEM.Domain.Entities;

public class Prorrogacao
{
    public Guid Id { get; private set; }
    public Guid ProcessoId { get; private set; }
    public int QuantidadeDias { get; private set; }
    public DateTime DataAnterior { get; private set; }
    public DateTime NovaData { get; private set; }
    public string Motivo { get; private set; }
    public string Usuario { get; private set; }
    public DateTime CriadoEm { get; private set; }

    private Prorrogacao() { }

    public static Prorrogacao Criar(Guid processoId, int quantidadeDias, DateTime dataAnterior, DateTime novaData, string motivo, string usuario)
    {
        if (quantidadeDias <= 0)
            throw new DomainException("Quantidade de dias must be greater than zero.");

        if (novaData <= dataAnterior)
            throw new DomainException("Nova data must be after data anterior.");

        return new Prorrogacao
        {
            Id = Guid.NewGuid(),
            ProcessoId = processoId,
            QuantidadeDias = quantidadeDias,
            DataAnterior = dataAnterior,
            NovaData = novaData,
            Motivo = motivo ?? throw new DomainException("Motivo is required."),
            Usuario = usuario ?? throw new DomainException("Usuario is required."),
            CriadoEm = DateTime.UtcNow
        };
    }
}