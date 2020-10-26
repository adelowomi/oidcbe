using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class anothermigrationadding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AppUserTypes_AppUserTypeId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Genders_GenderId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AppUserTypeId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "GenderId",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Genders_GenderId",
                table: "AspNetUsers",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Genders_GenderId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "GenderId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AppUserTypeId",
                table: "AspNetUsers",
                column: "AppUserTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AppUserTypes_AppUserTypeId",
                table: "AspNetUsers",
                column: "AppUserTypeId",
                principalTable: "AppUserTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Genders_GenderId",
                table: "AspNetUsers",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
