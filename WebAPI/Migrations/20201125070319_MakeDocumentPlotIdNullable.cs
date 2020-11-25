using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class MakeDocumentPlotIdNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Plots_PlotId",
                table: "Documents");

            migrationBuilder.AlterColumn<int>(
                name: "PlotId",
                table: "Documents",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Plots_PlotId",
                table: "Documents",
                column: "PlotId",
                principalTable: "Plots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Plots_PlotId",
                table: "Documents");

            migrationBuilder.AlterColumn<int>(
                name: "PlotId",
                table: "Documents",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Plots_PlotId",
                table: "Documents",
                column: "PlotId",
                principalTable: "Plots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
