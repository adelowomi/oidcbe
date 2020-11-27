using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class AddSomeMainModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "WorkOrders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "WorkOrders",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrders_AppUserId",
                table: "WorkOrders",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrders_AspNetUsers_AppUserId",
                table: "WorkOrders",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrders_AspNetUsers_AppUserId",
                table: "WorkOrders");

            migrationBuilder.DropIndex(
                name: "IX_WorkOrders_AppUserId",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "WorkOrders");
        }
    }
}
