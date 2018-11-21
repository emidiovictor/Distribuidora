using Microsoft.EntityFrameworkCore.Migrations;

namespace InfraData.Migrations
{
    public partial class alteracaoDataOperacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "datetime",
                table: "notas",
                newName: "data_operacao");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "data_operacao",
                table: "notas",
                newName: "datetime");
        }
    }
}
