using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace App.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddBranchFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FacebookLink",
                table: "Branches",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstagramLink",
                table: "Branches",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkedInLink",
                table: "Branches",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TwitterLink",
                table: "Branches",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "YouTubeLink",
                table: "Branches",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "branchCity",
                table: "Branches",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "branchCloseAt",
                table: "Branches",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<string>(
                name: "branchCountry",
                table: "Branches",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "branchEmail",
                table: "Branches",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "branchManagerName",
                table: "Branches",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "branchOpenAt",
                table: "Branches",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<string>(
                name: "branchWebsite",
                table: "Branches",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FacebookLink",
                table: "Branches");

            migrationBuilder.DropColumn(
                name: "InstagramLink",
                table: "Branches");

            migrationBuilder.DropColumn(
                name: "LinkedInLink",
                table: "Branches");

            migrationBuilder.DropColumn(
                name: "TwitterLink",
                table: "Branches");

            migrationBuilder.DropColumn(
                name: "YouTubeLink",
                table: "Branches");

            migrationBuilder.DropColumn(
                name: "branchCity",
                table: "Branches");

            migrationBuilder.DropColumn(
                name: "branchCloseAt",
                table: "Branches");

            migrationBuilder.DropColumn(
                name: "branchCountry",
                table: "Branches");

            migrationBuilder.DropColumn(
                name: "branchEmail",
                table: "Branches");

            migrationBuilder.DropColumn(
                name: "branchManagerName",
                table: "Branches");

            migrationBuilder.DropColumn(
                name: "branchOpenAt",
                table: "Branches");

            migrationBuilder.DropColumn(
                name: "branchWebsite",
                table: "Branches");
        }
    }
}