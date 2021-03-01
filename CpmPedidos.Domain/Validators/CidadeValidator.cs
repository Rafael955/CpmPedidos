using FluentValidation;

namespace CpmPedidos.Domain
{
    public class CidadeValidator : AbstractValidator<Cidade>
    {
        public CidadeValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A entidade não pode se vazia!")

                .NotNull()
                .WithMessage("A entidade não pode ser nula!");

            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("O nome não pode ser vazio!")

                .NotNull()
                .WithMessage("O nome não pode ser nulo!")

                .MinimumLength(3)
                .WithMessage("O nome deverá ter no mínimo 3 caracteres!")

                .MaximumLength(100)
                .WithMessage("O nome deverá ter no máximo 100 caracteres!");

            RuleFor(x => x.UF)
                .NotEmpty()
                .WithMessage("A unidade federativa não pode ser vazia!")

                .NotNull()
                .WithMessage("A unidade federativa não pode ser nula!")

                .MaximumLength(2)
                .WithMessage("A unidade federativa deverá ter no máximo 2 caracteres!");
        }
    }
}
