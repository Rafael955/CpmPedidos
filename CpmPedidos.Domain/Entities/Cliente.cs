using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpmPedidos.Domain
{
    public class Cliente : BaseDomain, IExibivel
    {
        public Cliente()
        {

        }

        public Cliente(string nome, string cpf, bool ativo)
        {
            Nome = nome;
            CPF = cpf;
            Ativo = ativo;
        }

        public string Nome { get; private set; }

        public string CPF { get; private set; }

        public bool Ativo { get; private set; }


        public int EnderecoId { get; set; }

        public virtual Endereco Endereco { get; set; }


        public virtual List<Pedido> Pedidos { get; set; }


        public override bool Validate()
        {
            var validator = new ClienteValidator();
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
