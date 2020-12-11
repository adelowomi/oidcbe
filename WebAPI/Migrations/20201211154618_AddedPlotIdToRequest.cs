using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class AddedPlotIdToRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlotId",
                table: "Requests",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Requests_PlotId",
                table: "Requests",
                column: "PlotId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Plots_PlotId",
                table: "Requests",
                column: "PlotId",
                principalTable: "Plots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Plots_PlotId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_PlotId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "PlotId",
                table: "Requests");
        }
    }
}
