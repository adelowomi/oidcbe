using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class AddedSomeProperties2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Offers_OfferId",
                table: "Payments");

            migrationBuilder.AddColumn<int>(
                name: "SubscriptionStatusId",
                table: "Subscriptions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsPaymentComplete",
                table: "Plots",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PlotStatusId",
                table: "Plots",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OfferId",
                table: "Payments",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "subscriptionId",
                table: "Payments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DocumentStatuses",
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
                    table.PrimaryKey("PK_DocumentStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlotStatus",
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
                    table.PrimaryKey("PK_PlotStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionStatuses",
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
                    table.PrimaryKey("PK_SubscriptionStatuses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_SubscriptionStatusId",
                table: "Subscriptions",
                column: "SubscriptionStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Plots_PlotStatusId",
                table: "Plots",
                column: "PlotStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_subscriptionId",
                table: "Payments",
                column: "subscriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Offers_OfferId",
                table: "Payments",
                column: "OfferId",
                principalTable: "Offers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Subscriptions_subscriptionId",
                table: "Payments",
                column: "subscriptionId",
                principalTable: "Subscriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Plots_PlotStatus_PlotStatusId",
                table: "Plots",
                column: "PlotStatusId",
                principalTable: "PlotStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_SubscriptionStatuses_SubscriptionStatusId",
                table: "Subscriptions",
                column: "SubscriptionStatusId",
                principalTable: "SubscriptionStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Offers_OfferId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Subscriptions_subscriptionId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Plots_PlotStatus_PlotStatusId",
                table: "Plots");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_SubscriptionStatuses_SubscriptionStatusId",
                table: "Subscriptions");

            migrationBuilder.DropTable(
                name: "DocumentStatuses");

            migrationBuilder.DropTable(
                name: "PlotStatus");

            migrationBuilder.DropTable(
                name: "SubscriptionStatuses");

            migrationBuilder.DropIndex(
                name: "IX_Subscriptions_SubscriptionStatusId",
                table: "Subscriptions");

            migrationBuilder.DropIndex(
                name: "IX_Plots_PlotStatusId",
                table: "Plots");

            migrationBuilder.DropIndex(
                name: "IX_Payments_subscriptionId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "SubscriptionStatusId",
                table: "Subscriptions");

            migrationBuilder.DropColumn(
                name: "IsPaymentComplete",
                table: "Plots");

            migrationBuilder.DropColumn(
                name: "PlotStatusId",
                table: "Plots");

            migrationBuilder.DropColumn(
                name: "subscriptionId",
                table: "Payments");

            migrationBuilder.AlterColumn<int>(
                name: "OfferId",
                table: "Payments",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Offers_OfferId",
                table: "Payments",
                column: "OfferId",
                principalTable: "Offers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
