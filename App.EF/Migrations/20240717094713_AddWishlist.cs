using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddWishlist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserWishlistItem");

            migrationBuilder.DropTable(
                name: "UserWishlist");

            migrationBuilder.DropColumn(
                name: "userBillingAddress",
                table: "UserClient");

            migrationBuilder.AddColumn<int>(
                name: "userProductWishListId",
                table: "UserClient",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserWishlists",
                columns: table => new
                {
                    wishlistId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userClientId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserWishlists", x => x.wishlistId);
                });

            migrationBuilder.CreateTable(
                name: "UserWishlistItems",
                columns: table => new
                {
                    wishlistItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    wishlistId = table.Column<int>(type: "int", nullable: false),
                    wishlistItemProductId = table.Column<int>(type: "int", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true),
                    createdDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    updatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
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
                name: "IX_UserClient_userProductWishListId",
                table: "UserClient",
                column: "userProductWishListId");

            migrationBuilder.CreateIndex(
                name: "IX_UserWishlistItems_wishlistId",
                table: "UserWishlistItems",
                column: "wishlistId");

            migrationBuilder.CreateIndex(
                name: "IX_UserWishlistItems_wishlistItemProductId",
                table: "UserWishlistItems",
                column: "wishlistItemProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserClient_UserWishlists_userProductWishListId",
                table: "UserClient",
                column: "userProductWishListId",
                principalTable: "UserWishlists",
                principalColumn: "wishlistId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserClient_UserWishlists_userProductWishListId",
                table: "UserClient");

            migrationBuilder.DropTable(
                name: "UserWishlistItems");

            migrationBuilder.DropTable(
                name: "UserWishlists");

            migrationBuilder.DropIndex(
                name: "IX_UserClient_userProductWishListId",
                table: "UserClient");

            migrationBuilder.DropColumn(
                name: "userProductWishListId",
                table: "UserClient");

            migrationBuilder.AddColumn<string>(
                name: "userBillingAddress",
                table: "UserClient",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserWishlist",
                columns: table => new
                {
                    userClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserWishlist", x => x.userClientId);
                    table.ForeignKey(
                        name: "FK_UserWishlist_UserClient_userClientId",
                        column: x => x.userClientId,
                        principalTable: "UserClient",
                        principalColumn: "userClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserWishlistItem",
                columns: table => new
                {
                    userWishlistItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userWishlistItemProductId = table.Column<int>(type: "int", nullable: false),
                    UserWishlistuserClientId = table.Column<int>(type: "int", nullable: true),
                    createdDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true),
                    updatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserWishlistItem", x => x.userWishlistItemId);
                    table.ForeignKey(
                        name: "FK_UserWishlistItem_Products_userWishlistItemProductId",
                        column: x => x.userWishlistItemProductId,
                        principalTable: "Products",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserWishlistItem_UserWishlist_UserWishlistuserClientId",
                        column: x => x.UserWishlistuserClientId,
                        principalTable: "UserWishlist",
                        principalColumn: "userClientId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserWishlistItem_userWishlistItemProductId",
                table: "UserWishlistItem",
                column: "userWishlistItemProductId");

            migrationBuilder.CreateIndex(
                name: "IX_UserWishlistItem_UserWishlistuserClientId",
                table: "UserWishlistItem",
                column: "UserWishlistuserClientId");
        }
    }
}
