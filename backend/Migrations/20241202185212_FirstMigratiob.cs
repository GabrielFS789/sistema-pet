using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigratiob : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Permissao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    CriaUsuario = table.Column<bool>(type: "boolean", nullable: false),
                    AlteraUsuario = table.Column<bool>(type: "boolean", nullable: false),
                    ExcluirUsuario = table.Column<bool>(type: "boolean", nullable: false),
                    ListarUsuarios = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Raca",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Inativo = table.Column<bool>(type: "boolean", nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataHoraUltimaAtualizacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Raca", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Inativo = table.Column<bool>(type: "boolean", nullable: false),
                    PermissaoId = table.Column<int>(type: "integer", nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataHoraUltimaAtualizacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Administrador = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Permissao_PermissaoId",
                        column: x => x.PermissaoId,
                        principalTable: "Permissao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DonoEndereco = table.Column<string>(type: "text", nullable: false),
                    DonoNumeroEndereco = table.Column<string>(type: "text", nullable: true),
                    DonoComplemento = table.Column<string>(type: "text", nullable: true),
                    DonoTelefone = table.Column<string>(type: "text", nullable: false),
                    Inativo = table.Column<bool>(type: "boolean", nullable: false),
                    DonoNome = table.Column<string>(type: "text", nullable: false),
                    CachorroNome = table.Column<string>(type: "text", nullable: false),
                    CachorroSexo = table.Column<string>(type: "text", nullable: false),
                    CachorroNascimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RacaId = table.Column<int>(type: "integer", nullable: false),
                    PossuiDoenca = table.Column<bool>(type: "boolean", nullable: false),
                    Doencas = table.Column<string>(type: "jsonb", nullable: true),
                    PossuiFratura = table.Column<bool>(type: "boolean", nullable: false),
                    Fratura = table.Column<string>(type: "text", nullable: true),
                    PossuiMedo = table.Column<bool>(type: "boolean", nullable: false),
                    Medo = table.Column<string>(type: "text", nullable: true),
                    Gestante = table.Column<bool>(type: "boolean", nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataHoraUltimaAtualizacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pet_Raca_RacaId",
                        column: x => x.RacaId,
                        principalTable: "Raca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pet_RacaId",
                table: "Pet",
                column: "RacaId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_PermissaoId",
                table: "Usuario",
                column: "PermissaoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pet");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Raca");

            migrationBuilder.DropTable(
                name: "Permissao");
        }
    }
}
