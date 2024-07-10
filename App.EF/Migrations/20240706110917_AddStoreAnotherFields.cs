using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace App.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddStoreAnotherFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "branchCity",
                table: "Branches");

            migrationBuilder.DropColumn(
                name: "branchCountry",
                table: "Branches");

            migrationBuilder.RenameColumn(
                name: "storeName",
                table: "Stores",
                newName: "storeContactInfo_storeName");

            migrationBuilder.RenameColumn(
                name: "storeAddress",
                table: "Stores",
                newName: "storeContactInfo_storeAddress");

            migrationBuilder.RenameColumn(
                name: "branchWebsite",
                table: "Branches",
                newName: "branchContactSocialMedia_branchWebsite");

            migrationBuilder.RenameColumn(
                name: "branchName",
                table: "Branches",
                newName: "branchContactInfo_branchName");

            migrationBuilder.RenameColumn(
                name: "branchManagerName",
                table: "Branches",
                newName: "branchContactInfo_branchManagerName");

            migrationBuilder.RenameColumn(
                name: "branchLongitude",
                table: "Branches",
                newName: "branchContactInfo_branchLongitude");

            migrationBuilder.RenameColumn(
                name: "branchLatitude",
                table: "Branches",
                newName: "branchContactInfo_branchLatitude");

            migrationBuilder.RenameColumn(
                name: "branchEmail",
                table: "Branches",
                newName: "branchContactInfo_branchEmail");

            migrationBuilder.RenameColumn(
                name: "branchAddress",
                table: "Branches",
                newName: "branchContactInfo_branchAddress");

            migrationBuilder.RenameColumn(
                name: "YouTubeLink",
                table: "Branches",
                newName: "branchContactSocialMedia_youtubeLink");

            migrationBuilder.RenameColumn(
                name: "TwitterLink",
                table: "Branches",
                newName: "branchContactSocialMedia_twitterLink");

            migrationBuilder.RenameColumn(
                name: "LinkedInLink",
                table: "Branches",
                newName: "branchContactSocialMedia_linkedinLink");

            migrationBuilder.RenameColumn(
                name: "InstagramLink",
                table: "Branches",
                newName: "branchContactSocialMedia_instagramLink");

            migrationBuilder.RenameColumn(
                name: "FacebookLink",
                table: "Branches",
                newName: "branchContactSocialMedia_facebookLink");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "storeCloseAt",
                table: "Stores",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<string>(
                name: "storeContactInfo_storeEmail",
                table: "Stores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "storeContactInfo_storeLatitude",
                table: "Stores",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "storeContactInfo_storeLongitude",
                table: "Stores",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "storeContactInfo_storeManagerName",
                table: "Stores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "storeContactSocialMedia_facebookLink",
                table: "Stores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "storeContactSocialMedia_instagramLink",
                table: "Stores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "storeContactSocialMedia_linkedinLink",
                table: "Stores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "storeContactSocialMedia_storeWebsite",
                table: "Stores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "storeContactSocialMedia_twitterLink",
                table: "Stores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "storeContactSocialMedia_youtubeLink",
                table: "Stores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "storeOpenAt",
                table: "Stores",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AlterColumn<double>(
                name: "branchContactInfo_branchLongitude",
                table: "Branches",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "branchContactInfo_branchLatitude",
                table: "Branches",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "storeCloseAt",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "storeContactInfo_storeEmail",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "storeContactInfo_storeLatitude",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "storeContactInfo_storeLongitude",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "storeContactInfo_storeManagerName",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "storeContactSocialMedia_facebookLink",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "storeContactSocialMedia_instagramLink",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "storeContactSocialMedia_linkedinLink",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "storeContactSocialMedia_storeWebsite",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "storeContactSocialMedia_twitterLink",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "storeContactSocialMedia_youtubeLink",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "storeOpenAt",
                table: "Stores");

            migrationBuilder.RenameColumn(
                name: "storeContactInfo_storeName",
                table: "Stores",
                newName: "storeName");

            migrationBuilder.RenameColumn(
                name: "storeContactInfo_storeAddress",
                table: "Stores",
                newName: "storeAddress");

            migrationBuilder.RenameColumn(
                name: "branchContactSocialMedia_youtubeLink",
                table: "Branches",
                newName: "YouTubeLink");

            migrationBuilder.RenameColumn(
                name: "branchContactSocialMedia_twitterLink",
                table: "Branches",
                newName: "TwitterLink");

            migrationBuilder.RenameColumn(
                name: "branchContactSocialMedia_linkedinLink",
                table: "Branches",
                newName: "LinkedInLink");

            migrationBuilder.RenameColumn(
                name: "branchContactSocialMedia_instagramLink",
                table: "Branches",
                newName: "InstagramLink");

            migrationBuilder.RenameColumn(
                name: "branchContactSocialMedia_facebookLink",
                table: "Branches",
                newName: "FacebookLink");

            migrationBuilder.RenameColumn(
                name: "branchContactSocialMedia_branchWebsite",
                table: "Branches",
                newName: "branchWebsite");

            migrationBuilder.RenameColumn(
                name: "branchContactInfo_branchName",
                table: "Branches",
                newName: "branchName");

            migrationBuilder.RenameColumn(
                name: "branchContactInfo_branchManagerName",
                table: "Branches",
                newName: "branchManagerName");

            migrationBuilder.RenameColumn(
                name: "branchContactInfo_branchLongitude",
                table: "Branches",
                newName: "branchLongitude");

            migrationBuilder.RenameColumn(
                name: "branchContactInfo_branchLatitude",
                table: "Branches",
                newName: "branchLatitude");

            migrationBuilder.RenameColumn(
                name: "branchContactInfo_branchEmail",
                table: "Branches",
                newName: "branchEmail");

            migrationBuilder.RenameColumn(
                name: "branchContactInfo_branchAddress",
                table: "Branches",
                newName: "branchAddress");

            migrationBuilder.AlterColumn<double>(
                name: "branchLongitude",
                table: "Branches",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "branchLatitude",
                table: "Branches",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "branchCity",
                table: "Branches",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "branchCountry",
                table: "Branches",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}