using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tp3.Migrations.MyContextReservaMigrations
{
    public partial class Reserva : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reserva",
                columns: table => new
                {
                    pk = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fdesde = table.Column<DateTime>(type: "datetime", nullable: false),
                    fhasta = table.Column<DateTime>(type: "datetime", nullable: false),
                    id = table.Column<int>(type: "int", nullable: false),
                    personaint = table.Column<int>(type: "int", nullable: false),
                    precio = table.Column<int>(type: "int", nullable: false),
                    propiedadint = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserva", x => x.pk);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reserva");
        }
    }
}
