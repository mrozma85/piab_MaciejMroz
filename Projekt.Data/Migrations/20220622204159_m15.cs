using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekt.Data.Migrations
{
    public partial class m15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ElementUslugi_Oferta_OfertaIdOferty",
                table: "ElementUslugi");

            migrationBuilder.RenameColumn(
                name: "OfertaIdOferty",
                table: "ElementUslugi",
                newName: "RodzajTransportuIdRodzajuTransportu");

            migrationBuilder.RenameColumn(
                name: "IdOferty",
                table: "ElementUslugi",
                newName: "IdRodzajuTransportu");

            migrationBuilder.RenameIndex(
                name: "IX_ElementUslugi_OfertaIdOferty",
                table: "ElementUslugi",
                newName: "IX_ElementUslugi_RodzajTransportuIdRodzajuTransportu");

            migrationBuilder.AddForeignKey(
                name: "FK_ElementUslugi_RodzajTransportu_RodzajTransportuIdRodzajuTransportu",
                table: "ElementUslugi",
                column: "RodzajTransportuIdRodzajuTransportu",
                principalTable: "RodzajTransportu",
                principalColumn: "IdRodzajuTransportu",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ElementUslugi_RodzajTransportu_RodzajTransportuIdRodzajuTransportu",
                table: "ElementUslugi");

            migrationBuilder.RenameColumn(
                name: "RodzajTransportuIdRodzajuTransportu",
                table: "ElementUslugi",
                newName: "OfertaIdOferty");

            migrationBuilder.RenameColumn(
                name: "IdRodzajuTransportu",
                table: "ElementUslugi",
                newName: "IdOferty");

            migrationBuilder.RenameIndex(
                name: "IX_ElementUslugi_RodzajTransportuIdRodzajuTransportu",
                table: "ElementUslugi",
                newName: "IX_ElementUslugi_OfertaIdOferty");

            migrationBuilder.AddForeignKey(
                name: "FK_ElementUslugi_Oferta_OfertaIdOferty",
                table: "ElementUslugi",
                column: "OfertaIdOferty",
                principalTable: "Oferta",
                principalColumn: "IdOferty",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
