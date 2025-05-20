using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bookShopAPI.Migrations
{
    /// <inheritdoc />
    public partial class imagenAutorbool : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "esPrincipal",
                table: "ImagenesAutores",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "esPrincipal",
                table: "ImagenesAutores");
        }
    }
}
