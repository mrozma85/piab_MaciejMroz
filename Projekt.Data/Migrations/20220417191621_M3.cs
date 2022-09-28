using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekt.Data.Migrations
{
    public partial class M3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CzymSieZajmujemy",
                columns: table => new
                {
                    IdCzymSieZajmujemy = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LinkCzymSieZajmujemy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TytulCzymSieZajmujemy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrescCzymSieZajmujemy = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Pozycja = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CzymSieZajmujemy", x => x.IdCzymSieZajmujemy);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CzymSieZajmujemy");
        }
    }
}
