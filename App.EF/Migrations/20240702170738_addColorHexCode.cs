using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.EF.Migrations
{
    /// <inheritdoc />
    public partial class addColorHexCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "colorHexCode",
                table: "Colors",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "colorHexCode",
                table: "Colors");
        }
    }
}