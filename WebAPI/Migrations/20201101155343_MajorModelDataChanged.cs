using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class MajorModelDataChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Plots");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "NextOfKins");

            migrationBuilder.DropColumn(
                name: "AppUserTypeId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "NextOfKins",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                table: "NextOfKins",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NextOfKins_GenderId",
                table: "NextOfKins",
                column: "GenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_NextOfKins_Genders_GenderId",
                table: "NextOfKins",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NextOfKins_Genders_GenderId",
                table: "NextOfKins");

            migrationBuilder.DropIndex(
                name: "IX_NextOfKins_GenderId",
                table: "NextOfKins");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "NextOfKins");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "NextOfKins");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Plots",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "NextOfKins",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AppUserTypeId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
