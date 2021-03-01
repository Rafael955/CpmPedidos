using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpmPedidos.Domain
{
    public class Endereco : BaseDomain
    {
        public Endereco()
        {
            //EF
        }

        public Endereco(TipoEnderecoEnum tipo, string logradouro, string bairro, string numero, string complemento, string cep)
        {
            Tipo = tipo;
            Logradouro = logradouro;
            Bairro = bairro;
            Numero = numero;
            Complemento = complemento;
            Cep = cep;

            Validate();
        }

        public TipoEnderecoEnum Tipo { get; private set; }

        public string Logradouro { get; private set; }

        public string Bairro { get; private set; }

        public string Numero { get; private set; }

        public string Complemento { get; private set; }

        public string Cep { get; private set; }

        
        public int CidadeId { get; private set; }

        public virtual Cidade Cidade { get; set; }

        public int ClienteId { get; private set; }

        public virtual Cliente Cliente { get; set; }


        public void SetCidadeId(int id)
        {
            CidadeId = id;
        }

        public void SetClienteId(int id)
        {
            ClienteId = id;
        }

        public void SetTipo(TipoEnderecoEnum tipo)
        {
            Tipo = tipo;
            Validate();
        }

        public void SetLogradouro(string logradouro)
        {
            Logradouro = logradouro;
            Validate();
        }

        public void SetBairro(string bairro)
        {
            Bairro = bairro;
            Validate();
        }

        public void SetNumero(string numero)
        {
            Numero = numero;
            Validate();
        }

        public void SetComplemento(string complemento)
        {
            Complemento = complemento;
            Validate();
        }

        public void SetCep(string cep)
        {
            Cep = cep;
            Validate();
        }


        public override bool Validate()
        {
            var validator = new EnderecoValidator();
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
