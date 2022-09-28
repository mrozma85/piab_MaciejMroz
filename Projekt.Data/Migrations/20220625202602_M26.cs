using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekt.Data.Migrations
{
    public partial class M26 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stopka",
                columns: table => new
                {
                    IdStopki = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaStopki = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stopka", x => x.IdStopki);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stopka");
        }
    }
}
