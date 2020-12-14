using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class AdjustmentInForumEntityAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ForumMessages_ForumMessageType_ForumMessageTypeId",
                table: "ForumMessages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ForumMessageType",
                table: "ForumMessageType");

            migrationBuilder.RenameTable(
                name: "ForumMessageType",
                newName: "ForumMessageTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ForumMessageTypes",
                table: "ForumMessageTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ForumMessages_ForumMessageTypes_ForumMessageTypeId",
                table: "ForumMessages",
                column: "ForumMessageTypeId",
                principalTable: "ForumMessageTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ForumMessages_ForumMessageTypes_ForumMessageTypeId",
                table: "ForumMessages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ForumMessageTypes",
                table: "ForumMessageTypes");

            migrationBuilder.RenameTable(
                name: "ForumMessageTypes",
                newName: "ForumMessageType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ForumMessageType",
                table: "ForumMessageType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ForumMessages_ForumMessageType_ForumMessageTypeId",
                table: "ForumMessages",
                column: "ForumMessageTypeId",
                principalTable: "ForumMessageType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
