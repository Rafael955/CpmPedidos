using System;
using System.Collections.Generic;

namespace CpmPedidos.Domain
{
    public class Imagem : BaseDomain
    {
        public Imagem()
        {

        }

        public Imagem(string nome, string nomeArquivo, bool principal)
        {
            Nome = nome;
            NomeArquivo = nomeArquivo;
            Principal = principal;
        }

        public string Nome { get; private set; }

        public string NomeArquivo { get; private set; }

        public bool Principal { get; private set; }


        public virtual List<Produto> Produtos { get; set; }

        public override bool Validate()
        {
            var validator = new ImagemValidator();
            var validation = validator.Validate(this);

            if (!validation.IsValid)
            {
                foreach (var error in validation.Errors)
                    _errors.Add(error.ErrorMessage);

                throw new Exception("Alguns campos estão inválidos, por favor corrija-os" + _errors[0]);
            }

            return true;
        }
    }
}