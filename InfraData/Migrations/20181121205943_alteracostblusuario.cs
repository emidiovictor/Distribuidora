using Microsoft.EntityFrameworkCore.Migrations;

namespace InfraData.Migrations
{
    public partial class alteracostblusuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Login",
                table: "usuarios");

            migrationBuilder.RenameColumn(
                name: "Senha",
                table: "usuarios",
                newName: "senha");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "usuarios",
                newName: "nome");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "senha",
                table: "usuarios",
                newName: "Senha");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "usuarios",
                newName: "Nome");

            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "usuarios",
                type: "varchar",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }
    }
}
