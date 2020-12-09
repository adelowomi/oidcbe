using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class RenameRequestStatusTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_requestStatuses_RequestStatusId",
                table: "Requests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_requestStatuses",
                table: "requestStatuses");

            migrationBuilder.RenameTable(
                name: "requestStatuses",
                newName: "RequestStatuses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestStatuses",
                table: "RequestStatuses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_RequestStatuses_RequestStatusId",
                table: "Requests",
                column: "RequestStatusId",
                principalTable: "RequestStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_RequestStatuses_RequestStatusId",
                table: "Requests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestStatuses",
                table: "RequestStatuses");

            migrationBuilder.RenameTable(
                name: "RequestStatuses",
                newName: "requestStatuses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_requestStatuses",
                table: "requestStatuses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_requestStatuses_RequestStatusId",
                table: "Requests",
                column: "RequestStatusId",
                principalTable: "requestStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
