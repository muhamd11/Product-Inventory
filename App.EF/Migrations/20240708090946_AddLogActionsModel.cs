using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace App.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddLogActionsModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LogActions",
                columns: table => new
                {
                    logActionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: false),
                    ModelName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    actionType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    oldActionData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    newActionData = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogActions", x => x.logActionId);
                    table.ForeignKey(
                        name: "FK_LogActions_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LogActions_userId",
                table: "LogActions",
                column: "userId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogActions");
        }
    }
}