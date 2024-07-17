using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddFieldsToUserClient2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "userBillingAddress",
                table: "UserClient",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "userShippingAddress",
                table: "UserClient",
                type: "nvarchar(max)",
                nullable: true);

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
                    productWishlistId = table.Column<int>(type: "int", nullable: false),
                    productId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductWishlistItem", x => x.productWishlistItemId);
                    table.ForeignKey(
                        name: "FK_ProductWishlistItem_ProductWishlist_productWishlistId",
                        column: x => x.productWishlistId,
                        principalTable: "ProductWishlist",
                        principalColumn: "productWishlistId",
                        onDelete: ReferentialAction.Cascade);
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductWishlistItem");

            migrationBuilder.DropTable(
                name: "ProductWishlist");

            migrationBuilder.DropColumn(
                name: "userBillingAddress",
                table: "UserClient");

            migrationBuilder.DropColumn(
                name: "userShippingAddress",
                table: "UserClient");
        }
    }
}