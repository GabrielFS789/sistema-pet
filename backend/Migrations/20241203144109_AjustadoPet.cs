using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class AjustadoPet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fratura",
                table: "Pet");

            migrationBuilder.DropColumn(
                name: "Medo",
                table: "Pet");

            migrationBuilder.DropColumn(
                name: "PossuiFratura",
                table: "Pet");

            migrationBuilder.DropColumn(
                name: "PossuiMedo",
                table: "Pet");

            migrationBuilder.AddColumn<string>(
                name: "Fraturas",
                table: "Pet",
                type: "jsonb",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Medos",
                table: "Pet",
                type: "jsonb",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fraturas",
                table: "Pet");

            migrationBuilder.DropColumn(
                name: "Medos",
                table: "Pet");

            migrationBuilder.AddColumn<string>(
                name: "Fratura",
                table: "Pet",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Medo",
                table: "Pet",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PossuiFratura",
                table: "Pet",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PossuiMedo",
                table: "Pet",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
