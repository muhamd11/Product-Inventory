using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace App.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddUserModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    userId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userContanctInfo_userFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userContanctInfo_userLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userContanctInfo_userCountryCodeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userContanctInfo_userCountryCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userContanctInfo_userDailCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userContanctInfo_userPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userContanctInfo_userEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userContanctInfo_userBirthDate = table.Column<DateOnly>(type: "date", nullable: true),
                    userContanctInfo_userIsActive = table.Column<bool>(type: "bit", nullable: true),
                    userName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.userId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}