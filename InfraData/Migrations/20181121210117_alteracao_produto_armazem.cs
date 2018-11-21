using Microsoft.EntityFrameworkCore.Migrations;

namespace InfraData.Migrations
{
    public partial class alteracao_produto_armazem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_produto_armazem_armazem_IdArmazem",
                table: "produto_armazem");

            migrationBuilder.DropForeignKey(
                name: "FK_produto_armazem_produtos_IdProduto",
                table: "produto_armazem");

            migrationBuilder.RenameColumn(
                name: "IdProduto",
                table: "produto_armazem",
                newName: "id_produto");

            migrationBuilder.RenameColumn(
                name: "IdArmazem",
                table: "produto_armazem",
                newName: "id_armazem");

            migrationBuilder.RenameIndex(
                name: "IX_produto_armazem_IdProduto",
                table: "produto_armazem",
                newName: "IX_produto_armazem_id_produto");

            migrationBuilder.RenameIndex(
                name: "IX_produto_armazem_IdArmazem",
                table: "produto_armazem",
                newName: "IX_produto_armazem_id_armazem");

            migrationBuilder.AddForeignKey(
                name: "FK_produto_armazem_armazem_id_armazem",
                table: "produto_armazem",
                column: "id_armazem",
                principalTable: "armazem",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_produto_armazem_produtos_id_produto",
                table: "produto_armazem",
                column: "id_produto",
                principalTable: "produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_produto_armazem_armazem_id_armazem",
                table: "produto_armazem");

            migrationBuilder.DropForeignKey(
                name: "FK_produto_armazem_produtos_id_produto",
                table: "produto_armazem");

            migrationBuilder.RenameColumn(
                name: "id_produto",
                table: "produto_armazem",
                newName: "IdProduto");

            migrationBuilder.RenameColumn(
                name: "id_armazem",
                table: "produto_armazem",
                newName: "IdArmazem");

            migrationBuilder.RenameIndex(
                name: "IX_produto_armazem_id_produto",
                table: "produto_armazem",
                newName: "IX_produto_armazem_IdProduto");

            migrationBuilder.RenameIndex(
                name: "IX_produto_armazem_id_armazem",
                table: "produto_armazem",
                newName: "IX_produto_armazem_IdArmazem");

            migrationBuilder.AddForeignKey(
                name: "FK_produto_armazem_armazem_IdArmazem",
                table: "produto_armazem",
                column: "IdArmazem",
                principalTable: "armazem",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_produto_armazem_produtos_IdProduto",
                table: "produto_armazem",
                column: "IdProduto",
                principalTable: "produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
