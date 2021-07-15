using Microsoft.EntityFrameworkCore.Migrations;

namespace Tp3.Migrations.MyContextAlojamientoMigrations
{
    public partial class Alojamiento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alojamientos",
                columns: table => new
                {
                    pk = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    barrio = table.Column<string>(type: "varchar(50)", nullable: true),
                    baños = table.Column<int>(type: "int", nullable: false),
                    cantPersonas = table.Column<int>(type: "int", nullable: false),
                    ciudad = table.Column<string>(type: "varchar(50)", nullable: true),
                    codigo = table.Column<int>(type: "int", nullable: false),
                    estrellas = table.Column<int>(type: "int", nullable: false),
                    habitaciones = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "varchar(50)", nullable: true),
                    precioDia = table.Column<int>(type: "int", nullable: false),
                    precioPorPersona = table.Column<int>(type: "int", nullable: false),
                    tipo = table.Column<string>(type: "varchar(50)", nullable: true),
                    tv = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alojamientos", x => x.pk);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alojamientos");
        }
    }
}
