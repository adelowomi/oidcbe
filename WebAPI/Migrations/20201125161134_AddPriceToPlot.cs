using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class AddPriceToPlot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Plots");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Plots",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Plots");

            migrationBuilder.AddColumn<double>(
                name: "Amount",
                table: "Plots",
                type: "float",
                nullable: true);
        }
    }
}
