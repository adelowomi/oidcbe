using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class WorkOrderStatusId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "WorkOrders",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkOrderStatusId",
                table: "WorkOrders",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "WorkOrderStatus",
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
                    table.PrimaryKey("PK_WorkOrderStatus", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrders_WorkOrderStatusId",
                table: "WorkOrders",
                column: "WorkOrderStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrders_WorkOrderStatus_WorkOrderStatusId",
                table: "WorkOrders",
                column: "WorkOrderStatusId",
                principalTable: "WorkOrderStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrders_WorkOrderStatus_WorkOrderStatusId",
                table: "WorkOrders");

            migrationBuilder.DropTable(
                name: "WorkOrderStatus");

            migrationBuilder.DropIndex(
                name: "IX_WorkOrders_WorkOrderStatusId",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "WorkOrderStatusId",
                table: "WorkOrders");
        }
    }
}
