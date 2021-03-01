using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpmPedidos.Domain
{
    public class Cidade : BaseDomain, IExibivel
    {
        public Cidade()
        {

        }

        public Cidade(string nome, string uF, bool ativo)
        {
            Nome = nome;
            UF = uF;
            Ativo = ativo;
            Validate();
        }

        public string Nome { get; private set; }
        
        public string UF { get; private set; }

        public bool Ativo { get; private set; }


        public void AlterarNome(string nome)
        {
            Nome = nome;
            Validate();
        }

        public void AlterarUF(string uf)
        {
            UF = uf;
            Validate();
        }

        public void AlterarStatus(bool status)
        {
            Ativo = status;
        }

        public override bool Validate()
        {
            var validator = new CidadeValidator();
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
