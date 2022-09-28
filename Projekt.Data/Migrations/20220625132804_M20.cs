using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekt.Data.Migrations
{
    public partial class M20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TrescPytaniaIOdpowiedzi",
                table: "PytaniaIOdpowiedzi",
                type: "nvarchar(MAX)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(MAX)");

            migrationBuilder.AlterColumn<string>(
                name: "TrescOpini",
                table: "Opinie",
                type: "nvarchar(MAX)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(MAX)");

            migrationBuilder.AlterColumn<string>(
                name: "Naglowek2Opini",
                table: "Opinie",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Naglowek1Opini",
                table: "Opinie",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TrescPytaniaIOdpowiedzi",
                table: "PytaniaIOdpowiedzi",
                type: "nvarchar(MAX)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(MAX)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TrescOpini",
                table: "Opinie",
                type: "nvarchar(MAX)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(MAX)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Naglowek2Opini",
                table: "Opinie",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Naglowek1Opini",
                table: "Opinie",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
