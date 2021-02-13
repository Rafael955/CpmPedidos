using CpmPedidos.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CpmPedidos.Repository
{
    public class ComboMapping : BaseDomainMapping<Combo>
    {
        public ComboMapping() : base("tb_combo")
        {

        }

        public override void Configure(EntityTypeBuilder<Combo> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Nome).HasColumnName("nome").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Preco).HasColumnName("preco").HasPrecision(17, 2).IsRequired();
            builder.Property(x => x.Ativo).HasColumnName("ativo").IsRequired();

            //Associações unidirecionais UM PARA MUITOS
            builder.Property(x => x.ImagemId).HasColumnName("imagem_id").IsRequired();
            builder.HasOne(x => x.Imagem).WithMany().HasForeignKey(x => x.ImagemId);

            builder
                .HasMany(x => x.Produtos)
                .WithMany(x => x.Combos)
                .UsingEntity<ProdutoCombo>(
                    x => x.HasOne(y => y.Produto).WithMany().HasForeignKey(y => y.ProdutoId),
                    x => x.HasOne(y => y.Combo).WithMany().HasForeignKey(y => y.ComboId),
                    x =>
                    {
                        x.ToTable("tb_produto_combo");

                        x.HasKey(y => new { y.ProdutoId, y.ComboId }); // chave composta

                        x.Property(x => x.ProdutoId).HasColumnName("produto_id").IsRequired();
                        x.Property(x => x.ComboId).HasColumnName("combo_id").IsRequired();
                    });
        }
    }


}
