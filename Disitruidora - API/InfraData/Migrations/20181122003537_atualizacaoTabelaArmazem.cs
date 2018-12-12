using Microsoft.EntityFrameworkCore.Migrations;

namespace InfraData.Migrations
{
    public partial class atualizacaoTabelaArmazem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Armazem_regioes_id_regiao",
                table: "Armazem");

            migrationBuilder.DropForeignKey(
                name: "FK_produto_armazem_Armazem_id_armazem",
                table: "produto_armazem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Armazem",
                table: "Armazem");

            migrationBuilder.RenameTable(
                name: "Armazem",
                newName: "armazem");

            migrationBuilder.RenameIndex(
                name: "IX_Armazem_id_regiao",
                table: "armazem",
                newName: "IX_armazem_id_regiao");

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
                name: "FK_produto_armazem_armazem_id_armazem",
                table: "produto_armazem",
                column: "id_armazem",
                principalTable: "armazem",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_armazem_regioes_id_regiao",
                table: "armazem");

            migrationBuilder.DropForeignKey(
                name: "FK_produto_armazem_armazem_id_armazem",
                table: "produto_armazem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_armazem",
                table: "armazem");

            migrationBuilder.RenameTable(
                name: "armazem",
                newName: "Armazem");

            migrationBuilder.RenameIndex(
                name: "IX_armazem_id_regiao",
                table: "Armazem",
                newName: "IX_Armazem_id_regiao");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Armazem",
                table: "Armazem",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Armazem_regioes_id_regiao",
                table: "Armazem",
                column: "id_regiao",
                principalTable: "regioes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_produto_armazem_Armazem_id_armazem",
                table: "produto_armazem",
                column: "id_armazem",
                principalTable: "Armazem",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
