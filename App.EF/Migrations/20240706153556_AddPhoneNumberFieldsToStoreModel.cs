using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddPhoneNumberFieldsToStoreModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "storeContactInfo_storeCountryCode",
                table: "Stores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "storeContactInfo_storeCountryCodeName",
                table: "Stores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "storeContactInfo_storeDailCode",
                table: "Stores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "storeContactInfo_storePhoneNumber",
                table: "Stores",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "storeContactInfo_storeCountryCode",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "storeContactInfo_storeCountryCodeName",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "storeContactInfo_storeDailCode",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "storeContactInfo_storePhoneNumber",
                table: "Stores");
        }
    }
}