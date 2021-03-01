
using System;
using System.Collections.Generic;

namespace CpmPedidos.Domain
{
    //Exemplo de Entidade Rica
    public class Produto : BaseDomain, IExibivel
    {
        protected Produto() { } //construtor para o Entity Framework

        public Produto(string nome, string codigo, string descricao, decimal preco, bool ativo)
        {
            Nome = nome;
            Codigo = codigo;
            Descricao = descricao;
            Preco = preco;
            Ativo = ativo;
            _errors = new List<string>();
            Validate();
        }

        //Possui propriedades
        public string Nome { get; private set; }

        public string Codigo { get; private set; }

        public string Descricao { get; private set; }

        public decimal Preco { get; private set; }


        public int CategoriaId { get; set; }

        public virtual CategoriaProduto Categoria { get; set; }


        public virtual List<Imagem> Imagens { get; set; }

        public virtual List<PromocaoProduto> Promocoes { get; set; }

        public virtual List<Combo> Combos { get; set; }


        public bool Ativo { get; private set; }

        //Possui comportamentos
        public void AlterarNome(string nome)
        {
            Nome = nome;
            Validate();
        }

        public void AlterarCodigo(string codigo)
        {
            Codigo = codigo;
            Validate();
        }

        public void AlterarDescricao(string descricao)
        {
            Descricao = descricao;
            Validate();
        }

        public void AlterarPreco(decimal preco)
        {
            Preco = preco;
            Validate();
        }

        public void IsAtivo(bool condition)
        {
            Ativo = condition;
            Validate();
        }

        //Se auto valida
        public override bool Validate()
        {
            var validator = new ProdutoValidator();
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
