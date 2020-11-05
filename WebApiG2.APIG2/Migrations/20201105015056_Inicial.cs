using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiG2.APIG2.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Deptos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deptos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ciudades",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 45, nullable: false),
                    DeptoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciudades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ciudades_Deptos_DeptoId",
                        column: x => x.DeptoId,
                        principalTable: "Deptos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Documento = table.Column<string>(maxLength: 15, nullable: false),
                    Nombre = table.Column<string>(maxLength: 45, nullable: false),
                    Direccion = table.Column<string>(maxLength: 45, nullable: false),
                    CiudadID = table.Column<int>(nullable: false),
                    Email = table.Column<string>(maxLength: 45, nullable: true),
                    Telefono = table.Column<string>(maxLength: 20, nullable: true),
                    Fechanac = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Personas_Ciudades_CiudadID",
                        column: x => x.CiudadID,
                        principalTable: "Ciudades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ciudades_DeptoId",
                table: "Ciudades",
                column: "DeptoId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_CiudadID",
                table: "Personas",
                column: "CiudadID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Ciudades");

            migrationBuilder.DropTable(
                name: "Deptos");
        }
    }
}
