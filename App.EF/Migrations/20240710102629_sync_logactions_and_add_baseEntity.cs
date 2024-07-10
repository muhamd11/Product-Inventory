using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.EF.Migrations
{
    /// <inheritdoc />
    public partial class sync_logactions_and_add_baseEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryProduct");

            migrationBuilder.RenameColumn(
                name: "ModelName",
                table: "LogActions",
                newName: "modelName");

            migrationBuilder.RenameColumn(
                name: "ActionDate",
                table: "LogActions",
                newName: "actionDate");

            migrationBuilder.RenameColumn(
                name: "oldActionData",
                table: "LogActions",
                newName: "oldData");

            migrationBuilder.RenameColumn(
                name: "newActionData",
                table: "LogActions",
                newName: "newData");

            migrationBuilder.AddColumn<bool>(
                name: "storeContactInfo_jsutForBuildEF",
                table: "Stores",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "storeContactSocialMedia_jsutForBuildEF",
                table: "Stores",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "categoryId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "actionDate",
                table: "LogActions",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<bool>(
                name: "branchContactInfo_jsutForBuildEF",
                table: "Branches",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "branchContactSocialMedia_jsutForBuildEF",
                table: "Branches",
                type: "bit",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_categoryId",
                table: "Products",
                column: "categoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_categoryId",
                table: "Products",
                column: "categoryId",
                principalTable: "Categories",
                principalColumn: "categoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_categoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_categoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "storeContactInfo_jsutForBuildEF",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "storeContactSocialMedia_jsutForBuildEF",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "categoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "branchContactInfo_jsutForBuildEF",
                table: "Branches");

            migrationBuilder.DropColumn(
                name: "branchContactSocialMedia_jsutForBuildEF",
                table: "Branches");

            migrationBuilder.RenameColumn(
                name: "modelName",
                table: "LogActions",
                newName: "ModelName");

            migrationBuilder.RenameColumn(
                name: "actionDate",
                table: "LogActions",
                newName: "ActionDate");

            migrationBuilder.RenameColumn(
                name: "oldData",
                table: "LogActions",
                newName: "oldActionData");

            migrationBuilder.RenameColumn(
                name: "newData",
                table: "LogActions",
                newName: "newActionData");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActionDate",
                table: "LogActions",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.CreateTable(
                name: "CategoryProduct",
                columns: table => new
                {
                    categoryDatacategoryId = table.Column<int>(type: "int", nullable: false),
                    productsDataproductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProduct", x => new { x.categoryDatacategoryId, x.productsDataproductId });
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Categories_categoryDatacategoryId",
                        column: x => x.categoryDatacategoryId,
                        principalTable: "Categories",
                        principalColumn: "categoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Products_productsDataproductId",
                        column: x => x.productsDataproductId,
                        principalTable: "Products",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProduct_productsDataproductId",
                table: "CategoryProduct",
                column: "productsDataproductId");
        }
    }
}
