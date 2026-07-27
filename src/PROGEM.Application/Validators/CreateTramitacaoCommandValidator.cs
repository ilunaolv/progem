using FluentValidation;

namespace PROGEM.Application.Validators;

public class CreateTramitacaoCommandValidator : AbstractValidator<CreateTramitacaoCommand>
{
    public CreateTramitacaoCommandValidator()
    {
        RuleFor(x => x.ProcessoId).NotEmpty();
        RuleFor(x => x.Origem).NotEmpty().WithMessage("Origem is required.");
        RuleFor(x => x.Destino).NotEmpty().WithMessage("Destino is required.");
    }
}