using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekt.Data.Migrations
{
    public partial class M18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TytulGlownyPytaniaIOdpowiedzi",
                table: "PytaniaIOdpowiedzi",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TytulGlownyPytaniaIOdpowiedzi",
                table: "PytaniaIOdpowiedzi");
        }
    }
}
