using MediatR;

namespace PROGEM.Application.Commands;

public record CreateProrrogacaoCommand(
    Guid ProcessoId,
    int QuantidadeDias,
    DateTime DataAnterior,
    DateTime NovaData,
    string Motivo,
    string Usuario
) : IRequest<ProrrogacaoDto>;