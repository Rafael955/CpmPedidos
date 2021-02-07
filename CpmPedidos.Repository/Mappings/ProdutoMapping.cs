using CpmPedidos.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CpmPedidos.Repository.Mappings
{
    public class ProdutoMapping : BaseDomainMapping<Produto>
    {
        public ProdutoMapping() : base("tb_produto")
        {

        }

        public override void Configure(EntityTypeBuilder<Produto> builder)
        {
            base.Configure(builder);
        }
    }


}
