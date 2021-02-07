using CpmPedidos.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CpmPedidos.Repository.Mappings
{
    public class PedidoMapping : BaseDomainMapping<Pedido>
    {
        public PedidoMapping() : base("tb_pedido")
        {

        }

        public override void Configure(EntityTypeBuilder<Pedido> builder)
        {
            base.Configure(builder);
        }
    }


}
