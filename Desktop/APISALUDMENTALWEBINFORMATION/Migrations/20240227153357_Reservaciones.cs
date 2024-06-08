using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIWEBINFO.Migrations
{
    /// <inheritdoc />
    public partial class Reservaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Formularios",
                table: "Formularios");

            migrationBuilder.RenameTable(
                name: "Formularios",
                newName: "Formulario");

            migrationBuilder.RenameColumn(
                name: "Usuario",
                table: "Formulario",
                newName: "Sexo");

            migrationBuilder.RenameColumn(
                name: "Labor",
                table: "Formulario",
                newName: "Rol");

            migrationBuilder.RenameColumn(
                name: "Fecha",
                table: "Formulario",
                newName: "Nombre");

            migrationBuilder.AddColumn<string>(
                name: "LinkImg",
                table: "Capacitaciones",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FechaNacimiento",
                table: "Formulario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FechaSuceso",
                table: "Formulario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Formulario",
                table: "Formulario",
                column: "IdFormulario");

            migrationBuilder.CreateTable(
                name: "Reservaciones",
                columns: table => new
                {
                    IdReservacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<int>(type: "int", nullable: false),
                    Mensaje = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CapacitacionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservaciones", x => x.IdReservacion);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservaciones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Formulario",
                table: "Formulario");

            migrationBuilder.DropColumn(
                name: "LinkImg",
                table: "Capacitaciones");

            migrationBuilder.DropColumn(
                name: "FechaNacimiento",
                table: "Formulario");

            migrationBuilder.DropColumn(
                name: "FechaSuceso",
                table: "Formulario");

            migrationBuilder.RenameTable(
                name: "Formulario",
                newName: "Formularios");

            migrationBuilder.RenameColumn(
                name: "Sexo",
                table: "Formularios",
                newName: "Usuario");

            migrationBuilder.RenameColumn(
                name: "Rol",
                table: "Formularios",
                newName: "Labor");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Formularios",
                newName: "Fecha");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Formularios",
                table: "Formularios",
                column: "IdFormulario");
        }
    }
}
