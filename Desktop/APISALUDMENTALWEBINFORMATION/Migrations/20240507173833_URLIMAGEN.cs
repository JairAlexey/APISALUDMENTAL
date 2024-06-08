using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIWEBINFO.Migrations
{
    /// <inheritdoc />
    public partial class URLIMAGEN : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagenData",
                table: "Capacitaciones");

            migrationBuilder.AddColumn<string>(
                name: "URLImagen",
                table: "Capacitaciones",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "URLImagen",
                table: "Capacitaciones");

            migrationBuilder.AddColumn<byte[]>(
                name: "ImagenData",
                table: "Capacitaciones",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
