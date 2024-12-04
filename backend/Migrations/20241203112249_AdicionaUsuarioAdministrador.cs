using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class AdicionaUsuarioAdministrador : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO public.\"Usuario\"\r\n(\"Id\", \"Nome\", \"Email\", \"Password\", \"Inativo\", \"PermissaoId\", \"DataHoraCadastro\", \"DataHoraUltimaAtualizacao\", \"Administrador\")\r\nVALUES(1, 'admin', 'admin@admin.com', '$2a$11$Ns4lCqTvS6Vqk.Nl9iB5UuTlAQoIneRvw6sC0bihHUgIRGQ/Syr6C', false, 1, '2024-12-01 00:00:00.000', NULL, true);");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
