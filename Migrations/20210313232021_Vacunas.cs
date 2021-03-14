using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VacunasApp.Migrations
{
    public partial class Vacunas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pais",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pais", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PrimeraDosis",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    recibida = table.Column<bool>(nullable: false),
                    fechaRecibida = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrimeraDosis", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SegundaDosis",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    recibida = table.Column<bool>(nullable: false),
                    fechaRecibida = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SegundaDosis", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "signossodiacales",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nombre = table.Column<string>(nullable: true),
                    fechaInicio = table.Column<DateTime>(nullable: false),
                    fechaFinal = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_signossodiacales", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "provincias",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nombre = table.Column<string>(nullable: true),
                    pais_id = table.Column<int>(nullable: true),
                    Paisid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_provincias", x => x.id);
                    table.ForeignKey(
                        name: "FK_provincias_pais_Paisid",
                        column: x => x.Paisid,
                        principalTable: "pais",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "provincias_pais_id_fkey",
                        column: x => x.pais_id,
                        principalTable: "pais",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "vacunas",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nombre = table.Column<string>(nullable: true),
                    marca = table.Column<string>(nullable: true),
                    cantidad = table.Column<long>(nullable: false),
                    disponibilidad = table.Column<bool>(nullable: false),
                    primeradosis_id = table.Column<int>(nullable: true),
                    segundadosis_id = table.Column<int>(nullable: true),
                    PrimeraDosisid = table.Column<int>(nullable: true),
                    SegundaDosisid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vacunas", x => x.id);
                    table.ForeignKey(
                        name: "FK_vacunas_PrimeraDosis_PrimeraDosisid",
                        column: x => x.PrimeraDosisid,
                        principalTable: "PrimeraDosis",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_vacunas_SegundaDosis_SegundaDosisid",
                        column: x => x.SegundaDosisid,
                        principalTable: "SegundaDosis",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "vacuna_primeradosis_id_fkey",
                        column: x => x.primeradosis_id,
                        principalTable: "PrimeraDosis",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "vacuna_segundadosis_id_fkey",
                        column: x => x.segundadosis_id,
                        principalTable: "SegundaDosis",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "personas",
                columns: table => new
                {
                    cedula = table.Column<string>(nullable: false),
                    nombre = table.Column<string>(nullable: true),
                    apellido = table.Column<string>(nullable: true),
                    telefono = table.Column<string>(nullable: true),
                    fechaNacimiento = table.Column<DateTime>(nullable: false),
                    vacuna_id = table.Column<int>(nullable: true),
                    provincia_id = table.Column<int>(nullable: true),
                    signosodiacal_id = table.Column<int>(nullable: true),
                    Provinciasid = table.Column<int>(nullable: true),
                    SignosSodiacalesid = table.Column<int>(nullable: true),
                    Vacunasid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personas", x => x.cedula);
                    table.ForeignKey(
                        name: "FK_personas_provincias_Provinciasid",
                        column: x => x.Provinciasid,
                        principalTable: "provincias",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_personas_signossodiacales_SignosSodiacalesid",
                        column: x => x.SignosSodiacalesid,
                        principalTable: "signossodiacales",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_personas_vacunas_Vacunasid",
                        column: x => x.Vacunasid,
                        principalTable: "vacunas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "persona_provincia_id_fkey",
                        column: x => x.provincia_id,
                        principalTable: "provincias",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "persona_signosodiacal_id_id_fkey",
                        column: x => x.signosodiacal_id,
                        principalTable: "signossodiacales",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "persona_vacuna_id_fkey",
                        column: x => x.vacuna_id,
                        principalTable: "vacunas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_personas_Provinciasid",
                table: "personas",
                column: "Provinciasid");

            migrationBuilder.CreateIndex(
                name: "IX_personas_SignosSodiacalesid",
                table: "personas",
                column: "SignosSodiacalesid");

            migrationBuilder.CreateIndex(
                name: "IX_personas_Vacunasid",
                table: "personas",
                column: "Vacunasid");

            migrationBuilder.CreateIndex(
                name: "IX_personas_provincia_id",
                table: "personas",
                column: "provincia_id");

            migrationBuilder.CreateIndex(
                name: "IX_personas_signosodiacal_id",
                table: "personas",
                column: "signosodiacal_id");

            migrationBuilder.CreateIndex(
                name: "IX_personas_vacuna_id",
                table: "personas",
                column: "vacuna_id");

            migrationBuilder.CreateIndex(
                name: "IX_provincias_Paisid",
                table: "provincias",
                column: "Paisid");

            migrationBuilder.CreateIndex(
                name: "IX_provincias_pais_id",
                table: "provincias",
                column: "pais_id");

            migrationBuilder.CreateIndex(
                name: "IX_vacunas_PrimeraDosisid",
                table: "vacunas",
                column: "PrimeraDosisid");

            migrationBuilder.CreateIndex(
                name: "IX_vacunas_SegundaDosisid",
                table: "vacunas",
                column: "SegundaDosisid");

            migrationBuilder.CreateIndex(
                name: "IX_vacunas_primeradosis_id",
                table: "vacunas",
                column: "primeradosis_id");

            migrationBuilder.CreateIndex(
                name: "IX_vacunas_segundadosis_id",
                table: "vacunas",
                column: "segundadosis_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "personas");

            migrationBuilder.DropTable(
                name: "provincias");

            migrationBuilder.DropTable(
                name: "signossodiacales");

            migrationBuilder.DropTable(
                name: "vacunas");

            migrationBuilder.DropTable(
                name: "pais");

            migrationBuilder.DropTable(
                name: "PrimeraDosis");

            migrationBuilder.DropTable(
                name: "SegundaDosis");
        }
    }
}
