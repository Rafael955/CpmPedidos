using CpmPedidos.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CpmPedidos.Repository
{
    public class PedidoMapping : BaseDomainMapping<Pedido>
    {
        public PedidoMapping() : base("tb_pedido")
        {

        }

        public override void Configure(EntityTypeBuilder<Pedido> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Numero).HasColumnName("numero").HasMaxLength(10).IsRequired();
            builder.Property(x => x.ValorTotal).HasColumnName("valor_total").HasPrecision(17, 2).IsRequired();
            builder.Property(x => x.Entrega).HasColumnName("entrega");

            //Associações bidirecionais UM PARA MUITOS
            builder.Property(x => x.ClienteId).HasColumnName("cliente_id").IsRequired();
            builder.HasOne(x => x.Cliente).WithMany(x => x.Pedidos).HasForeignKey(x => x.ClienteId);
        }
    }


}
