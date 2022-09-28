using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekt.Data.Migrations
{
    public partial class M17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StronaGlowna",
                columns: table => new
                {
                    IdStronyGlownej = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tytul1StronyGlownej = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tytul2StronyGlownej = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StronaGlowna", x => x.IdStronyGlownej);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StronaGlowna");
        }
    }
}
