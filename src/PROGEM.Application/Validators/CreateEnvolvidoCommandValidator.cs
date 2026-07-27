using FluentValidation;

namespace PROGEM.Application.Validators;

public class CreateEnvolvidoCommandValidator : AbstractValidator<CreateEnvolvidoCommand>
{
    public CreateEnvolvidoCommandValidator()
    {
        RuleFor(x => x.ProcessoId).NotEmpty();
        RuleFor(x => x.ServidorId).NotEmpty();
        RuleFor(x => x.DiasSuspensao).InclusiveBetween(0, 90).WithMessage("DiasSuspensao must be between 0 and 90.")
            .Must((cmd, dias) => cmd.Resultado != ResultadoEnvolvido.Suspensao || dias >= 1)
            .WithMessage("DiasSuspensao must be at least 1 when Resultado is Suspensao.");
    }
}