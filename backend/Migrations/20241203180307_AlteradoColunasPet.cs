using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class AlteradoColunasPet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CachorroSexo",
                table: "Pet",
                newName: "PetSexo");

            migrationBuilder.RenameColumn(
                name: "CachorroNome",
                table: "Pet",
                newName: "PetNome");

            migrationBuilder.RenameColumn(
                name: "CachorroNascimento",
                table: "Pet",
                newName: "PetNascimento");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PetSexo",
                table: "Pet",
                newName: "CachorroSexo");

            migrationBuilder.RenameColumn(
                name: "PetNome",
                table: "Pet",
                newName: "CachorroNome");

            migrationBuilder.RenameColumn(
                name: "PetNascimento",
                table: "Pet",
                newName: "CachorroNascimento");
        }
    }
}
