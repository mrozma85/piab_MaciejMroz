using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekt.Data.Migrations
{
    public partial class m23 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RodzajTransportu_Oferta_OfertaIdOferty",
                table: "RodzajTransportu");

            migrationBuilder.AlterColumn<int>(
                name: "OfertaIdOferty",
                table: "RodzajTransportu",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_RodzajTransportu_Oferta_OfertaIdOferty",
                table: "RodzajTransportu",
                column: "OfertaIdOferty",
                principalTable: "Oferta",
                principalColumn: "IdOferty");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RodzajTransportu_Oferta_OfertaIdOferty",
                table: "RodzajTransportu");

            migrationBuilder.AlterColumn<int>(
                name: "OfertaIdOferty",
                table: "RodzajTransportu",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RodzajTransportu_Oferta_OfertaIdOferty",
                table: "RodzajTransportu",
                column: "OfertaIdOferty",
                principalTable: "Oferta",
                principalColumn: "IdOferty",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
