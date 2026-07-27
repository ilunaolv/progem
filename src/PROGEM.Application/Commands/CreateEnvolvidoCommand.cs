using MediatR;
using PROGEM.Domain.Enums;

namespace PROGEM.Application.Commands;

public record CreateEnvolvidoCommand(
    Guid ProcessoId,
    Guid ServidorId,
    ResultadoEnvolvido Resultado,
    int DiasSuspensao,
    string? Observacao
) : IRequest<EnvolvidoDto>;