using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class AdjustForModelAddOTP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AppUserDetails_AppUserDetailId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Offers_OfferId",
                table: "Payments");

            migrationBuilder.DropTable(
                name: "AppUserDetails");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AppUserDetailId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AppUserDetailId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "OfferId",
                table: "Payments",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "OTPs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    IsEnabled = table.Column<bool>(nullable: false),
                    AppUserId = table.Column<int>(nullable: false),
                    Code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OTPs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OTPs_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OTPs_AppUserId",
                table: "OTPs",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Offers_OfferId",
                table: "Payments",
                column: "OfferId",
                principalTable: "Offers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Offers_OfferId",
                table: "Payments");

            migrationBuilder.DropTable(
                name: "OTPs");

            migrationBuilder.AlterColumn<int>(
                name: "OfferId",
                table: "Payments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "AppUserDetailId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AppUserDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    ProfilePhoto = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserDetails", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AppUserDetailId",
                table: "AspNetUsers",
                column: "AppUserDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AppUserDetails_AppUserDetailId",
                table: "AspNetUsers",
                column: "AppUserDetailId",
                principalTable: "AppUserDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Offers_OfferId",
                table: "Payments",
                column: "OfferId",
                principalTable: "Offers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
