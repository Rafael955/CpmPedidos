using CpmPedidos.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CpmPedidos.Repository.Mappings
{
    public class EnderecoMapping : BaseDomainMapping<Endereco>
    {
        public EnderecoMapping() : base("tb_endereco")
        {

        }

        public override void Configure(EntityTypeBuilder<Endereco> builder)
        {
            base.Configure(builder);
        }
    }


}
