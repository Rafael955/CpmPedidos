using CpmPedidos.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CpmPedidos.Repository
{
    public class ProdutoMapping : BaseDomainMapping<Produto>
    {
        public ProdutoMapping() : base("tb_produto")
        {

        }

        public override void Configure(EntityTypeBuilder<Produto> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Nome).HasColumnName("nome").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Codigo).HasColumnName("codigo").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Descricao).HasColumnName("descricao").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Descricao).HasColumnName("preco").HasPrecision(17, 2).IsRequired();
            builder.Property(x => x.Ativo).HasColumnName("ativo").IsRequired();

            //Associações bidirecionais UM PARA MUITOS
            builder.Property(x => x.CategoriaId).HasColumnName("categoria_id").IsRequired();
            builder.HasOne(x => x.Categoria).WithMany(x => x.Produtos).HasForeignKey(x => x.CategoriaId);

            builder
               .HasMany(x => x.Imagens)
               .WithMany(x => x.Produtos)
               .UsingEntity<ImagemProduto>(
                   x => x.HasOne(y => y.Imagem).WithMany().HasForeignKey(y => y.ImagemId),
                   x => x.HasOne(y => y.Produto).WithMany().HasForeignKey(y => y.ProdutoId),
                   x =>
                   {
                       x.ToTable("tb_imagem_produto");

                       x.HasKey(y => new { y.ImagemId, y.ProdutoId }); // chave composta

                        x.Property(x => x.ImagemId).HasColumnName("imagem_id").IsRequired();
                       x.Property(x => x.ProdutoId).HasColumnName("produto_id").IsRequired();
                   });
        }
    }


}
