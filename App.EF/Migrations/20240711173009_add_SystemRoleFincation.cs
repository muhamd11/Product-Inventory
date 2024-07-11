using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.EF.Migrations
{
    /// <inheritdoc />
    public partial class add_SystemRoleFincation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "Users",
                newName: "updatedDate");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Users",
                newName: "createdDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "UserClient",
                newName: "updatedDate");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "UserClient",
                newName: "createdDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "Units",
                newName: "updatedDate");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Units",
                newName: "createdDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "SystemRoles",
                newName: "updatedDate");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "SystemRoles",
                newName: "createdDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "Colors",
                newName: "updatedDate");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Colors",
                newName: "createdDate");

            migrationBuilder.CreateTable(
                name: "SystemRoleFincations",
                columns: table => new
                {
                    systemRoleId = table.Column<int>(type: "int", nullable: false),
                    funcationsType = table.Column<int>(type: "int", nullable: false),
                    moduleId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    funcationId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isHavePrivlage = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SystemRoleFincations");

            migrationBuilder.RenameColumn(
                name: "updatedDate",
                table: "Users",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "createdDate",
                table: "Users",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "updatedDate",
                table: "UserClient",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "createdDate",
                table: "UserClient",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "updatedDate",
                table: "Units",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "createdDate",
                table: "Units",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "updatedDate",
                table: "SystemRoles",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "createdDate",
                table: "SystemRoles",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "updatedDate",
                table: "Colors",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "createdDate",
                table: "Colors",
                newName: "CreatedDate");
        }
    }
}
