using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class ChangesSubsciptionId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Subscriptions_subscriptionId",
                table: "Payments");

            migrationBuilder.RenameColumn(
                name: "subscriptionId",
                table: "Payments",
                newName: "SubscriptionId");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_subscriptionId",
                table: "Payments",
                newName: "IX_Payments_SubscriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Subscriptions_SubscriptionId",
                table: "Payments",
                column: "SubscriptionId",
                principalTable: "Subscriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Subscriptions_SubscriptionId",
                table: "Payments");

            migrationBuilder.RenameColumn(
                name: "SubscriptionId",
                table: "Payments",
                newName: "subscriptionId");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_SubscriptionId",
                table: "Payments",
                newName: "IX_Payments_subscriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Subscriptions_subscriptionId",
                table: "Payments",
                column: "subscriptionId",
                principalTable: "Subscriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
