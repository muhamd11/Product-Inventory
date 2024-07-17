using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.EF.Migrations
{
    /// <inheritdoc />
    public partial class inshlizeDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Places");

            migrationBuilder.EnsureSchema(
                name: "Products");

            migrationBuilder.EnsureSchema(
                name: "Shared");

            migrationBuilder.EnsureSchema(
                name: "SystemBase");

            migrationBuilder.EnsureSchema(
                name: "Users");

            migrationBuilder.EnsureSchema(
                name: "OnlineStores");

            migrationBuilder.CreateTable(
                name: "Branchs",
                schema: "Places",
                columns: table => new
                {
                    branchId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    branchContactInfo_jsutForBuildEF = table.Column<bool>(type: "bit", nullable: true),
                    branchContactInfo_branchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    branchContactInfo_branchAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    branchContactInfo_branchLatitude = table.Column<double>(type: "float", nullable: true),
                    branchContactInfo_branchLongitude = table.Column<double>(type: "float", nullable: true),
                    branchContactInfo_branchManagerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    branchContactInfo_branchEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    branchContactInfo_branchCountryCodeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    branchContactInfo_branchCountryCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    branchContactInfo_branchDailCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    branchContactInfo_branchPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    branchContactSocialMedia_jsutForBuildEF = table.Column<bool>(type: "bit", nullable: true),
                    branchContactSocialMedia_branchWebsite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    branchContactSocialMedia_facebookLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    branchContactSocialMedia_twitterLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    branchContactSocialMedia_instagramLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    branchContactSocialMedia_linkedinLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    branchContactSocialMedia_youtubeLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    branchOpenAt = table.Column<TimeSpan>(type: "time", nullable: false),
                    branchCloseAt = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branchs", x => x.branchId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                schema: "Products",
                columns: table => new
                {
                    categoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    categoryDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.categoryId);
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                schema: "Shared",
                columns: table => new
                {
                    colorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    colorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    colorDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    colorHexCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true),
                    createdDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    updatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.colorId);
                });

            migrationBuilder.CreateTable(
                name: "LogActions",
                schema: "SystemBase",
                columns: table => new
                {
                    logActionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: false),
                    modelName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    actionDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    actionType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    oldData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    newData = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogActions", x => x.logActionId);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                schema: "Places",
                columns: table => new
                {
                    storeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    storeContactInfo_jsutForBuildEF = table.Column<bool>(type: "bit", nullable: true),
                    storeContactInfo_storeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    storeContactInfo_storeAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    storeContactInfo_storeLatitude = table.Column<double>(type: "float", nullable: true),
                    storeContactInfo_storeLongitude = table.Column<double>(type: "float", nullable: true),
                    storeContactInfo_storeManagerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    storeContactInfo_storeEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    storeContactInfo_storeCountryCodeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    storeContactInfo_storeCountryCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    storeContactInfo_storeDailCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    storeContactInfo_storePhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    storeContactSocialMedia_jsutForBuildEF = table.Column<bool>(type: "bit", nullable: true),
                    storeContactSocialMedia_storeWebsite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    storeContactSocialMedia_facebookLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    storeContactSocialMedia_twitterLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    storeContactSocialMedia_instagramLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    storeContactSocialMedia_linkedinLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    storeContactSocialMedia_youtubeLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    storeOpenAt = table.Column<TimeSpan>(type: "time", nullable: false),
                    storeCloseAt = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.storeId);
                });

            migrationBuilder.CreateTable(
                name: "SystemRoleFincations",
                schema: "SystemBase",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    systemRoleId = table.Column<int>(type: "int", nullable: false),
                    funcationsType = table.Column<int>(type: "int", nullable: false),
                    moduleId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    funcationId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isHavePrivlage = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemRoleFincations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SystemRoles",
                schema: "SystemBase",
                columns: table => new
                {
                    systemRoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    systemRoleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    systemRoleDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    systemRoleUserType = table.Column<int>(type: "int", nullable: false),
                    systemRoleCanUseDefault = table.Column<bool>(type: "bit", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true),
                    createdDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    updatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemRoles", x => x.systemRoleId);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                schema: "Shared",
                columns: table => new
                {
                    unitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    unitName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    unitSympol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    unitDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true),
                    createdDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    updatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.unitId);
                });

            migrationBuilder.CreateTable(
                name: "UserEmployees",
                schema: "Users",
                columns: table => new
                {
                    userEmployeetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEmployees", x => x.userEmployeetId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "Products",
                columns: table => new
                {
                    productId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    productDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    categoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.productId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_categoryId",
                        column: x => x.categoryId,
                        principalSchema: "Products",
                        principalTable: "Categories",
                        principalColumn: "categoryId");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "Users",
                columns: table => new
                {
                    userId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userPhoneDialCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userPhoneCC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userPhoneCCName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userLoginName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userType = table.Column<int>(type: "int", nullable: false),
                    systemRoleId = table.Column<int>(type: "int", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true),
                    createdDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    updatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.userId);
                    table.ForeignKey(
                        name: "FK_Users_SystemRoles_systemRoleId",
                        column: x => x.systemRoleId,
                        principalSchema: "SystemBase",
                        principalTable: "SystemRoles",
                        principalColumn: "systemRoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductStores",
                schema: "Products",
                columns: table => new
                {
                    productStoreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productId = table.Column<int>(type: "int", nullable: false),
                    unitId = table.Column<int>(type: "int", nullable: false),
                    colorId = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductStores", x => x.productStoreId);
                    table.ForeignKey(
                        name: "FK_ProductStores_Colors_colorId",
                        column: x => x.colorId,
                        principalSchema: "Shared",
                        principalTable: "Colors",
                        principalColumn: "colorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductStores_Products_productId",
                        column: x => x.productId,
                        principalSchema: "Products",
                        principalTable: "Products",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductStores_Units_unitId",
                        column: x => x.unitId,
                        principalSchema: "Shared",
                        principalTable: "Units",
                        principalColumn: "unitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClients",
                schema: "Users",
                columns: table => new
                {
                    userClientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClients", x => x.userClientId);
                    table.ForeignKey(
                        name: "FK_UserClients_Users_userId",
                        column: x => x.userId,
                        principalSchema: "Users",
                        principalTable: "Users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                schema: "Users",
                columns: table => new
                {
                    userProfileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userPhone_2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userPhoneDialCode_2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userPhoneCC_2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userPhoneCCName_2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userPhone_3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userPhoneDialCode_3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userPhoneCC_3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userPhoneCCName_3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userPhone_4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userPhoneDialCode_4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userPhoneCC_4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userPhoneCCName_4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userBirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.userProfileId);
                    table.ForeignKey(
                        name: "FK_UserProfiles_Users_userId",
                        column: x => x.userId,
                        principalSchema: "Users",
                        principalTable: "Users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wishlists",
                schema: "OnlineStores",
                columns: table => new
                {
                    wishlistId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productQuantity = table.Column<int>(type: "int", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: true),
                    prodcutId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wishlists", x => x.wishlistId);
                    table.ForeignKey(
                        name: "FK_Wishlists_Products_prodcutId",
                        column: x => x.prodcutId,
                        principalSchema: "Products",
                        principalTable: "Products",
                        principalColumn: "productId");
                    table.ForeignKey(
                        name: "FK_Wishlists_Users_userId",
                        column: x => x.userId,
                        principalSchema: "Users",
                        principalTable: "Users",
                        principalColumn: "userId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_categoryId",
                schema: "Products",
                table: "Products",
                column: "categoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductStores_colorId",
                schema: "Products",
                table: "ProductStores",
                column: "colorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductStores_productId",
                schema: "Products",
                table: "ProductStores",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductStores_unitId",
                schema: "Products",
                table: "ProductStores",
                column: "unitId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClients_userId",
                schema: "Users",
                table: "UserClients",
                column: "userId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_userId",
                schema: "Users",
                table: "UserProfiles",
                column: "userId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_systemRoleId",
                schema: "Users",
                table: "Users",
                column: "systemRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Wishlists_prodcutId",
                schema: "OnlineStores",
                table: "Wishlists",
                column: "prodcutId");

            migrationBuilder.CreateIndex(
                name: "IX_Wishlists_userId",
                schema: "OnlineStores",
                table: "Wishlists",
                column: "userId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Branchs",
                schema: "Places");

            migrationBuilder.DropTable(
                name: "LogActions",
                schema: "SystemBase");

            migrationBuilder.DropTable(
                name: "ProductStores",
                schema: "Products");

            migrationBuilder.DropTable(
                name: "Stores",
                schema: "Places");

            migrationBuilder.DropTable(
                name: "SystemRoleFincations",
                schema: "SystemBase");

            migrationBuilder.DropTable(
                name: "UserClients",
                schema: "Users");

            migrationBuilder.DropTable(
                name: "UserEmployees",
                schema: "Users");

            migrationBuilder.DropTable(
                name: "UserProfiles",
                schema: "Users");

            migrationBuilder.DropTable(
                name: "Wishlists",
                schema: "OnlineStores");

            migrationBuilder.DropTable(
                name: "Colors",
                schema: "Shared");

            migrationBuilder.DropTable(
                name: "Units",
                schema: "Shared");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "Products");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "Users");

            migrationBuilder.DropTable(
                name: "Categories",
                schema: "Products");

            migrationBuilder.DropTable(
                name: "SystemRoles",
                schema: "SystemBase");
        }
    }
}
