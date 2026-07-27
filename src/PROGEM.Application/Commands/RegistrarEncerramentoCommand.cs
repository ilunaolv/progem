using MediatR;

namespace PROGEM.Application.Commands;

public record RegistrarEncerramentoCommand(
    Guid ProcessoId,
    DateTime DataEncerramento,
    string Motivo
) : IRequest<ProcessoDto>;