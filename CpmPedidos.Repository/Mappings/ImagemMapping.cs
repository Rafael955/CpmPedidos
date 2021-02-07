using CpmPedidos.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CpmPedidos.Repository.Mappings
{
    public class ImagemMapping : BaseDomainMapping<Imagem>
    {
        public ImagemMapping() : base("tb_imagem")
        {

        }

        public override void Configure(EntityTypeBuilder<Imagem> builder)
        {
            base.Configure(builder);
        }
    }


}
