using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekt.Data.Migrations
{
    public partial class M5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kontakt",
                columns: table => new
                {
                    IdKontaktu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrescKontaktu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pozycja = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kontakt", x => x.IdKontaktu);
                });

            migrationBuilder.CreateTable(
                name: "Opinie",
                columns: table => new
                {
                    IdOpini = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LinkOpini = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImieINazwiskoDodajacego = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrescOpini = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Pozycja = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opinie", x => x.IdOpini);
                });

            migrationBuilder.CreateTable(
                name: "PytaniaIOdpowiedzi",
                columns: table => new
                {
                    IdPytaniaIOdpowiedzi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LinkPytaniaIOdpowiedzi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TytulPytaniaIOdpowiedzi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrescPytaniaIOdpowiedzi = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Pozycja = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PytaniaIOdpowiedzi", x => x.IdPytaniaIOdpowiedzi);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kontakt");

            migrationBuilder.DropTable(
                name: "Opinie");

            migrationBuilder.DropTable(
                name: "PytaniaIOdpowiedzi");
        }
    }
}
