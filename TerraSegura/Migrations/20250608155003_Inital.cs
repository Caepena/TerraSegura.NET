using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TerraSegura.Migrations
{
    /// <inheritdoc />
    public partial class Inital : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RegiaoMonitoradaNET",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    Nome = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: false),
                    Latitude = table.Column<decimal>(type: "NUMBER(9,6)", nullable: false),
                    Longitude = table.Column<decimal>(type: "NUMBER(9,6)", nullable: false),
                    NivelRisco = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegiaoMonitoradaNET", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SensorLeituraNET",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    Valor = table.Column<decimal>(type: "NUMBER(18,2)", nullable: false),
                    DataHora = table.Column<DateTime>(type: "TIMESTAMP", nullable: false),
                    TipoSensor = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    RegiaoMonitoradaId = table.Column<Guid>(type: "RAW(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SensorLeituraNET", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SensorLeituraNET_RegiaoMonitoradaNET_RegiaoMonitoradaId",
                        column: x => x.RegiaoMonitoradaId,
                        principalTable: "RegiaoMonitoradaNET",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SensorLeituraNET_RegiaoMonitoradaId",
                table: "SensorLeituraNET",
                column: "RegiaoMonitoradaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SensorLeituraNET");

            migrationBuilder.DropTable(
                name: "RegiaoMonitoradaNET");
        }
    }
}
