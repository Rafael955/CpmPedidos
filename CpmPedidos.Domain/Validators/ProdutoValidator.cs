using FluentValidation;
using System;

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

            RuleFor(x => x.Nome)
                .NotNull()
                .WithMessage("O nome não pode ser nulo!")

                .NotEmpty()
                .WithMessage("O nome não pode ser vazio!")

                .MinimumLength(5)
                .WithMessage("O nome deverá ter no mínimo 5 caracteres!")

                .MaximumLength(50)
                .WithMessage("O nome deverá ter no máximo 50 caracteres!");

            RuleFor(x => x.Codigo)
                 .NotNull()
                .WithMessage("O código não pode ser nulo!")

                .NotEmpty()
                .WithMessage("O código não pode ser vazio!")

                .MinimumLength(3)
                .WithMessage("O código deverá ter no mínimo 3 caracteres!")

                .MaximumLength(50)
                .WithMessage("O código deverá ter no máximo 50 caracteres!");

            RuleFor(x => x.Descricao)
                .NotNull()
                .WithMessage("A descrição não pode ser nulo!")

                .MaximumLength(50)
                .WithMessage("A descrição deverá ter no máximo 50 caracteres!");

            RuleFor(x => x.Preco)
                .NotNull()
                .WithMessage("O preço não pode ser nulo!")

                .ScalePrecision(17, 2);

            RuleFor(x => x.CriadoEm)
                .Must(BeTodayDate);
        }

        protected bool BeTodayDate(DateTime date)
        {
            return date.Date == DateTime.Today.Date ? true : false;
        }
    }

    public class EnderecoValidator : AbstractValidator<Endereco>
    {
        public EnderecoValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A entidade não pode se vazia!")

                .NotNull()
                .WithMessage("A entidade não pode ser nula!");

            RuleFor(x => x.Logradouro)
                .NotNull()
                .WithMessage("O logradouro não pode ser nulo!")

                .NotEmpty()
                .WithMessage("O logradouro não pode ser vazio!")

                .MinimumLength(5)
                .WithMessage("O logradouro deverá ter no mínimo 5 caracteres!")

                .MaximumLength(50)
                .WithMessage("O logradouro deverá ter no máximo 50 caracteres!");
        }
    }

    public class ImagemValidator : AbstractValidator<Imagem>
    {
        public ImagemValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A entidade não pode se vazia!")

                .NotNull()
                .WithMessage("A entidade não pode ser nula!");
        }
    }

    public class PedidoValidator : AbstractValidator<Pedido>
    {
        public PedidoValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A entidade não pode se vazia!")

                .NotNull()
                .WithMessage("A entidade não pode ser nula!");
        }
    }

    public class ProdutoPedidoValidator : AbstractValidator<ProdutoPedido>
    {
        public ProdutoPedidoValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A entidade não pode se vazia!")

                .NotNull()
                .WithMessage("A entidade não pode ser nula!");
        }
    }

    public class PromocaoProdutoValidator : AbstractValidator<PromocaoProduto>
    {
        public PromocaoProdutoValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A entidade não pode se vazia!")

                .NotNull()
                .WithMessage("A entidade não pode ser nula!");
        }
    }

}
