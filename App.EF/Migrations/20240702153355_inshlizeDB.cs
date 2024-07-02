using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.EF.Migrations
{
    /// <inheritdoc />
    public partial class inshlizeDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    unitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    unitName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    unitSympol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    unitDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.unitId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Units");
        }
    }
}