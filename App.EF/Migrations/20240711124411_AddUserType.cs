using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace App.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddUserType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "userContanctInfo_userBirthDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "userContanctInfo_userCountryCode",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "userContanctInfo_userCountryCodeName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "userContanctInfo_userCreationDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "userContanctInfo_userDailCode",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "userContanctInfo_userEmail",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "userContanctInfo_userFirstName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "userContanctInfo_userIsActive",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "userContanctInfo_userLastName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "userContanctInfo_userPhoneNumber",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "Buyer",
                columns: table => new
                {
                    userId = table.Column<int>(type: "int", nullable: false),
                    buyerFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    buyerLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    buyerCountryCodeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    buyerCountryCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    buyerDailCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    buyerPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    buyerEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    buyerBirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    buyerIsActive = table.Column<bool>(type: "bit", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buyer", x => x.userId);
                    table.ForeignKey(
                        name: "FK_Buyer_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Buyer");

            migrationBuilder.AddColumn<DateOnly>(
                name: "userContanctInfo_userBirthDate",
                table: "Users",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "userContanctInfo_userCountryCode",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "userContanctInfo_userCountryCodeName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "userContanctInfo_userCreationDate",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "userContanctInfo_userDailCode",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "userContanctInfo_userEmail",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "userContanctInfo_userFirstName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "userContanctInfo_userIsActive",
                table: "Users",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "userContanctInfo_userLastName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "userContanctInfo_userPhoneNumber",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
