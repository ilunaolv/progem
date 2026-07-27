namespace PROGEM.Domain.Entities;

public class Historico
{
    public Guid Id { get; private set; }
    public Guid ProcessoId { get; private set; }
    public string CampoAlterado { get; private set; }
    public string ValorAnterior { get; private set; }
    public string ValorNovo { get; private set; }
    public string Usuario { get; private set; }
    public DateTime Data { get; private set; }
    public string IP { get; private set; }
    public DateTime CriadoEm { get; private set; }

    private Historico() { }

    public static Historico Criar(Guid processoId, string campoAlterado, string valorAnterior, string valorNovo, string usuario, string ip)
    {
        return new Historico
        {
            Id = Guid.NewGuid(),
            ProcessoId = Guid.Empty,
            CampoAlterado = campoAlterado ?? throw new DomainException("CampoAlterado is required."),
            ValorAnterior = valorAnterior ?? string.Empty,
            ValorNovo = valorNovo ?? string.Empty,
            Usuario = usuario ?? throw new DomainException("Usuario is required."),
            Data = DateTime.UtcNow,
            IP = ip ?? "127.0.0.1",
            CriadoEm = DateTime.UtcNow
        };
    }
}