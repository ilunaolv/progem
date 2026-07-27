using PROGEM.Domain.Enums;
using PROGEM.Domain.ValueObjects;

namespace PROGEM.Domain.Entities;

public class Envolvido
{
    public Guid Id { get; private set; }
    public Guid ProcessoId { get; private set; }
    public Guid ServidorId { get; private set; }
    public ResultadoEnvolvido Resultado { get; private set; }
    public int DiasSuspensao { get; private set; }
    public string? Observacao { get; private set; }
    public DateTime CriadoEm { get; private set; }

    private Envolvido() { }

    public static Envolvido Criar(Guid processoId, Guid servidorId, ResultadoEnvolvido resultado, int diasSuspensao, string? observacao)
    {
        if (resultado == ResultadoEnvolvido.Suspensao)
        {
            if (diasSuspensao < 1 || diasSuspensao > 90)
                throw new DomainException("Suspensao dias must be between 1 and 90.");
        }

        return new Envolvido
        {
            Id = Guid.NewGuid(),
            ProcessoId = processoId,
            ServidorId = servidorId,
            Resultado = resultado,
            DiasSuspensao = diasSuspensao,
            Observacao = observacao,
            CriadoEm = DateTime.UtcNow
        };
    }

    public void Atualizar(ResultadoEnvolvido resultado, int diasSuspensao, string? observacao)
    {
        if (resultado == ResultadoEnvolvido.Suspensao)
        {
            if (diasSuspensao < 1 || diasSuspensao > 90)
                throw new DomainException("Suspensao dias must be between 1 and 90.");
        }

        Resultado = resultado;
        DiasSuspensao = diasSuspensao;
        Observacao = observacao;
    }
}