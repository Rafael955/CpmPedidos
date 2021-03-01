using System;
using System.Collections.Generic;

namespace CpmPedidos.Domain
{
    public class Combo : BaseDomain, IExibivel
    {
        public Combo()
        {

        }

        public Combo(string nome, decimal preco, bool ativo)
        {
            Nome = nome;
            Preco = preco;
            Ativo = ativo;
        }

        public string Nome { get; private set; }

        public decimal Preco { get; private set; }

        public bool Ativo { get; private set; }

        
        public int ImagemId { get; set; }

        public virtual Imagem Imagem { get; set; }


        public virtual List<Produto> Produtos { get; set; }


        public override bool Validate()
        {
            var validator = new ComboValidator();
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
