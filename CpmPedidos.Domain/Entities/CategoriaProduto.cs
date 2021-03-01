using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpmPedidos.Domain
{
    public class CategoriaProduto : BaseDomain, IExibivel
    {
        public CategoriaProduto()
        {

        }

        public CategoriaProduto(string nome, bool ativo)
        {
            Nome = nome;
            Ativo = ativo;
        }

        public string Nome { get; private set; }

        public bool Ativo { get; private set; }


        public void AlterarNome(string nome)
        {
            Nome = nome;
            Validate();
        }

        public void AlterarStatus(bool status)
        {
            Ativo = status;
        }

        public virtual List<Produto> Produtos { get; set; }


        public override bool Validate()
        {
            var validator = new CategoriaProdutoValidator();
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