using Microsoft.EntityFrameworkCore.Migrations;

namespace Tp3.Migrations
{
    public partial class Usuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    num_usr = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DNI = table.Column<int>(type: "int", nullable: false),
                    Mail = table.Column<string>(type: "varchar(50)", nullable: true),
                    Nombre = table.Column<string>(type: "varchar(50)", nullable: true),
                    Password = table.Column<string>(type: "varchar(50)", nullable: true),
                    bloqueado = table.Column<bool>(type: "bit", nullable: false),
                    esAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.num_usr);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
