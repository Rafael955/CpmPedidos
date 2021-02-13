﻿// <auto-generated />
using System;
using CpmPedidos.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CpmPedidos.Repository.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("CpmPedidos.Domain.CategoriaProduto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .UseIdentityByDefaultColumn();

                    b.Property<bool>("Ativo")
                        .HasColumnType("boolean")
                        .HasColumnName("ativo");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("criado_em");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.ToTable("tb_categoria_produto");
                });

            modelBuilder.Entity("CpmPedidos.Domain.Cidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .UseIdentityByDefaultColumn();

                    b.Property<bool>("Ativo")
                        .HasColumnType("boolean")
                        .HasColumnName("ativo");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("criado_em");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("nome");

                    b.Property<string>("UF")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("character varying(2)")
                        .HasColumnName("uf");

                    b.HasKey("Id");

                    b.ToTable("tb_cidade");
                });

            modelBuilder.Entity("CpmPedidos.Domain.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .UseIdentityByDefaultColumn();

                    b.Property<bool>("Ativo")
                        .HasColumnType("boolean")
                        .HasColumnName("ativo");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("character varying(11)")
                        .HasColumnName("cpf");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("criado_em");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("integer")
                        .HasColumnName("endereco_id");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId")
                        .IsUnique();

                    b.ToTable("tb_cliente");
                });

            modelBuilder.Entity("CpmPedidos.Domain.Combo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .UseIdentityByDefaultColumn();

                    b.Property<bool>("Ativo")
                        .HasColumnType("boolean")
                        .HasColumnName("ativo");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("criado_em");

                    b.Property<int>("ImagemId")
                        .HasColumnType("integer")
                        .HasColumnName("imagem_id");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("nome");

                    b.Property<decimal>("Preco")
                        .HasPrecision(17, 2)
                        .HasColumnType("numeric(17,2)")
                        .HasColumnName("preco");

                    b.HasKey("Id");

                    b.HasIndex("ImagemId");

                    b.ToTable("tb_combo");
                });

            modelBuilder.Entity("CpmPedidos.Domain.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("bairro");

                    b.Property<string>("Cep")
                        .HasMaxLength(8)
                        .HasColumnType("character varying(8)")
                        .HasColumnName("cep");

                    b.Property<int>("CidadeId")
                        .HasColumnType("integer")
                        .HasColumnName("cidade_id");

                    b.Property<string>("Complemento")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("complemento");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("criado_em");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("logradouro");

                    b.Property<string>("Numero")
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("numero");

                    b.Property<byte>("Tipo")
                        .HasColumnType("smallint")
                        .HasColumnName("tipo");

                    b.HasKey("Id");

                    b.HasIndex("CidadeId");

                    b.ToTable("tb_endereco");
                });

            modelBuilder.Entity("CpmPedidos.Domain.Imagem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .UseIdentityByDefaultColumn();

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("criado_em");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("nome");

                    b.Property<string>("NomeArquivo")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("nome_arquivo");

                    b.Property<bool>("Principal")
                        .HasColumnType("boolean")
                        .HasColumnName("principal");

                    b.HasKey("Id");

                    b.ToTable("tb_imagem");
                });

            modelBuilder.Entity("CpmPedidos.Domain.ImagemProduto", b =>
                {
                    b.Property<int>("ImagemId")
                        .HasColumnType("integer")
                        .HasColumnName("imagem_id");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("integer")
                        .HasColumnName("produto_id");

                    b.HasKey("ImagemId", "ProdutoId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("tb_imagem_produto");
                });

            modelBuilder.Entity("CpmPedidos.Domain.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .UseIdentityByDefaultColumn();

                    b.Property<int>("ClienteId")
                        .HasColumnType("integer")
                        .HasColumnName("cliente_id");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("criado_em");

                    b.Property<TimeSpan>("Entrega")
                        .HasColumnType("interval")
                        .HasColumnName("entrega");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("numero");

                    b.Property<decimal>("ValorTotal")
                        .HasPrecision(17, 2)
                        .HasColumnType("numeric(17,2)")
                        .HasColumnName("valor_total");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("tb_pedido");
                });

            modelBuilder.Entity("CpmPedidos.Domain.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .UseIdentityByDefaultColumn();

                    b.Property<bool>("Ativo")
                        .HasColumnType("boolean")
                        .HasColumnName("ativo");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("integer")
                        .HasColumnName("categoria_id");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("codigo");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("criado_em");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasPrecision(17, 2)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("preco");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("nome");

                    b.Property<decimal>("Preco")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("tb_produto");
                });

            modelBuilder.Entity("CpmPedidos.Domain.ProdutoCombo", b =>
                {
                    b.Property<int>("ProdutoId")
                        .HasColumnType("integer")
                        .HasColumnName("produto_id");

                    b.Property<int>("ComboId")
                        .HasColumnType("integer")
                        .HasColumnName("combo_id");

                    b.HasKey("ProdutoId", "ComboId");

                    b.HasIndex("ComboId");

                    b.ToTable("tb_produto_combo");
                });

            modelBuilder.Entity("CpmPedidos.Domain.ProdutoPedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .UseIdentityByDefaultColumn();

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("criado_em");

                    b.Property<int>("PedidoId")
                        .HasColumnType("integer")
                        .HasColumnName("pedido_id");

                    b.Property<decimal>("Preco")
                        .HasPrecision(17, 2)
                        .HasColumnType("numeric(17,2)")
                        .HasColumnName("preco");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("integer")
                        .HasColumnName("produto_id");

                    b.Property<int>("Quantidade")
                        .HasPrecision(2)
                        .HasColumnType("integer")
                        .HasColumnName("quantidade");

                    b.HasKey("Id");

                    b.HasIndex("PedidoId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("tb_produto_pedido");
                });

            modelBuilder.Entity("CpmPedidos.Domain.PromocaoProduto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .UseIdentityByDefaultColumn();

                    b.Property<bool>("Ativo")
                        .HasColumnType("boolean")
                        .HasColumnName("ativo");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("criado_em");

                    b.Property<int>("ImagemId")
                        .HasColumnType("integer")
                        .HasColumnName("imagem_id");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("nome");

                    b.Property<decimal>("Preco")
                        .HasPrecision(17, 2)
                        .HasColumnType("numeric(17,2)")
                        .HasColumnName("preco");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("integer")
                        .HasColumnName("produto_id");

                    b.HasKey("Id");

                    b.HasIndex("ImagemId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("tb_promocao_produto");
                });

            modelBuilder.Entity("CpmPedidos.Domain.Cliente", b =>
                {
                    b.HasOne("CpmPedidos.Domain.Endereco", "Endereco")
                        .WithOne("Cliente")
                        .HasForeignKey("CpmPedidos.Domain.Cliente", "EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("CpmPedidos.Domain.Combo", b =>
                {
                    b.HasOne("CpmPedidos.Domain.Imagem", "Imagem")
                        .WithMany()
                        .HasForeignKey("ImagemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Imagem");
                });

            modelBuilder.Entity("CpmPedidos.Domain.Endereco", b =>
                {
                    b.HasOne("CpmPedidos.Domain.Cidade", "Cidade")
                        .WithMany()
                        .HasForeignKey("CidadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cidade");
                });

            modelBuilder.Entity("CpmPedidos.Domain.ImagemProduto", b =>
                {
                    b.HasOne("CpmPedidos.Domain.Imagem", "Imagem")
                        .WithMany()
                        .HasForeignKey("ImagemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CpmPedidos.Domain.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Imagem");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("CpmPedidos.Domain.Pedido", b =>
                {
                    b.HasOne("CpmPedidos.Domain.Cliente", "Cliente")
                        .WithMany("Pedidos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("CpmPedidos.Domain.Produto", b =>
                {
                    b.HasOne("CpmPedidos.Domain.CategoriaProduto", "Categoria")
                        .WithMany("Produtos")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("CpmPedidos.Domain.ProdutoCombo", b =>
                {
                    b.HasOne("CpmPedidos.Domain.Combo", "Combo")
                        .WithMany()
                        .HasForeignKey("ComboId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CpmPedidos.Domain.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Combo");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("CpmPedidos.Domain.ProdutoPedido", b =>
                {
                    b.HasOne("CpmPedidos.Domain.Pedido", "Pedido")
                        .WithMany("Produtos")
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CpmPedidos.Domain.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pedido");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("CpmPedidos.Domain.PromocaoProduto", b =>
                {
                    b.HasOne("CpmPedidos.Domain.Imagem", "Imagem")
                        .WithMany()
                        .HasForeignKey("ImagemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CpmPedidos.Domain.Produto", "Produto")
                        .WithMany("Promocoes")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Imagem");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("CpmPedidos.Domain.CategoriaProduto", b =>
                {
                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("CpmPedidos.Domain.Cliente", b =>
                {
                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("CpmPedidos.Domain.Endereco", b =>
                {
                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("CpmPedidos.Domain.Pedido", b =>
                {
                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("CpmPedidos.Domain.Produto", b =>
                {
                    b.Navigation("Promocoes");
                });
#pragma warning restore 612, 618
        }
    }
}
