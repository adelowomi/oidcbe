using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class RemovedContactIdFromContactEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_ContactTypes_ContactTypeId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "ContactId",
                table: "Contacts");

            migrationBuilder.AlterColumn<int>(
                name: "ContactTypeId",
                table: "Contacts",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_ContactTypes_ContactTypeId",
                table: "Contacts",
                column: "ContactTypeId",
                principalTable: "ContactTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_ContactTypes_ContactTypeId",
                table: "Contacts");

            migrationBuilder.AlterColumn<int>(
                name: "ContactTypeId",
                table: "Contacts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ContactId",
                table: "Contacts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_ContactTypes_ContactTypeId",
                table: "Contacts",
                column: "ContactTypeId",
                principalTable: "ContactTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
