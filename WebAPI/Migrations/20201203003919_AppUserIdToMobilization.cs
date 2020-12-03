using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class AppUserIdToMobilization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Mobilizations",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mobilizations_AppUserId",
                table: "Mobilizations",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mobilizations_AspNetUsers_AppUserId",
                table: "Mobilizations",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mobilizations_AspNetUsers_AppUserId",
                table: "Mobilizations");

            migrationBuilder.DropIndex(
                name: "IX_Mobilizations_AppUserId",
                table: "Mobilizations");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Mobilizations");
        }
    }
}
