using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekt.Data.Migrations
{
    public partial class M1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nawigacja",
                columns: table => new
                {
                    IdNawigacji = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LinkNawigacji = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TytulNawigacji = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrescNawigacji = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Pozycja = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nawigacja", x => x.IdNawigacji);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nawigacja");
        }
    }
}
