using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddFields2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "userPhoneDialCode",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "userPhoneDialCode_2",
                table: "UserProfile",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "userPhoneDialCode_3",
                table: "UserProfile",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "userPhoneDialCode_4",
                table: "UserProfile",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "userPhoneDialCode",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "userPhoneDialCode_2",
                table: "UserProfile");

            migrationBuilder.DropColumn(
                name: "userPhoneDialCode_3",
                table: "UserProfile");

            migrationBuilder.DropColumn(
                name: "userPhoneDialCode_4",
                table: "UserProfile");
        }
    }
}