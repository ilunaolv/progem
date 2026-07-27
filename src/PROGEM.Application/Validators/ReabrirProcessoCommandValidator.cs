using FluentValidation;

namespace PROGEM.Application.Validators;

public class ReabrirProcessoCommandValidator : AbstractValidator<ReabrirProcessoCommand>
{
    public ReabrirProcessoCommandValidator()
    {
        RuleFor(x => x.ProcessoId).NotEmpty();
        RuleFor(x => x.Motivo).NotEmpty().WithMessage("Motivo is required.");
        RuleFor(x => x.Usuario).NotEmpty().WithMessage("Usuario is required.");
    }
}