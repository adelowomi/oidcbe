using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class AddAmountToPlot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasAmount",
                table: "Plots");

            migrationBuilder.AddColumn<string>(
                name: "TrnxRef",
                table: "Payments",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrnxRef",
                table: "Payments");

            migrationBuilder.AddColumn<bool>(
                name: "HasAmount",
                table: "Plots",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
