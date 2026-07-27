using FluentValidation;

namespace PROGEM.Application.Validators;

public class CreateProcessoCommandValidator : AbstractValidator<CreateProcessoCommand>
{
    public CreateProcessoCommandValidator()
    {
        RuleFor(x => x.Numero).NotEmpty().WithMessage("Numero is required.")
            .Length(4, 20).WithMessage("Numero must be between 4 and 20 characters.");
        RuleFor(x => x.Ano).InclusiveBetween(2000, 2100).WithMessage("Ano must be between 2000 and 2100.");
        RuleFor(x => x.Requerente).NotEmpty().WithMessage("Requerente is required.");
        RuleFor(x => x.Local).NotEmpty().WithMessage("Local is required.");
        RuleFor(x => x.Assunto).NotEmpty().WithMessage("Assunto is required.");
    }
}