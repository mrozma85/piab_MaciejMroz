using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekt.Data.Migrations
{
    public partial class m9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Oferta",
                columns: table => new
                {
                    IdOferty = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oferta", x => x.IdOferty);
                });

            migrationBuilder.CreateTable(
                name: "RodzajTransportu",
                columns: table => new
                {
                    IdRodzajuTransportu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cena = table.Column<decimal>(type: "money", nullable: false),
                    IdOferty = table.Column<int>(type: "int", nullable: false),
                    OfertaIdOferty = table.Column<int>(type: "int", nullable: false),
                    PromocjaOferty = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RodzajTransportu", x => x.IdRodzajuTransportu);
                    table.ForeignKey(
                        name: "FK_RodzajTransportu_Oferta_OfertaIdOferty",
                        column: x => x.OfertaIdOferty,
                        principalTable: "Oferta",
                        principalColumn: "IdOferty",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RodzajTransportu_OfertaIdOferty",
                table: "RodzajTransportu",
                column: "OfertaIdOferty");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RodzajTransportu");

            migrationBuilder.DropTable(
                name: "Oferta");
        }
    }
}
