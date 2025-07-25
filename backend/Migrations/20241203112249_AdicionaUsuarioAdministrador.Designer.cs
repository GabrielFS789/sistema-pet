﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using backend.AppDbContext;

#nullable disable

namespace backend.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241203112249_AdicionaUsuarioAdministrador")]
    partial class AdicionaUsuarioAdministrador
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("backend.Models.Permissao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("AlteraUsuario")
                        .HasColumnType("boolean");

                    b.Property<bool>("CriaUsuario")
                        .HasColumnType("boolean");

                    b.Property<bool>("ExcluirUsuario")
                        .HasColumnType("boolean");

                    b.Property<bool>("ListarUsuarios")
                        .HasColumnType("boolean");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Permissao");
                });

            modelBuilder.Entity("backend.Models.Pet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CachorroNascimento")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CachorroNome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CachorroSexo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DataHoraCadastro")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataHoraUltimaAtualizacao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Doencas")
                        .HasColumnType("jsonb");

                    b.Property<string>("DonoComplemento")
                        .HasColumnType("text");

                    b.Property<string>("DonoEndereco")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DonoNome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DonoNumeroEndereco")
                        .HasColumnType("text");

                    b.Property<string>("DonoTelefone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Fratura")
                        .HasColumnType("text");

                    b.Property<bool>("Gestante")
                        .HasColumnType("boolean");

                    b.Property<bool>("Inativo")
                        .HasColumnType("boolean");

                    b.Property<string>("Medo")
                        .HasColumnType("text");

                    b.Property<bool>("PossuiDoenca")
                        .HasColumnType("boolean");

                    b.Property<bool>("PossuiFratura")
                        .HasColumnType("boolean");

                    b.Property<bool>("PossuiMedo")
                        .HasColumnType("boolean");

                    b.Property<int>("RacaId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RacaId");

                    b.ToTable("Pet");
                });

            modelBuilder.Entity("backend.Models.Raca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataHoraCadastro")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DataHoraUltimaAtualizacao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Inativo")
                        .HasColumnType("boolean");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Raca");
                });

            modelBuilder.Entity("backend.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Administrador")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("DataHoraCadastro")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DataHoraUltimaAtualizacao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Inativo")
                        .HasColumnType("boolean");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PermissaoId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PermissaoId");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("backend.Models.Pet", b =>
                {
                    b.HasOne("backend.Models.Raca", "Raca")
                        .WithMany()
                        .HasForeignKey("RacaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Raca");
                });

            modelBuilder.Entity("backend.Models.Usuario", b =>
                {
                    b.HasOne("backend.Models.Permissao", "Permissao")
                        .WithMany()
                        .HasForeignKey("PermissaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permissao");
                });
#pragma warning restore 612, 618
        }
    }
}
