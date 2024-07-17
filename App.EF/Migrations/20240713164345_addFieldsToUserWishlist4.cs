using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace App.EF.Migrations
{
    /// <inheritdoc />
    public partial class addFieldsToUserWishlist4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductWishlistItem");

            migrationBuilder.DropTable(
                name: "ProductWishlist");

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
                    isDeleted = table.Column<bool>(type: "bit", nullable: true),
                    createdDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserWishlistItem");

            migrationBuilder.DropTable(
                name: "UserWishlist");

            migrationBuilder.CreateTable(
                name: "ProductWishlist",
                columns: table => new
                {
                    productWishlistId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductWishlist", x => x.productWishlistId);
                    table.ForeignKey(
                        name: "FK_ProductWishlist_UserClient_userClientId",
                        column: x => x.userClientId,
                        principalTable: "UserClient",
                        principalColumn: "userClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductWishlistItem",
                columns: table => new
                {
                    productWishlistItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productId = table.Column<int>(type: "int", nullable: false),
                    productWishlistId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductWishlistItem", x => x.productWishlistItemId);
                    table.ForeignKey(
                        name: "FK_ProductWishlistItem_ProductWishlist_productWishlistId",
                        column: x => x.productWishlistId,
                        principalTable: "ProductWishlist",
                        principalColumn: "productWishlistId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductWishlist_userClientId",
                table: "ProductWishlist",
                column: "userClientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductWishlistItem_productWishlistId",
                table: "ProductWishlistItem",
                column: "productWishlistId");
        }
    }
}