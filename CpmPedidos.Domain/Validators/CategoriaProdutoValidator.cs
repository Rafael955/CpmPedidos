using FluentValidation;
using System;

namespace CpmPedidos.Domain
{
    public class CategoriaProdutoValidator : AbstractValidator<CategoriaProduto>
    {
        public CategoriaProdutoValidator()
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

            //RuleFor(x => x.CriadoEm)
            //    .Must(BeTodayDate);
        }

        //protected bool BeTodayDate(DateTime date)
        //{
        //    return date.Date == DateTime.Today.Date ? true : false;
        //}
    }
}
