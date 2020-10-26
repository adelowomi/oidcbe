using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class removesomemodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdentificationId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Identification",
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
                    table.PrimaryKey("PK_Identification", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_IdentificationId",
                table: "AspNetUsers",
                column: "IdentificationId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Identification_IdentificationId",
                table: "AspNetUsers",
                column: "IdentificationId",
                principalTable: "Identification",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Identification_IdentificationId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Identification");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_IdentificationId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IdentificationId",
                table: "AspNetUsers");
        }
    }
}
