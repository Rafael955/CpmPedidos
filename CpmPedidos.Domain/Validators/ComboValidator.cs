using FluentValidation;

namespace CpmPedidos.Domain
{
    public class ComboValidator : AbstractValidator<Combo>
    {
        public ComboValidator()
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

                .MinimumLength(5)
                .WithMessage("O nome deverá ter no mínimo 5 caracteres!")

                .MaximumLength(50)
                .WithMessage("O nome deverá ter no máximo 50 caracteres!");

            RuleFor(x => x.Preco)
                .NotNull()
                .WithMessage("O preço não pode ser nulo!")

                .ScalePrecision(17, 2);
        }
    }
}
