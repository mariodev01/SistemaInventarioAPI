using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaInventarioAPI.Migrations
{
    /// <inheritdoc />
    public partial class tblTransacciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Articulos",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
            //        FechaIngreso = table.Column<DateTime>(type: "date", nullable: false),
            //        Estado = table.Column<bool>(type: "bit", nullable: false),
            //        FechaVencimiento = table.Column<DateTime>(type: "date", nullable: false),
            //        Cantidad = table.Column<int>(type: "int", nullable: false),
            //        Costo = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Articulos", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Estados",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Descripcion = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Estados", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "TipoTransacciones",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Descripcion = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_TipoTransacciones", x => x.Id);
            //    });

            migrationBuilder.CreateTable(
                name: "Transaccions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoTransaccionId = table.Column<int>(type: "int", nullable: false),
                    ArticuloId = table.Column<int>(type: "int", nullable: false),
                    FechaDocumento = table.Column<DateTime>(type: "date", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    CostoTotal = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaccions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transaccions_Articulos_ArticuloId",
                        column: x => x.ArticuloId,
                        principalTable: "Articulos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transaccions_Estados_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transaccions_TipoTransacciones_TipoTransaccionId",
                        column: x => x.TipoTransaccionId,
                        principalTable: "TipoTransacciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transaccions_ArticuloId",
                table: "Transaccions",
                column: "ArticuloId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaccions_EstadoId",
                table: "Transaccions",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaccions_TipoTransaccionId",
                table: "Transaccions",
                column: "TipoTransaccionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transaccions");

            migrationBuilder.DropTable(
                name: "Articulos");

            migrationBuilder.DropTable(
                name: "Estados");

            migrationBuilder.DropTable(
                name: "TipoTransacciones");
        }
    }
}
