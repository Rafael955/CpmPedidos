using CpmPedidos.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CpmPedidos.Repository
{
    public class ClienteMapping : BaseDomainMapping<Cliente>
    {
        public ClienteMapping() : base("tb_cliente")
        {

        }

        public override void Configure(EntityTypeBuilder<Cliente> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Nome).HasColumnName("nome").HasMaxLength(100).IsRequired();
            builder.Property(x => x.CPF).HasColumnName("cpf").HasMaxLength(11).IsRequired();
            builder.Property(x => x.Ativo).HasColumnName("ativo").IsRequired();

            builder.Property(x => x.EnderecoId).HasColumnName("endereco_id").IsRequired();
            builder.HasOne(x => x.Endereco).WithOne(x => x.Cliente).HasForeignKey<Endereco>(x => x.ClienteId);
        }
    }


}
