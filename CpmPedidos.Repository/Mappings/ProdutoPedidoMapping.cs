using CpmPedidos.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CpmPedidos.Repository.Mappings
{
    public class ProdutoPedidoMapping : BaseDomainMapping<ProdutoPedido>
    {
        public ProdutoPedidoMapping() : base("tb_produto_pedido")
        {

        }

        public override void Configure(EntityTypeBuilder<ProdutoPedido> builder)
        {
            base.Configure(builder);
        }
    }


}
