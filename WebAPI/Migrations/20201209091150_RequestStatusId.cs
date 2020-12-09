using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class RequestStatusId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RequestStatusId",
                table: "Requests",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "requestStatuses",
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
                    table.PrimaryKey("PK_requestStatuses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Requests_RequestStatusId",
                table: "Requests",
                column: "RequestStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_requestStatuses_RequestStatusId",
                table: "Requests",
                column: "RequestStatusId",
                principalTable: "requestStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_requestStatuses_RequestStatusId",
                table: "Requests");

            migrationBuilder.DropTable(
                name: "requestStatuses");

            migrationBuilder.DropIndex(
                name: "IX_Requests_RequestStatusId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "RequestStatusId",
                table: "Requests");
        }
    }
}
