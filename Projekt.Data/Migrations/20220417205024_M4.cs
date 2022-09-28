using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekt.Data.Migrations
{
    public partial class M4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TrescCzymSieZajmujemy",
                table: "CzymSieZajmujemy",
                newName: "Tresc2CzymSieZajmujemy");

            migrationBuilder.AddColumn<string>(
                name: "Tresc1CzymSieZajmujemy",
                table: "CzymSieZajmujemy",
                type: "nvarchar(MAX)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tresc1CzymSieZajmujemy",
                table: "CzymSieZajmujemy");

            migrationBuilder.RenameColumn(
                name: "Tresc2CzymSieZajmujemy",
                table: "CzymSieZajmujemy",
                newName: "TrescCzymSieZajmujemy");
        }
    }
}
