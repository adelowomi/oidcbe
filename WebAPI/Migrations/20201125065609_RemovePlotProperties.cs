using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class RemovePlotProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Plots_PlotId",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_PlotId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "PlotId",
                table: "Documents");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlotId",
                table: "Documents",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Documents_PlotId",
                table: "Documents",
                column: "PlotId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Plots_PlotId",
                table: "Documents",
                column: "PlotId",
                principalTable: "Plots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
