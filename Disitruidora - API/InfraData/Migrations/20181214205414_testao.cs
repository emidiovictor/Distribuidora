using Microsoft.EntityFrameworkCore.Migrations;

namespace InfraData.Migrations
{
    public partial class testao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "nome",
                table: "usuarios",
                type: "varchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 20);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "nome",
                table: "usuarios",
                type: "varchar",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldMaxLength: 20);
        }
    }
}
