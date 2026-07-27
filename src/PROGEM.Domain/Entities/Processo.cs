using PROGEM.Domain.Enums;
using PROGEM.Domain.ValueObjects;

namespace PROGEM.Domain.Entities;

public class Processo
{
    public Guid Id { get; private set; }
    public NumeroProcesso Numero { get; private set; }
    public int Ano { get; private set; }
    public string? Codigo { get; private set; }
    public string? Anexo { get; private set; }
    public string? Volume { get; private set; }
    public NaturalezaProcesso Natureza { get; private set; }
    public CategoriaProcesso Categoria { get; private set; }
    public SubcategoriaProcesso Subcategoria { get; private set; }
    public string Requerente { get; private set; }
    public string Local { get; private set; }
    public TipoProcesso Tipo { get; private set; }
    public StatusProcesso Status { get; private set; }
    public string Assunto { get; private set; }
    public DateTime DataIrregularidade { get; private set; }
    public DateTime DataInstalacao { get; private set; }
    public DateTime DataPrescricao { get; private set; }
    public DateTime? DataEncerramento { get; private set; }
    public string? MotivoEncerramento { get; private set; }
    public string? Observacoes { get; private set; }
    public DateTime CriadoEm { get; private set; }
    public DateTime AtualizadoEm { get; private set; }

    public List<Envolvido> Envolvidos { get; private set; } = new();
    public List<Tramitacao> Tramitacoes { get; private set; } = new();
    public List<Prorrogacao> Prorrogacoes { get; private set; } = new();
    public List<Historico> Historicos { get; private set; } = new();
    public List<Documento> Documentos { get; private set; } = new();

    private Processo() { }

    public static Processo Criar(
        NumeroProcesso numero,
        int ano,
        string? codigo,
        string? anexo,
        string? volume,
        NaturalezaProcesso natureza,
        CategoriaProcesso categoria,
        SubcategoriaProcesso subcategoria,
        string requerente,
        string local,
        TipoProcesso tipo,
        string assunto,
        DateTime dataIrregularidade,
        string observacoes)
    {
        var processo = new Processo
        {
            Id = Guid.NewGuid(),
            Numero = numero,
            Ano = ano,
            Codigo = codigo,
            Anexo = anexo,
            Volume = volume,
            Natureza = natureza,
            Categoria = categoria,
            Subcategoria = subcategoria,
            Requerente = requerente ?? throw new DomainException("Requerente is required."),
            Local = local ?? throw new DomainException("Local is required."),
            Tipo = tipo,
            Status = StatusProcesso.Preliminar,
            Assunto = assunto ?? throw new DomainException("Assunto is required."),
            DataIrregularidade = dataIrregularidade,
            DataInstalacao = DateTime.UtcNow,
            DataPrescricao = CalcularPrescricao(natureza, dataIrregularidade),
            Observacoes = observacoes,
            CriadoEm = DateTime.UtcNow,
            AtualizadoEm = DateTime.UtcNow
        };

        processo.AdicionarTramitacaoInicial();

        return processo;
    }

    private static DateTime CalcularPrescricao(NaturalezaProcesso natureza, DateTime dataIrregularidade)
    {
        return natureza switch
        {
            NaturalezaProcesso.Sindicancia or NaturalezaProcesso.Sumario => dataIrregularidade.AddYears(2),
            NaturalezaProcesso.Inquisito => dataIrregularidade.AddYears(2),
            _ => DateTime.MaxValue
        };
    }

    public void AtualizarPrescricao()
    {
        DataPrescricao = CalcularPrescricao(Natureza, DataIrregularidade);
    }

    public void AlterarDataIrregularidade(DateTime novaData)
    {
        DataIrregularidade = novaData;
        AtualizarPrescricao();
        AtualizadoEm = DateTime.UtcNow;
    }

    public void AvancarStatus(StatusProcesso novoStatus)
    {
        Status = novoStatus;
        AtualizadoEm = DateTime.UtcNow;
    }

    public void RegistrarEncerramento(DateTime dataEncerramento, string motivo)
    {
        if (DataEncerramento.HasValue)
            throw new DomainException("Processo already has an encerramento date.");

        DataEncerramento = dataEncerramento;
        MotivoEncerramento = motivo ?? throw new DomainException("Motivo is required for encerramento.");
        Status = StatusProcesso.Encerrado;
        AtualizadoEm = DateTime.UtcNow;
    }

    public void Reabrir(string motivo, string usuario)
    {
        if (Status == StatusProcesso.Reaberto)
            throw new DomainException("Processo is already reaberto.");

        Status = StatusProcesso.Reaberto;
        DataEncerramento = null;
        MotivoEncerramento = null;
        AtualizadoEm = DateTime.UtcNow;

        AdicionarHistorico("Status", "Encerrado", "Reaberto", usuario);
    }

    public void AdicionarEnvolvido(Envolvido envolvido)
    {
        if (envolvido is null)
            throw new DomainException("Envolvido cannot be null.");

        Envolvidos.Add(envolvido);
    }

    public void AdicionarTramitacao(Tramitacao tramitacao)
    {
        if (tramitacao is null)
            throw new DomainException("Tramitacao cannot be null.");

        Tramitacoes.Add(tramitacao);
    }

    public void AdicionarProrrogacao(Prorrogacao prorrogacao)
    {
        if (prorrogacao is null)
            throw new DomainException("Prorrogacao cannot be null.");

        Prorrogacoes.Add(prorrogacao);
    }

    public void AdicionarDocumento(Documento documento)
    {
        if (documento is null)
            throw new DomainException("Documento cannot be null.");

        Documentos.Add(documento);
    }

    private void AdicionarTramitacaoInicial()
    {
        Tramitacoes.Add(Tramitacao.Criar(
            "Inicial",
            "Preliminar",
            "Sistema",
            DateTime.UtcNow,
            "Processo criado automaticamente.",
            TipoTramitacao.Origem
        ));
    }

    public void AdicionarHistorico(string campo, string valorAnterior, string valorNovo, string usuario, string ip = "127.0.0.1")
    {
        Historicos.Add(Historico.Criar(Id, campo, valorAnterior, valorNovo, usuario, ip));
    }

    public bool PodeProrrogar()
    {
        return Natureza is NaturalezaProcesso.Sindicancia or NaturalezaProcesso.Sumario
               && Status is not StatusProcesso.Encerrado and not StatusProcesso.Arquivado;
    }

    public bool NaoPodeProrrogar()
    {
        return Natureza == NaturalezaProcesso.Inquisito;
    }
}

public enum TipoProcesso
{
    Administrativo = 0,
    Penalidade = 1,
    Sindicancia = 2
}