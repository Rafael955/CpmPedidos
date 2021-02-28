using FluentValidation;

namespace CpmPedidos.Domain
{
    public class ProdutoValidator : AbstractValidator<Produto>
    {
        public ProdutoValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A entidade não pode se vazia!")

                .NotNull()
                .WithMessage("A entidade não pode ser nula!");

        }
    }
}
