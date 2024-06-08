using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIWEBINFO.Migrations
{
    /// <inheritdoc />
    public partial class FechaInicioFin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Fecha",
                table: "Capacitaciones",
                newName: "Modalidad");

            migrationBuilder.AddColumn<string>(
                name: "FechaFin",
                table: "Capacitaciones",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FechaInicio",
                table: "Capacitaciones",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Lugar",
                table: "Capacitaciones",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaFin",
                table: "Capacitaciones");

            migrationBuilder.DropColumn(
                name: "FechaInicio",
                table: "Capacitaciones");

            migrationBuilder.DropColumn(
                name: "Lugar",
                table: "Capacitaciones");

            migrationBuilder.RenameColumn(
                name: "Modalidad",
                table: "Capacitaciones",
                newName: "Fecha");
        }
    }
}
