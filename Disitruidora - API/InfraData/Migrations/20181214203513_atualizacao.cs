using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace InfraData.Migrations
{
    public partial class atualizacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_armazem_regioes_id_regiao",
                "armazem");

            migrationBuilder.DropForeignKey(
                "FK_item_notas_id_nota",
                "item");

            migrationBuilder.DropForeignKey(
                "FK_item_produtos_id_produto",
                "item");

            migrationBuilder.DropForeignKey(
                "FK_notas_particiapntes_id_particiapnte",
                "notas");

            migrationBuilder.DropForeignKey(
                "FK_particiapntes_regioes_id_regiao",
                "particiapntes");

            migrationBuilder.DropForeignKey(
                "FK_produto_armazem_armazem_id_armazem",
                "produto_armazem");

            migrationBuilder.DropPrimaryKey(
                "PK_particiapntes",
                "particiapntes");

            migrationBuilder.DropPrimaryKey(
                "PK_item",
                "item");

            migrationBuilder.DropPrimaryKey(
                "PK_armazem",
                "armazem");

            migrationBuilder.DropColumn(
                "endereco",
                "particiapntes");

            migrationBuilder.RenameTable(
                "particiapntes",
                newName: "participantes");

            migrationBuilder.RenameTable(
                "item",
                newName: "item_nota");

            migrationBuilder.RenameTable(
                "armazem",
                newName: "armazens");

            migrationBuilder.RenameIndex(
                "IX_particiapntes_id_regiao",
                table: "participantes",
                newName: "IX_participantes_id_regiao");

            migrationBuilder.RenameIndex(
                "IX_item_id_produto",
                table: "item_nota",
                newName: "IX_item_nota_id_produto");

            migrationBuilder.RenameIndex(
                "IX_item_id_nota",
                table: "item_nota",
                newName: "IX_item_nota_id_nota");

            migrationBuilder.RenameIndex(
                "IX_armazem_id_regiao",
                table: "armazens",
                newName: "IX_armazens_id_regiao");

            migrationBuilder.AddColumn<int>(
                "id_endereco",
                "participantes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                "PK_participantes",
                "participantes",
                "id");

            migrationBuilder.AddPrimaryKey(
                "PK_item_nota",
                "item_nota",
                "Id");

            migrationBuilder.AddPrimaryKey(
                "PK_armazens",
                "armazens",
                "id");

            migrationBuilder.CreateTable(
                "enderecos",
                table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    cep = table.Column<string>("varchar", maxLength: 14, nullable: false),
                    cidade = table.Column<string>("varchar", maxLength: 100, nullable: false),
                    estado = table.Column<string>("varchar", maxLength: 100, nullable: false),
                    rua = table.Column<string>("varchar", maxLength: 200, nullable: false),
                    bairro = table.Column<string>("varchar", maxLength: 100, nullable: false),
                    numero = table.Column<string>("varchar", maxLength: 20, nullable: false),
                    complemento = table.Column<string>("varchar", maxLength: 100, nullable: false),
                    referencia = table.Column<string>("varchar", maxLength: 100, nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_enderecos", x => x.id); });

            migrationBuilder.CreateIndex(
                "IX_participantes_id_endereco",
                "participantes",
                "id_endereco");

            migrationBuilder.AddForeignKey(
                "FK_armazens_regioes_id_regiao",
                "armazens",
                "id_regiao",
                "regioes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                "FK_item_nota_notas_id_nota",
                "item_nota",
                "id_nota",
                "notas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                "FK_item_nota_produtos_id_produto",
                "item_nota",
                "id_produto",
                "produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                "FK_notas_participantes_id_particiapnte",
                "notas",
                "id_particiapnte",
                "participantes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                "FK_participantes_enderecos_id_endereco",
                "participantes",
                "id_endereco",
                "enderecos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                "FK_participantes_regioes_id_regiao",
                "participantes",
                "id_regiao",
                "regioes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                "FK_produto_armazem_armazens_id_armazem",
                "produto_armazem",
                "id_armazem",
                "armazens",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_armazens_regioes_id_regiao",
                "armazens");

            migrationBuilder.DropForeignKey(
                "FK_item_nota_notas_id_nota",
                "item_nota");

            migrationBuilder.DropForeignKey(
                "FK_item_nota_produtos_id_produto",
                "item_nota");

            migrationBuilder.DropForeignKey(
                "FK_notas_participantes_id_particiapnte",
                "notas");

            migrationBuilder.DropForeignKey(
                "FK_participantes_enderecos_id_endereco",
                "participantes");

            migrationBuilder.DropForeignKey(
                "FK_participantes_regioes_id_regiao",
                "participantes");

            migrationBuilder.DropForeignKey(
                "FK_produto_armazem_armazens_id_armazem",
                "produto_armazem");

            migrationBuilder.DropTable(
                "enderecos");

            migrationBuilder.DropPrimaryKey(
                "PK_participantes",
                "participantes");

            migrationBuilder.DropIndex(
                "IX_participantes_id_endereco",
                "participantes");

            migrationBuilder.DropPrimaryKey(
                "PK_item_nota",
                "item_nota");

            migrationBuilder.DropPrimaryKey(
                "PK_armazens",
                "armazens");

            migrationBuilder.DropColumn(
                "id_endereco",
                "participantes");

            migrationBuilder.RenameTable(
                "participantes",
                newName: "particiapntes");

            migrationBuilder.RenameTable(
                "item_nota",
                newName: "item");

            migrationBuilder.RenameTable(
                "armazens",
                newName: "armazem");

            migrationBuilder.RenameIndex(
                "IX_participantes_id_regiao",
                table: "particiapntes",
                newName: "IX_particiapntes_id_regiao");

            migrationBuilder.RenameIndex(
                "IX_item_nota_id_produto",
                table: "item",
                newName: "IX_item_id_produto");

            migrationBuilder.RenameIndex(
                "IX_item_nota_id_nota",
                table: "item",
                newName: "IX_item_id_nota");

            migrationBuilder.RenameIndex(
                "IX_armazens_id_regiao",
                table: "armazem",
                newName: "IX_armazem_id_regiao");

            migrationBuilder.AddColumn<string>(
                "endereco",
                "particiapntes",
                "varchar",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                "PK_particiapntes",
                "particiapntes",
                "id");

            migrationBuilder.AddPrimaryKey(
                "PK_item",
                "item",
                "Id");

            migrationBuilder.AddPrimaryKey(
                "PK_armazem",
                "armazem",
                "id");

            migrationBuilder.AddForeignKey(
                "FK_armazem_regioes_id_regiao",
                "armazem",
                "id_regiao",
                "regioes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                "FK_item_notas_id_nota",
                "item",
                "id_nota",
                "notas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                "FK_item_produtos_id_produto",
                "item",
                "id_produto",
                "produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                "FK_notas_particiapntes_id_particiapnte",
                "notas",
                "id_particiapnte",
                "particiapntes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                "FK_particiapntes_regioes_id_regiao",
                "particiapntes",
                "id_regiao",
                "regioes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                "FK_produto_armazem_armazem_id_armazem",
                "produto_armazem",
                "id_armazem",
                "armazem",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}