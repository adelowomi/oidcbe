using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class AdjustmentInForumEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ForumMessages_Forums_ForumId",
                table: "ForumMessages");

            migrationBuilder.AlterColumn<int>(
                name: "ForumId",
                table: "ForumMessages",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ForumMessageTypeId",
                table: "ForumMessages",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ForumMessageType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    IsEnabled = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForumMessageType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ForumMessages_ForumMessageTypeId",
                table: "ForumMessages",
                column: "ForumMessageTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ForumMessages_Forums_ForumId",
                table: "ForumMessages",
                column: "ForumId",
                principalTable: "Forums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ForumMessages_ForumMessageType_ForumMessageTypeId",
                table: "ForumMessages",
                column: "ForumMessageTypeId",
                principalTable: "ForumMessageType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ForumMessages_Forums_ForumId",
                table: "ForumMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_ForumMessages_ForumMessageType_ForumMessageTypeId",
                table: "ForumMessages");

            migrationBuilder.DropTable(
                name: "ForumMessageType");

            migrationBuilder.DropIndex(
                name: "IX_ForumMessages_ForumMessageTypeId",
                table: "ForumMessages");

            migrationBuilder.DropColumn(
                name: "ForumMessageTypeId",
                table: "ForumMessages");

            migrationBuilder.AlterColumn<int>(
                name: "ForumId",
                table: "ForumMessages",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ForumMessages_Forums_ForumId",
                table: "ForumMessages",
                column: "ForumId",
                principalTable: "Forums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
