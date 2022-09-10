using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ViajerosApp.Migrations
{
    public partial class CreateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ciudades",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciudades", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TipoVehiculos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoVehiculos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Viajeros",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreYApellido = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Viajeros", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Vehiculos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoVehiculoID = table.Column<int>(type: "int", nullable: false),
                    Patente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Vehiculos_TipoVehiculos_TipoVehiculoID",
                        column: x => x.TipoVehiculoID,
                        principalTable: "TipoVehiculos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Viajes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ViajeroID = table.Column<int>(type: "int", nullable: false),
                    CiudadID = table.Column<int>(type: "int", nullable: false),
                    VehiculoID = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CantidadDias = table.Column<int>(type: "int", nullable: false),
                    Reprogramado = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Viajes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Viajes_Ciudades_CiudadID",
                        column: x => x.CiudadID,
                        principalTable: "Ciudades",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Viajes_Vehiculos_VehiculoID",
                        column: x => x.VehiculoID,
                        principalTable: "Vehiculos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Viajes_Viajeros_ViajeroID",
                        column: x => x.ViajeroID,
                        principalTable: "Viajeros",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TipoVehiculos",
                columns: new[] { "ID", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Auto" },
                    { 2, "Camion" },
                    { 3, "Moto" },
                    { 4, "Colectivo" },
                    { 5, "Avion" },
                    { 6, "Otro" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_TipoVehiculoID",
                table: "Vehiculos",
                column: "TipoVehiculoID");

            migrationBuilder.CreateIndex(
                name: "IX_Viajes_CiudadID",
                table: "Viajes",
                column: "CiudadID");

            migrationBuilder.CreateIndex(
                name: "IX_Viajes_VehiculoID",
                table: "Viajes",
                column: "VehiculoID");

            migrationBuilder.CreateIndex(
                name: "IX_Viajes_ViajeroID",
                table: "Viajes",
                column: "ViajeroID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Viajes");

            migrationBuilder.DropTable(
                name: "Ciudades");

            migrationBuilder.DropTable(
                name: "Vehiculos");

            migrationBuilder.DropTable(
                name: "Viajeros");

            migrationBuilder.DropTable(
                name: "TipoVehiculos");
        }
    }
}
