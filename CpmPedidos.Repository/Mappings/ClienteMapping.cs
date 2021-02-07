using CpmPedidos.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CpmPedidos.Repository.Mappings
{
    public class ClienteMapping : BaseDomainMapping<Cliente>
    {
        public ClienteMapping() : base("tb_cliente")
        {

        }

        public override void Configure(EntityTypeBuilder<Cliente> builder)
        {
            base.Configure(builder);
        }
    }


}
