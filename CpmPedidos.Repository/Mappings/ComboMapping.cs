using CpmPedidos.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CpmPedidos.Repository.Mappings
{
    public class ComboMapping : BaseDomainMapping<Combo>
    {
        public ComboMapping() : base("tb_combo")
        {

        }

        public override void Configure(EntityTypeBuilder<Combo> builder)
        {
            base.Configure(builder);
        }
    }


}
