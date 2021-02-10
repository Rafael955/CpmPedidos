﻿using CpmPedidos.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CpmPedidos.Repository
{
    public class CategoriaProdutoMapping : BaseDomainMapping<CategoriaProduto>
    {
        public CategoriaProdutoMapping() : base("tb_categoria_produto")
        {

        }

        public override void Configure(EntityTypeBuilder<CategoriaProduto> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Nome).HasColumnName("nome").HasMaxLength(100).IsRequired();
            builder.Property(x => x.Ativo).HasColumnName("ativo").IsRequired();
        }
    }
}
