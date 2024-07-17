using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.EF.Migrations
{
    /// <inheritdoc />
    public partial class improve_preformance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "userPhone",
                schema: "Users",
                table: "Users",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "userLoginName",
                schema: "Users",
                table: "Users",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "userEmail",
                schema: "Users",
                table: "Users",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_userEmail",
                schema: "Users",
                table: "Users",
                column: "userEmail",
                unique: true,
                filter: "[userEmail] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_userLoginName",
                schema: "Users",
                table: "Users",
                column: "userLoginName",
                unique: true,
                filter: "[userLoginName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_userPhone",
                schema: "Users",
                table: "Users",
                column: "userPhone",
                unique: true,
                filter: "[userPhone] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_userType",
                schema: "Users",
                table: "Users",
                column: "userType");

            migrationBuilder.CreateIndex(
                name: "IX_UserEmployees_userId",
                schema: "Users",
                table: "UserEmployees",
                column: "userId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserEmployees_Users_userId",
                schema: "Users",
                table: "UserEmployees",
                column: "userId",
                principalSchema: "Users",
                principalTable: "Users",
                principalColumn: "userId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserEmployees_Users_userId",
                schema: "Users",
                table: "UserEmployees");

            migrationBuilder.DropIndex(
                name: "IX_Users_userEmail",
                schema: "Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_userLoginName",
                schema: "Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_userPhone",
                schema: "Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_userType",
                schema: "Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_UserEmployees_userId",
                schema: "Users",
                table: "UserEmployees");

            migrationBuilder.AlterColumn<string>(
                name: "userPhone",
                schema: "Users",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "userLoginName",
                schema: "Users",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "userEmail",
                schema: "Users",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
