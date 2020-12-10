using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class AddingNextOfKinBack : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_NextOfKins_AppUserId",
                table: "NextOfKins");

            migrationBuilder.CreateIndex(
                name: "IX_NextOfKins_AppUserId",
                table: "NextOfKins",
                column: "AppUserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_NextOfKins_AppUserId",
                table: "NextOfKins");

            migrationBuilder.CreateIndex(
                name: "IX_NextOfKins_AppUserId",
                table: "NextOfKins",
                column: "AppUserId");
        }
    }
}
