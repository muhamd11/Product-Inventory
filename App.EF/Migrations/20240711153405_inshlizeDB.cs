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
            migrationBuilder.CreateTable(
                name: "Branches",
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
                    table.PrimaryKey("PK_Branches", x => x.branchId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
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
                columns: table => new
                {
                    colorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    colorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    colorDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    colorHexCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.colorId);
                });

            migrationBuilder.CreateTable(
                name: "LogActions",
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
                name: "SystemRoles",
                columns: table => new
                {
                    systemRoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    systemRoleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    systemRoleDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemRoles", x => x.systemRoleId);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    unitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    unitName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    unitSympol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    unitDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.unitId);
                });

            migrationBuilder.CreateTable(
                name: "UserClient",
                columns: table => new
                {
                    userClientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClient", x => x.userClientId);
                });

            migrationBuilder.CreateTable(
                name: "UserProfile",
                columns: table => new
                {
                    userProfileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userPhone_2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userPhoneCC_2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userPhoneCCName_2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userPhone_3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userPhoneCC_3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userPhoneCCName_3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userPhone_4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userPhoneCC_4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userPhoneCCName_4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    buyerBirthDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfile", x => x.userProfileId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
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
                        principalTable: "Categories",
                        principalColumn: "categoryId");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    userId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userPhoneCC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userPhoneCCName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userLoginName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userType = table.Column<int>(type: "int", nullable: false),
                    systemRoleId = table.Column<int>(type: "int", nullable: false),
                    userProfileId = table.Column<int>(type: "int", nullable: true),
                    userBuyerDatauserClientId = table.Column<int>(type: "int", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.userId);
                    table.ForeignKey(
                        name: "FK_Users_SystemRoles_systemRoleId",
                        column: x => x.systemRoleId,
                        principalTable: "SystemRoles",
                        principalColumn: "systemRoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_UserClient_userBuyerDatauserClientId",
                        column: x => x.userBuyerDatauserClientId,
                        principalTable: "UserClient",
                        principalColumn: "userClientId");
                    table.ForeignKey(
                        name: "FK_Users_UserProfile_userProfileId",
                        column: x => x.userProfileId,
                        principalTable: "UserProfile",
                        principalColumn: "userProfileId");
                });

            migrationBuilder.CreateTable(
                name: "ProductStores",
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
                        principalTable: "Colors",
                        principalColumn: "colorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductStores_Products_productId",
                        column: x => x.productId,
                        principalTable: "Products",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductStores_Units_unitId",
                        column: x => x.unitId,
                        principalTable: "Units",
                        principalColumn: "unitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_categoryId",
                table: "Products",
                column: "categoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductStores_colorId",
                table: "ProductStores",
                column: "colorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductStores_productId",
                table: "ProductStores",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductStores_unitId",
                table: "ProductStores",
                column: "unitId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_systemRoleId",
                table: "Users",
                column: "systemRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_userBuyerDatauserClientId",
                table: "Users",
                column: "userBuyerDatauserClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_userProfileId",
                table: "Users",
                column: "userProfileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "LogActions");

            migrationBuilder.DropTable(
                name: "ProductStores");

            migrationBuilder.DropTable(
                name: "Stores");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "SystemRoles");

            migrationBuilder.DropTable(
                name: "UserClient");

            migrationBuilder.DropTable(
                name: "UserProfile");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
