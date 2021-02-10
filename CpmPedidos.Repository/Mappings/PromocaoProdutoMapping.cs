using CpmPedidos.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CpmPedidos.Repository
{
    public class PromocaoProdutoMapping : BaseDomainMapping<PromocaoProduto>
    {
        public PromocaoProdutoMapping() : base("tb_promocao_produto")
        {

        }

        public override void Configure(EntityTypeBuilder<PromocaoProduto> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Nome).HasColumnName("nome").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Preco).HasColumnName("preco").HasPrecision(17, 2).IsRequired();
            builder.Property(x => x.Ativo).HasColumnName("ativo").IsRequired();

            //Associações unidirecionais UM PARA MUITOS
            builder.Property(x => x.ImagemId).HasColumnName("imagem_id").IsRequired();
            builder.HasOne(x => x.Imagem).WithMany().HasForeignKey(x => x.ImagemId);

            //Associações bidirecionais UM PARA MUITOS
            builder.Property(x => x.ProdutoId).HasColumnName("produto_id").IsRequired();
            builder.HasOne(x => x.Produto).WithMany(x => x.Promocoes).HasForeignKey(x => x.ProdutoId);
        }
    }


}
