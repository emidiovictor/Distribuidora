using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace InfraData.Migrations
{
    public partial class AddingEnderecos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_armazem_regioes_id_regiao",
                table: "armazem");

            migrationBuilder.DropForeignKey(
                name: "FK_item_notas_id_nota",
                table: "item");

            migrationBuilder.DropForeignKey(
                name: "FK_item_produtos_id_produto",
                table: "item");

            migrationBuilder.DropForeignKey(
                name: "FK_notas_particiapntes_id_particiapnte",
                table: "notas");

            migrationBuilder.DropForeignKey(
                name: "FK_particiapntes_regioes_id_regiao",
                table: "particiapntes");

            migrationBuilder.DropForeignKey(
                name: "FK_produto_armazem_armazem_id_armazem",
                table: "produto_armazem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_particiapntes",
                table: "particiapntes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_item",
                table: "item");

            migrationBuilder.DropPrimaryKey(
                name: "PK_armazem",
                table: "armazem");

            migrationBuilder.DropColumn(
                name: "endereco",
                table: "particiapntes");

            migrationBuilder.RenameTable(
                name: "particiapntes",
                newName: "participantes");

            migrationBuilder.RenameTable(
                name: "item",
                newName: "item_nota");

            migrationBuilder.RenameTable(
                name: "armazem",
                newName: "armazens");

            migrationBuilder.RenameIndex(
                name: "IX_particiapntes_id_regiao",
                table: "participantes",
                newName: "IX_participantes_id_regiao");

            migrationBuilder.RenameIndex(
                name: "IX_item_id_produto",
                table: "item_nota",
                newName: "IX_item_nota_id_produto");

            migrationBuilder.RenameIndex(
                name: "IX_item_id_nota",
                table: "item_nota",
                newName: "IX_item_nota_id_nota");

            migrationBuilder.RenameIndex(
                name: "IX_armazem_id_regiao",
                table: "armazens",
                newName: "IX_armazens_id_regiao");

            migrationBuilder.AddColumn<int>(
                name: "id_endereco",
                table: "participantes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_participantes",
                table: "participantes",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_item_nota",
                table: "item_nota",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_armazens",
                table: "armazens",
                column: "id");

            migrationBuilder.CreateTable(
                name: "enderecos",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    cep = table.Column<string>(type: "varchar", maxLength: 14, nullable: false),
                    cidade = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    estado = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    rua = table.Column<string>(type: "varchar", maxLength: 200, nullable: false),
                    bairro = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    numero = table.Column<string>(type: "varchar", maxLength: 20, nullable: false),
                    complemento = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    referencia = table.Column<string>(type: "varchar", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_enderecos", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_participantes_id_endereco",
                table: "participantes",
                column: "id_endereco");

            migrationBuilder.AddForeignKey(
                name: "FK_armazens_regioes_id_regiao",
                table: "armazens",
                column: "id_regiao",
                principalTable: "regioes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_item_nota_notas_id_nota",
                table: "item_nota",
                column: "id_nota",
                principalTable: "notas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_item_nota_produtos_id_produto",
                table: "item_nota",
                column: "id_produto",
                principalTable: "produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_notas_participantes_id_particiapnte",
                table: "notas",
                column: "id_particiapnte",
                principalTable: "participantes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_participantes_enderecos_id_endereco",
                table: "participantes",
                column: "id_endereco",
                principalTable: "enderecos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_participantes_regioes_id_regiao",
                table: "participantes",
                column: "id_regiao",
                principalTable: "regioes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_produto_armazem_armazens_id_armazem",
                table: "produto_armazem",
                column: "id_armazem",
                principalTable: "armazens",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_armazens_regioes_id_regiao",
                table: "armazens");

            migrationBuilder.DropForeignKey(
                name: "FK_item_nota_notas_id_nota",
                table: "item_nota");

            migrationBuilder.DropForeignKey(
                name: "FK_item_nota_produtos_id_produto",
                table: "item_nota");

            migrationBuilder.DropForeignKey(
                name: "FK_notas_participantes_id_particiapnte",
                table: "notas");

            migrationBuilder.DropForeignKey(
                name: "FK_participantes_enderecos_id_endereco",
                table: "participantes");

            migrationBuilder.DropForeignKey(
                name: "FK_participantes_regioes_id_regiao",
                table: "participantes");

            migrationBuilder.DropForeignKey(
                name: "FK_produto_armazem_armazens_id_armazem",
                table: "produto_armazem");

            migrationBuilder.DropTable(
                name: "enderecos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_participantes",
                table: "participantes");

            migrationBuilder.DropIndex(
                name: "IX_participantes_id_endereco",
                table: "participantes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_item_nota",
                table: "item_nota");

            migrationBuilder.DropPrimaryKey(
                name: "PK_armazens",
                table: "armazens");

            migrationBuilder.DropColumn(
                name: "id_endereco",
                table: "participantes");

            migrationBuilder.RenameTable(
                name: "participantes",
                newName: "particiapntes");

            migrationBuilder.RenameTable(
                name: "item_nota",
                newName: "item");

            migrationBuilder.RenameTable(
                name: "armazens",
                newName: "armazem");

            migrationBuilder.RenameIndex(
                name: "IX_participantes_id_regiao",
                table: "particiapntes",
                newName: "IX_particiapntes_id_regiao");

            migrationBuilder.RenameIndex(
                name: "IX_item_nota_id_produto",
                table: "item",
                newName: "IX_item_id_produto");

            migrationBuilder.RenameIndex(
                name: "IX_item_nota_id_nota",
                table: "item",
                newName: "IX_item_id_nota");

            migrationBuilder.RenameIndex(
                name: "IX_armazens_id_regiao",
                table: "armazem",
                newName: "IX_armazem_id_regiao");

            migrationBuilder.AddColumn<string>(
                name: "endereco",
                table: "particiapntes",
                type: "varchar",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_particiapntes",
                table: "particiapntes",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_item",
                table: "item",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_armazem",
                table: "armazem",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_armazem_regioes_id_regiao",
                table: "armazem",
                column: "id_regiao",
                principalTable: "regioes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_item_notas_id_nota",
                table: "item",
                column: "id_nota",
                principalTable: "notas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_item_produtos_id_produto",
                table: "item",
                column: "id_produto",
                principalTable: "produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_notas_particiapntes_id_particiapnte",
                table: "notas",
                column: "id_particiapnte",
                principalTable: "particiapntes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_particiapntes_regioes_id_regiao",
                table: "particiapntes",
                column: "id_regiao",
                principalTable: "regioes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_produto_armazem_armazem_id_armazem",
                table: "produto_armazem",
                column: "id_armazem",
                principalTable: "armazem",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
