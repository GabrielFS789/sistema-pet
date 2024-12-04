using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class AdicionaPerfilPrincipal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO public.\"Permissao\"\r\n(\"Id\", \"Nome\", \"CriaUsuario\", \"AlteraUsuario\", \"ExcluirUsuario\", \"ListarUsuarios\")\r\nVALUES(1, 'Perfil Principal', true, true, true, true);");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
