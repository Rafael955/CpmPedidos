using System;

namespace CpmPedidos.Domain
{
    public class ProdutoPedido : BaseDomain
    {
        public ProdutoPedido()
        {

        }

        public ProdutoPedido(int quantidade, decimal preco)
        {
            Quantidade = quantidade;
            Preco = preco;
        }

        public int Quantidade { get; private set; }

        public decimal Preco { get; private set; }
        
        
        public int ProdutoId { get; set; }

        public virtual Produto Produto { get; set; }

        public int PedidoId { get; set; }

        public virtual Pedido Pedido { get; set; }


        public override bool Validate()
        {
            var validator = new ProdutoPedidoValidator();
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
