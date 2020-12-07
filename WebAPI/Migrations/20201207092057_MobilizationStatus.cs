using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class MobilizationStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MobilizationStatusId",
                table: "Mobilizations",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MobilizationStatuses",
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
                    table.PrimaryKey("PK_MobilizationStatuses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mobilizations_MobilizationStatusId",
                table: "Mobilizations",
                column: "MobilizationStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mobilizations_MobilizationStatuses_MobilizationStatusId",
                table: "Mobilizations",
                column: "MobilizationStatusId",
                principalTable: "MobilizationStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mobilizations_MobilizationStatuses_MobilizationStatusId",
                table: "Mobilizations");

            migrationBuilder.DropTable(
                name: "MobilizationStatuses");

            migrationBuilder.DropIndex(
                name: "IX_Mobilizations_MobilizationStatusId",
                table: "Mobilizations");

            migrationBuilder.DropColumn(
                name: "MobilizationStatusId",
                table: "Mobilizations");
        }
    }
}
