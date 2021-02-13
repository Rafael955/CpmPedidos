using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CpmPedidos.Repository.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_categoria_produto",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ativo = table.Column<bool>(type: "boolean", nullable: false),
                    criado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_categoria_produto", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_cidade",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    uf = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    ativo = table.Column<bool>(type: "boolean", nullable: false),
                    criado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_cidade", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_imagem",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    nome_arquivo = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    principal = table.Column<bool>(type: "boolean", nullable: false),
                    criado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_imagem", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_produto",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    codigo = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    preco = table.Column<string>(type: "character varying(50)", maxLength: 50, precision: 17, scale: 2, nullable: false),
                    Preco = table.Column<decimal>(type: "numeric", nullable: false),
                    categoria_id = table.Column<int>(type: "integer", nullable: false),
                    ativo = table.Column<bool>(type: "boolean", nullable: false),
                    criado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_produto", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_produto_tb_categoria_produto_categoria_id",
                        column: x => x.categoria_id,
                        principalTable: "tb_categoria_produto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_endereco",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tipo = table.Column<byte>(type: "smallint", nullable: false),
                    logradouro = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    bairro = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    numero = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    complemento = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    cep = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: true),
                    cidade_id = table.Column<int>(type: "integer", nullable: false),
                    criado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_endereco", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_endereco_tb_cidade_cidade_id",
                        column: x => x.cidade_id,
                        principalTable: "tb_cidade",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_combo",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    preco = table.Column<decimal>(type: "numeric(17,2)", precision: 17, scale: 2, nullable: false),
                    imagem_id = table.Column<int>(type: "integer", nullable: false),
                    ativo = table.Column<bool>(type: "boolean", nullable: false),
                    criado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_combo", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_combo_tb_imagem_imagem_id",
                        column: x => x.imagem_id,
                        principalTable: "tb_imagem",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_imagem_produto",
                columns: table => new
                {
                    imagem_id = table.Column<int>(type: "integer", nullable: false),
                    produto_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_imagem_produto", x => new { x.imagem_id, x.produto_id });
                    table.ForeignKey(
                        name: "FK_tb_imagem_produto_tb_imagem_imagem_id",
                        column: x => x.imagem_id,
                        principalTable: "tb_imagem",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_imagem_produto_tb_produto_produto_id",
                        column: x => x.produto_id,
                        principalTable: "tb_produto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_promocao_produto",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    preco = table.Column<decimal>(type: "numeric(17,2)", precision: 17, scale: 2, nullable: false),
                    imagem_id = table.Column<int>(type: "integer", nullable: false),
                    produto_id = table.Column<int>(type: "integer", nullable: false),
                    ativo = table.Column<bool>(type: "boolean", nullable: false),
                    criado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_promocao_produto", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_promocao_produto_tb_imagem_imagem_id",
                        column: x => x.imagem_id,
                        principalTable: "tb_imagem",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_promocao_produto_tb_produto_produto_id",
                        column: x => x.produto_id,
                        principalTable: "tb_produto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_cliente",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    cpf = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    ativo = table.Column<bool>(type: "boolean", nullable: false),
                    endereco_id = table.Column<int>(type: "integer", nullable: false),
                    criado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_cliente", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_cliente_tb_endereco_endereco_id",
                        column: x => x.endereco_id,
                        principalTable: "tb_endereco",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_produto_combo",
                columns: table => new
                {
                    produto_id = table.Column<int>(type: "integer", nullable: false),
                    combo_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_produto_combo", x => new { x.produto_id, x.combo_id });
                    table.ForeignKey(
                        name: "FK_tb_produto_combo_tb_combo_combo_id",
                        column: x => x.combo_id,
                        principalTable: "tb_combo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_produto_combo_tb_produto_produto_id",
                        column: x => x.produto_id,
                        principalTable: "tb_produto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_pedido",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    numero = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    valor_total = table.Column<decimal>(type: "numeric(17,2)", precision: 17, scale: 2, nullable: false),
                    entrega = table.Column<TimeSpan>(type: "interval", nullable: false),
                    cliente_id = table.Column<int>(type: "integer", nullable: false),
                    criado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_pedido", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_pedido_tb_cliente_cliente_id",
                        column: x => x.cliente_id,
                        principalTable: "tb_cliente",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_produto_pedido",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    quantidade = table.Column<int>(type: "integer", precision: 2, nullable: false),
                    preco = table.Column<decimal>(type: "numeric(17,2)", precision: 17, scale: 2, nullable: false),
                    produto_id = table.Column<int>(type: "integer", nullable: false),
                    pedido_id = table.Column<int>(type: "integer", nullable: false),
                    criado_em = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_produto_pedido", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_produto_pedido_tb_pedido_pedido_id",
                        column: x => x.pedido_id,
                        principalTable: "tb_pedido",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_produto_pedido_tb_produto_produto_id",
                        column: x => x.produto_id,
                        principalTable: "tb_produto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_cliente_endereco_id",
                table: "tb_cliente",
                column: "endereco_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_combo_imagem_id",
                table: "tb_combo",
                column: "imagem_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_endereco_cidade_id",
                table: "tb_endereco",
                column: "cidade_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_imagem_produto_produto_id",
                table: "tb_imagem_produto",
                column: "produto_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_pedido_cliente_id",
                table: "tb_pedido",
                column: "cliente_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_produto_categoria_id",
                table: "tb_produto",
                column: "categoria_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_produto_combo_combo_id",
                table: "tb_produto_combo",
                column: "combo_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_produto_pedido_pedido_id",
                table: "tb_produto_pedido",
                column: "pedido_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_produto_pedido_produto_id",
                table: "tb_produto_pedido",
                column: "produto_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_promocao_produto_imagem_id",
                table: "tb_promocao_produto",
                column: "imagem_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_promocao_produto_produto_id",
                table: "tb_promocao_produto",
                column: "produto_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_imagem_produto");

            migrationBuilder.DropTable(
                name: "tb_produto_combo");

            migrationBuilder.DropTable(
                name: "tb_produto_pedido");

            migrationBuilder.DropTable(
                name: "tb_promocao_produto");

            migrationBuilder.DropTable(
                name: "tb_combo");

            migrationBuilder.DropTable(
                name: "tb_pedido");

            migrationBuilder.DropTable(
                name: "tb_produto");

            migrationBuilder.DropTable(
                name: "tb_imagem");

            migrationBuilder.DropTable(
                name: "tb_cliente");

            migrationBuilder.DropTable(
                name: "tb_categoria_produto");

            migrationBuilder.DropTable(
                name: "tb_endereco");

            migrationBuilder.DropTable(
                name: "tb_cidade");
        }
    }
}
