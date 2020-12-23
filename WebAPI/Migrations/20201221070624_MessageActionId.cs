using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class MessageActionId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Indicator",
                table: "Messages",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MessageActionId",
                table: "Messages",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MessageAction",
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
                    table.PrimaryKey("PK_MessageAction", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_MessageActionId",
                table: "Messages",
                column: "MessageActionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_MessageAction_MessageActionId",
                table: "Messages",
                column: "MessageActionId",
                principalTable: "MessageAction",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_MessageAction_MessageActionId",
                table: "Messages");

            migrationBuilder.DropTable(
                name: "MessageAction");

            migrationBuilder.DropIndex(
                name: "IX_Messages_MessageActionId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "Indicator",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "MessageActionId",
                table: "Messages");
        }
    }
}
