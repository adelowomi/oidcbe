using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class AddedSomeCalendarFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Calendars",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Calendars",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Calendars",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Calendars",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Calendars");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Calendars");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Calendars");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Calendars");
        }
    }
}
