using CpmPedidos.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CpmPedidos.Repository.Mappings
{
    public class PromocaoProdutoMapping : BaseDomainMapping<PromocaoProduto>
    {
        public PromocaoProdutoMapping() : base("tb_promocao_produto")
        {

        }

        public override void Configure(EntityTypeBuilder<PromocaoProduto> builder)
        {
            base.Configure(builder);
        }
    }


}
