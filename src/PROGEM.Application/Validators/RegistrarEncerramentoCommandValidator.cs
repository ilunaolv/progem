using FluentValidation;

namespace PROGEM.Application.Validators;

public class RegistrarEncerramentoCommandValidator : AbstractValidator<RegistrarEncerramentoCommand>
{
    public RegistrarEncerramentoCommandValidator()
    {
        RuleFor(x => x.ProcessoId).NotEmpty();
        RuleFor(x => x.DataEncerramento).NotEmpty().WithMessage("DataEncerramento is required.");
        RuleFor(x => x.Motivo).NotEmpty().WithMessage("Motivo is required.");
    }
}