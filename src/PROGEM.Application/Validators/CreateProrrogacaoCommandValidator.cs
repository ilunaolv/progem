using FluentValidation;

namespace PROGEM.Application.Validators;

public class CreateProrrogacaoCommandValidator : AbstractValidator<CreateProrrogacaoCommand>
{
    public CreateProrrogacaoCommandValidator()
    {
        RuleFor(x => x.ProcessoId).NotEmpty();
        RuleFor(x => x.QuantidadeDias).GreaterThan(0).WithMessage("QuantidadeDias must be greater than zero.");
        RuleFor(x => x.NovaData).GreaterThan(x => x.DataAnterior).WithMessage("NovaData must be after DataAnterior.");
        RuleFor(x => x.Motivo).NotEmpty().WithMessage("Motivo is required.");
        RuleFor(x => x.Usuario).NotEmpty().WithMessage("Usuario is required.");
    }
}