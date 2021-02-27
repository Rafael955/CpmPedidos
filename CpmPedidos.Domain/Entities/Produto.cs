using System.Collections.Generic;

namespace CpmPedidos.Domain
{
    public class Produto : BaseDomain, IExibivel
    {
        //protected Produto() { } //construtor para o Entity Framework

        //public Produto(string nome, string codigo, string descricao, decimal preco)
        //{
        //    Nome = nome;
        //    Codigo = codigo;
        //    Descricao = descricao;
        //    Preco = preco;
        //    _errors = new List<string>();
        //}

        public string Nome { get; set; }

        public string Codigo { get; set; }

        public string Descricao { get; set; }

        public decimal Preco { get; set; }


        public int CategoriaId { get; set; }

        public virtual CategoriaProduto Categoria { get; set; }


        public virtual List<Imagem> Imagens { get; set; }

        public virtual List<PromocaoProduto> Promocoes { get; set; }

        public virtual List<Combo> Combos { get; set; }


        public bool Ativo { get; set; }


        //public void AlterarNome(string nome)
        //{
        //    Nome = nome;
        //    Validate();
        //}

        //public void AlterarCodigo(string nome)
        //{
        //    Nome = nome;
        //    Validate();
        //}

        //public void AlterarDescricao(string nome)
        //{
        //    Nome = nome;
        //    Validate();
        //}

        //public void AlterarPreco(string nome)
        //{
        //    Nome = nome;
        //    Validate();
        //}

    }
}
