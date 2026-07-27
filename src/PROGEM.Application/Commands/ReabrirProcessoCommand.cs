using MediatR;

namespace PROGEM.Application.Commands;

public record ReabrirProcessoCommand(
    Guid ProcessoId,
    string Motivo,
    string Usuario
) : IRequest<ProcessoDto>;