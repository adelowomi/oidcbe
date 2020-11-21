using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class RemoveDocumentTypeIdFromDocument : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocumentTypes_AspNetUsers_AppUserId",
                table: "DocumentTypes");

            migrationBuilder.DropIndex(
                name: "IX_DocumentTypes_AppUserId",
                table: "DocumentTypes");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "DocumentTypes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "DocumentTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DocumentTypes_AppUserId",
                table: "DocumentTypes",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentTypes_AspNetUsers_AppUserId",
                table: "DocumentTypes",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
