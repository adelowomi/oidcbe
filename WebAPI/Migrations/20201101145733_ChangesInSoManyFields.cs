using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class ChangesInSoManyFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_NextOfKins_AppUserId",
                table: "NextOfKins");

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Plots",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Plots",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdentityDocument",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Plots_AppUserId",
                table: "Plots",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_NextOfKins_AppUserId",
                table: "NextOfKins",
                column: "AppUserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Plots_AspNetUsers_AppUserId",
                table: "Plots",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plots_AspNetUsers_AppUserId",
                table: "Plots");

            migrationBuilder.DropIndex(
                name: "IX_Plots_AppUserId",
                table: "Plots");

            migrationBuilder.DropIndex(
                name: "IX_NextOfKins_AppUserId",
                table: "NextOfKins");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Plots");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Plots");

            migrationBuilder.DropColumn(
                name: "IdentityDocument",
                table: "AspNetUsers");

            migrationBuilder.CreateIndex(
                name: "IX_NextOfKins_AppUserId",
                table: "NextOfKins",
                column: "AppUserId");
        }
    }
}
