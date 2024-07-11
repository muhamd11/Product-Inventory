using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.EF.Migrations
{
    /// <inheritdoc />
    public partial class add_fileds_to_SystemRole1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "systemRoleCanUseDefault",
                table: "SystemRoles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "systemRoleUserType",
                table: "SystemRoles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "systemRoleCanUseDefault",
                table: "SystemRoles");

            migrationBuilder.DropColumn(
                name: "systemRoleUserType",
                table: "SystemRoles");
        }
    }
}
