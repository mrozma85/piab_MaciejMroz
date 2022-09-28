using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekt.Data.Migrations
{
    public partial class M11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ElementUslugi",
                columns: table => new
                {
                    IdElementuUslugi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSesjiKoszyka = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdOferty = table.Column<int>(type: "int", nullable: false),
                    OfertaIdOferty = table.Column<int>(type: "int", nullable: false),
                    Ilosc = table.Column<int>(type: "int", nullable: false),
                    DataUtworzenia = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElementUslugi", x => x.IdElementuUslugi);
                    table.ForeignKey(
                        name: "FK_ElementUslugi_Oferta_OfertaIdOferty",
                        column: x => x.OfertaIdOferty,
                        principalTable: "Oferta",
                        principalColumn: "IdOferty",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ElementUslugi_OfertaIdOferty",
                table: "ElementUslugi",
                column: "OfertaIdOferty");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ElementUslugi");
        }
    }
}
