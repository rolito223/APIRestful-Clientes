using Microsoft.EntityFrameworkCore.Migrations;

namespace APIRestful_Clientes.Migrations
{
    public partial class CLinte : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostCode",
                table: "Clientes");

            migrationBuilder.RenameColumn(
                name: "Lastname",
                table: "Clientes",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "Clientes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Clientes");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Clientes",
                newName: "Lastname");

            migrationBuilder.AddColumn<string>(
                name: "PostCode",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
