using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class AddOrganizationTypeIdToAppUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrganizationTypeId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_OrganizationTypeId",
                table: "AspNetUsers",
                column: "OrganizationTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_OrganizationTypes_OrganizationTypeId",
                table: "AspNetUsers",
                column: "OrganizationTypeId",
                principalTable: "OrganizationTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_OrganizationTypes_OrganizationTypeId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_OrganizationTypeId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "OrganizationTypeId",
                table: "AspNetUsers");
        }
    }
}
