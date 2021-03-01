using System;
using System.Collections.Generic;

namespace CpmPedidos.Domain
{
    public class Pedido : BaseDomain
    {
        public Pedido()
        {

        }

        public Pedido(string numero, decimal valorTotal, TimeSpan entrega)
        {
            Numero = numero;
            ValorTotal = valorTotal;
            Entrega = entrega;
        }

        public string Numero { get; private set; }

        public decimal ValorTotal { get; private set; }

        public TimeSpan Entrega { get; private set; }

        
        public int ClienteId { get; set; }

        public virtual Cliente Cliente { get; set; }


        public virtual List<ProdutoPedido> Produtos { get; set; }


        public override bool Validate()
        {
            var validator = new PedidoValidator();
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
