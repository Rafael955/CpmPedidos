using FluentValidation;

namespace CpmPedidos.Domain
{
    public class ClienteValidator : AbstractValidator<Cliente>
    {
        public ClienteValidator()
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

            RuleFor(x => x.CPF)
                .NotEmpty()
                .WithMessage("O nome não pode ser vazio!")

                .NotNull()
                .WithMessage("O nome não pode ser nulo!")

                .MaximumLength(13)
                .WithMessage("O nome deverá ter no máximo 13 caracteres!")

                .Must(BeValidCPF)
                .WithMessage("CPF inválido!");
        }

        private bool BeValidCPF(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        } 
    }
}
