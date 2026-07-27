using MediatR;
using PROGEM.Domain.Enums;

namespace PROGEM.Application.Commands;

public record CreateTramitacaoCommand(
    Guid ProcessoId,
    string Origem,
    string Destino,
    string Responsavel,
    DateTime Data,
    string Observacao,
    TipoTramitacao Tipo
) : IRequest<TramitacaoDto>;