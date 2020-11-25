using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class LinkedPlotToDocumentAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlotId",
                table: "Documents",
                nullable: false,
                defaultValue: 0);

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
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
