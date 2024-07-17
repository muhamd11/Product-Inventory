using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.EF.Migrations
{
    /// <inheritdoc />
    public partial class RemoveWishlistItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserWishlistItems");

            migrationBuilder.AddColumn<int>(
                name: "prodcutWishlistId",
                table: "UserWishlists",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "productQuantity",
                table: "UserWishlists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserWishlists_prodcutWishlistId",
                table: "UserWishlists",
                column: "prodcutWishlistId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserWishlists_Products_prodcutWishlistId",
                table: "UserWishlists",
                column: "prodcutWishlistId",
                principalTable: "Products",
                principalColumn: "productId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserWishlists_Products_prodcutWishlistId",
                table: "UserWishlists");

            migrationBuilder.DropIndex(
                name: "IX_UserWishlists_prodcutWishlistId",
                table: "UserWishlists");

            migrationBuilder.DropColumn(
                name: "prodcutWishlistId",
                table: "UserWishlists");

            migrationBuilder.DropColumn(
                name: "productQuantity",
                table: "UserWishlists");

            migrationBuilder.CreateTable(
                name: "UserWishlistItems",
                columns: table => new
                {
                    wishlistItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    wishlistItemProductId = table.Column<int>(type: "int", nullable: false),
                    createdDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true),
                    updatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    wishlistId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserWishlistItems", x => x.wishlistItemId);
                    table.ForeignKey(
                        name: "FK_UserWishlistItems_Products_wishlistItemProductId",
                        column: x => x.wishlistItemProductId,
                        principalTable: "Products",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserWishlistItems_UserWishlists_wishlistId",
                        column: x => x.wishlistId,
                        principalTable: "UserWishlists",
                        principalColumn: "wishlistId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserWishlistItems_wishlistId",
                table: "UserWishlistItems",
                column: "wishlistId");

            migrationBuilder.CreateIndex(
                name: "IX_UserWishlistItems_wishlistItemProductId",
                table: "UserWishlistItems",
                column: "wishlistItemProductId");
        }
    }
}
