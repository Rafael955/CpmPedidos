using System.Collections.Generic;

namespace CpmPedidos.Domain
{
    public class Combo : BaseDomain, IExibivel
    {
        public string Nome { get; set; }

        public decimal Preco { get; set; }


        public int ImagemId { get; set; }

        public virtual Imagem Imagem { get; set; }

        public List<Produto> Produtos { get; set; }


        public bool Ativo { get; set; }
    }
}
