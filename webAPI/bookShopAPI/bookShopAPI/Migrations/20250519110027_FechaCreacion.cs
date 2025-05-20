using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bookShopAPI.Migrations
{
    /// <inheritdoc />
    public partial class FechaCreacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "Libros",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<int>(
                name: "AutorId",
                table: "ImagenesAutores",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "LibroISBN",
                table: "Imagenes",
                type: "nvarchar(13)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(13)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "Libros");

            migrationBuilder.AlterColumn<int>(
                name: "AutorId",
                table: "ImagenesAutores",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LibroISBN",
                table: "Imagenes",
                type: "nvarchar(13)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(13)",
                oldNullable: true);
        }
    }
}
