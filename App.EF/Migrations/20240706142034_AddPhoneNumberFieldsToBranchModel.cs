using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddPhoneNumberFieldsToBranchModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "branchContactInfo_branchCountryCode",
                table: "Branches",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "branchContactInfo_branchCountryCodeName",
                table: "Branches",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "branchContactInfo_branchDailCode",
                table: "Branches",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "branchContactInfo_branchPhoneNumber",
                table: "Branches",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "branchContactInfo_branchCountryCode",
                table: "Branches");

            migrationBuilder.DropColumn(
                name: "branchContactInfo_branchCountryCodeName",
                table: "Branches");

            migrationBuilder.DropColumn(
                name: "branchContactInfo_branchDailCode",
                table: "Branches");

            migrationBuilder.DropColumn(
                name: "branchContactInfo_branchPhoneNumber",
                table: "Branches");
        }
    }
}