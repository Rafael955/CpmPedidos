﻿using CpmPedidos.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpmPedidos.Repository
{
    public class CidadeMapping : BaseDomainMapping<Cidade>
    {
        public CidadeMapping() : base("tb_cidade")
        {

        }

        public override void Configure(EntityTypeBuilder<Cidade> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Nome).HasColumnName("nome").HasMaxLength(100).IsRequired();
            builder.Property(x => x.UF).HasColumnName("uf").HasMaxLength(2).IsRequired();
            builder.Property(x => x.Ativo).HasColumnName("ativo").IsRequired();
        }
    }
}
