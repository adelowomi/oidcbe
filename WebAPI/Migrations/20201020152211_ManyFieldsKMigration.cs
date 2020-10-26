using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class ManyFieldsKMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUserDetails_AppUserTypes_AppUserTypeId",
                table: "AppUserDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_AppUserDetails_Genders_GenderId",
                table: "AppUserDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_AppUserDetails_AppUserDetailId",
                table: "Subscriptions");

            migrationBuilder.DropIndex(
                name: "IX_Subscriptions_AppUserDetailId",
                table: "Subscriptions");

            migrationBuilder.DropIndex(
                name: "IX_AppUserDetails_AppUserTypeId",
                table: "AppUserDetails");

            migrationBuilder.DropIndex(
                name: "IX_AppUserDetails_GenderId",
                table: "AppUserDetails");

            migrationBuilder.DropColumn(
                name: "AppUserDetailId",
                table: "Subscriptions");

            migrationBuilder.DropColumn(
                name: "AppUserTypeId",
                table: "AppUserDetails");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AppUserDetails");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "AppUserDetails");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AppUserDetails");

            migrationBuilder.DropColumn(
                name: "MiddleName",
                table: "AppUserDetails");

            migrationBuilder.DropColumn(
                name: "OTP",
                table: "AppUserDetails");

            migrationBuilder.DropColumn(
                name: "Token",
                table: "AppUserDetails");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppUserDetailId",
                table: "Subscriptions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AppUserTypeId",
                table: "AppUserDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AppUserDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                table: "AppUserDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AppUserDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "AppUserDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OTP",
                table: "AppUserDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "AppUserDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_AppUserDetailId",
                table: "Subscriptions",
                column: "AppUserDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserDetails_AppUserTypeId",
                table: "AppUserDetails",
                column: "AppUserTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserDetails_GenderId",
                table: "AppUserDetails",
                column: "GenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserDetails_AppUserTypes_AppUserTypeId",
                table: "AppUserDetails",
                column: "AppUserTypeId",
                principalTable: "AppUserTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserDetails_Genders_GenderId",
                table: "AppUserDetails",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_AppUserDetails_AppUserDetailId",
                table: "Subscriptions",
                column: "AppUserDetailId",
                principalTable: "AppUserDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
