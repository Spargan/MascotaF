using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MascotaFeliz.App.Persistencia.Migrations
{
    public partial class InicialMascota : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cedula = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TarjetaProfesional = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HistorialesDeVisita",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonaId = table.Column<int>(type: "int", nullable: true),
                    Fechas = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistorialesDeVisita", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistorialesDeVisita_Personas_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Mascotas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: true),
                    VeterinarioId = table.Column<int>(type: "int", nullable: true),
                    Temperatura = table.Column<int>(type: "int", nullable: false),
                    Peso = table.Column<int>(type: "int", nullable: false),
                    FrecuenciaRespiratoria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Animo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaVisita = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IDVete = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Especie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Raza = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Recomendaciones = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mascotas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mascotas_Personas_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mascotas_Personas_VeterinarioId",
                        column: x => x.VeterinarioId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Medicamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VeterinarioId = table.Column<int>(type: "int", nullable: true),
                    Formula = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dosis = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medicamento_Personas_VeterinarioId",
                        column: x => x.VeterinarioId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MascotasAfiliadas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MascotaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MascotasAfiliadas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MascotasAfiliadas_Mascotas_MascotaId",
                        column: x => x.MascotaId,
                        principalTable: "Mascotas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistorialesDeVisita_PersonaId",
                table: "HistorialesDeVisita",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_Mascotas_ClienteId",
                table: "Mascotas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Mascotas_VeterinarioId",
                table: "Mascotas",
                column: "VeterinarioId");

            migrationBuilder.CreateIndex(
                name: "IX_MascotasAfiliadas_MascotaId",
                table: "MascotasAfiliadas",
                column: "MascotaId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicamento_VeterinarioId",
                table: "Medicamento",
                column: "VeterinarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistorialesDeVisita");

            migrationBuilder.DropTable(
                name: "MascotasAfiliadas");

            migrationBuilder.DropTable(
                name: "Medicamento");

            migrationBuilder.DropTable(
                name: "Mascotas");

            migrationBuilder.DropTable(
                name: "Personas");
        }
    }
}
