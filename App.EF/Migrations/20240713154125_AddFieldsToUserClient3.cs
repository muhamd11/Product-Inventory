using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddFieldsToUserClient3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductWishlistItem_ProductWishlist_productWishlistId",
                table: "ProductWishlistItem");

            migrationBuilder.AlterColumn<int>(
                name: "productWishlistId",
                table: "ProductWishlistItem",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductWishlistItem_ProductWishlist_productWishlistId",
                table: "ProductWishlistItem",
                column: "productWishlistId",
                principalTable: "ProductWishlist",
                principalColumn: "productWishlistId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductWishlistItem_ProductWishlist_productWishlistId",
                table: "ProductWishlistItem");

            migrationBuilder.AlterColumn<int>(
                name: "productWishlistId",
                table: "ProductWishlistItem",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductWishlistItem_ProductWishlist_productWishlistId",
                table: "ProductWishlistItem",
                column: "productWishlistId",
                principalTable: "ProductWishlist",
                principalColumn: "productWishlistId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}