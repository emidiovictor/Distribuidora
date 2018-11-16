using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace InfraData.Migrations
{
    public partial class t : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "produtos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    nome = table.Column<string>(type: "varchar", maxLength: 200, nullable: false),
                    descricao = table.Column<string>(type: "varchar", maxLength: 200, nullable: false),
                    custo = table.Column<decimal>(nullable: false),
                    preco_venda = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produtos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "regioes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    nome = table.Column<string>(nullable: true),
                    coordenada_x = table.Column<decimal>(nullable: false),
                    coordenada_y = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_regioes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Nome = table.Column<string>(type: "varchar", maxLength: 20, nullable: false),
                    Login = table.Column<string>(type: "varchar", maxLength: 20, nullable: false),
                    Senha = table.Column<string>(type: "varchar", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "armazem",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    nome = table.Column<string>(type: "varchar", maxLength: 200, nullable: true),
                    id_regiao = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_armazem", x => x.id);
                    table.ForeignKey(
                        name: "FK_armazem_regioes_id_regiao",
                        column: x => x.id_regiao,
                        principalTable: "regioes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "particiapntes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    id_regiao = table.Column<int>(nullable: false),
                    nome = table.Column<string>(type: "varchar", maxLength: 200, nullable: false),
                    endereco = table.Column<string>(type: "varchar", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_particiapntes", x => x.id);
                    table.ForeignKey(
                        name: "FK_particiapntes_regioes_id_regiao",
                        column: x => x.id_regiao,
                        principalTable: "regioes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "produto_armazem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    IdProduto = table.Column<int>(nullable: false),
                    IdArmazem = table.Column<int>(nullable: false),
                    quantidade = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produto_armazem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_produto_armazem_armazem_IdArmazem",
                        column: x => x.IdArmazem,
                        principalTable: "armazem",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_produto_armazem_produtos_IdProduto",
                        column: x => x.IdProduto,
                        principalTable: "produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "notas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    id_usuario = table.Column<int>(nullable: false),
                    id_particiapnte = table.Column<int>(nullable: false),
                    DataOperacao = table.Column<DateTime>(nullable: false),
                    tipo_nota = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_notas_particiapntes_id_particiapnte",
                        column: x => x.id_particiapnte,
                        principalTable: "particiapntes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_notas_usuarios_id_usuario",
                        column: x => x.id_usuario,
                        principalTable: "usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "item",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    id_produto = table.Column<int>(nullable: false),
                    id_nota = table.Column<int>(nullable: false),
                    quantidade = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_item_notas_id_nota",
                        column: x => x.id_nota,
                        principalTable: "notas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_item_produtos_id_produto",
                        column: x => x.id_produto,
                        principalTable: "produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_armazem_id_regiao",
                table: "armazem",
                column: "id_regiao");

            migrationBuilder.CreateIndex(
                name: "IX_item_id_nota",
                table: "item",
                column: "id_nota");

            migrationBuilder.CreateIndex(
                name: "IX_item_id_produto",
                table: "item",
                column: "id_produto");

            migrationBuilder.CreateIndex(
                name: "IX_notas_id_particiapnte",
                table: "notas",
                column: "id_particiapnte");

            migrationBuilder.CreateIndex(
                name: "IX_notas_id_usuario",
                table: "notas",
                column: "id_usuario");

            migrationBuilder.CreateIndex(
                name: "IX_particiapntes_id_regiao",
                table: "particiapntes",
                column: "id_regiao");

            migrationBuilder.CreateIndex(
                name: "IX_produto_armazem_IdArmazem",
                table: "produto_armazem",
                column: "IdArmazem");

            migrationBuilder.CreateIndex(
                name: "IX_produto_armazem_IdProduto",
                table: "produto_armazem",
                column: "IdProduto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "item");

            migrationBuilder.DropTable(
                name: "produto_armazem");

            migrationBuilder.DropTable(
                name: "notas");

            migrationBuilder.DropTable(
                name: "armazem");

            migrationBuilder.DropTable(
                name: "produtos");

            migrationBuilder.DropTable(
                name: "particiapntes");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "regioes");
        }
    }
}
