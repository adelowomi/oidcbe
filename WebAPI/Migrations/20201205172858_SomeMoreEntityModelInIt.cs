using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class SomeMoreEntityModelInIt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_RequestTypes_RequestTypeId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "RequestId",
                table: "Requests");

            migrationBuilder.AlterColumn<int>(
                name: "RequestTypeId",
                table: "Requests",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Requests",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_RequestTypes_RequestTypeId",
                table: "Requests",
                column: "RequestTypeId",
                principalTable: "RequestTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_RequestTypes_RequestTypeId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Requests");

            migrationBuilder.AlterColumn<int>(
                name: "RequestTypeId",
                table: "Requests",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "RequestId",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_RequestTypes_RequestTypeId",
                table: "Requests",
                column: "RequestTypeId",
                principalTable: "RequestTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
