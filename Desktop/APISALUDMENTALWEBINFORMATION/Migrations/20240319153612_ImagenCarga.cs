using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIWEBINFO.Migrations
{
    /// <inheritdoc />
    public partial class ImagenCarga : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ImagenData",
                table: "Capacitaciones",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagenData",
                table: "Capacitaciones");
        }
    }
}
