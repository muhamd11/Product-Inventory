using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace App.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserClient_userBuyerDatauserClientId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "createdDate",
                table: "UserClient");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "UserClient");

            migrationBuilder.DropColumn(
                name: "updatedDate",
                table: "UserClient");

            migrationBuilder.RenameColumn(
                name: "userBuyerDatauserClientId",
                table: "Users",
                newName: "userClientDatauserClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_userBuyerDatauserClientId",
                table: "Users",
                newName: "IX_Users_userClientDatauserClientId");

            migrationBuilder.RenameColumn(
                name: "buyerBirthDate",
                table: "UserProfile",
                newName: "userBirthDate");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserClient_userClientDatauserClientId",
                table: "Users",
                column: "userClientDatauserClientId",
                principalTable: "UserClient",
                principalColumn: "userClientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserClient_userClientDatauserClientId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "userClientDatauserClientId",
                table: "Users",
                newName: "userBuyerDatauserClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_userClientDatauserClientId",
                table: "Users",
                newName: "IX_Users_userBuyerDatauserClientId");

            migrationBuilder.RenameColumn(
                name: "userBirthDate",
                table: "UserProfile",
                newName: "buyerBirthDate");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "createdDate",
                table: "UserClient",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "UserClient",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "updatedDate",
                table: "UserClient",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserClient_userBuyerDatauserClientId",
                table: "Users",
                column: "userBuyerDatauserClientId",
                principalTable: "UserClient",
                principalColumn: "userClientId");
        }
    }
}