using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bookShopAPI.Migrations
{
    /// <inheritdoc />
    public partial class esPortada : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EsPortada",
                table: "Imagenes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EsPortada",
                table: "Imagenes");
        }
    }
}
