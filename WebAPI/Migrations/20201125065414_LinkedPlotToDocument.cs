using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class LinkedPlotToDocument : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Plots",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Plots",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Plots",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Plots",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Plots",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Plots",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Plots",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Plots",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Plots",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Plots",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Plots",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Plots",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Plots",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Plots",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Plots",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Plots",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Plots",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Plots",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Plots",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Plots",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "PlotTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PlotTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PlotTypes",
                keyColumn: "Id",
                keyValue: 3);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PlotTypes",
                columns: new[] { "Id", "DateCreated", "DateModified", "IsEnabled", "Name" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "BRONZE" });

            migrationBuilder.InsertData(
                table: "PlotTypes",
                columns: new[] { "Id", "DateCreated", "DateModified", "IsEnabled", "Name" },
                values: new object[] { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "SILVER" });

            migrationBuilder.InsertData(
                table: "PlotTypes",
                columns: new[] { "Id", "DateCreated", "DateModified", "IsEnabled", "Name" },
                values: new object[] { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "GOLD" });

            migrationBuilder.InsertData(
                table: "Plots",
                columns: new[] { "Id", "Acres", "Address", "Amount", "AppUserId", "DateCreated", "DateModified", "HasAmount", "IsAvailable", "IsEnabled", "KilometerSquare", "Lattitude", "Longitude", "Name", "PlotTypeId" },
                values: new object[,]
                {
                    { 4, 30.0, "Block 8A Balogun Street, Orange Island", null, null, new DateTime(2020, 11, 25, 7, 50, 5, 535, DateTimeKind.Local).AddTicks(7900), new DateTime(2020, 11, 25, 7, 50, 5, 535, DateTimeKind.Local).AddTicks(7900), false, true, true, 0.0, 33.399999999999999, 45.899999999999999, "Plot 100C - Junea", 1 },
                    { 10, 30.0, "Block 8A Balogun Street, Orange Island", null, null, new DateTime(2020, 11, 25, 7, 50, 5, 535, DateTimeKind.Local).AddTicks(7920), new DateTime(2020, 11, 25, 7, 50, 5, 535, DateTimeKind.Local).AddTicks(7920), false, true, true, 0.0, 33.399999999999999, 45.899999999999999, "Plot 809 - Tallahassee", 3 },
                    { 9, 30.0, "Block 8A Balogun Street, Orange Island", null, null, new DateTime(2020, 11, 25, 7, 50, 5, 535, DateTimeKind.Local).AddTicks(7920), new DateTime(2020, 11, 25, 7, 50, 5, 535, DateTimeKind.Local).AddTicks(7920), false, true, true, 0.0, 33.399999999999999, 45.899999999999999, "Plot 812 - Dover", 3 },
                    { 5, 30.0, "Block 8A Balogun Street, Orange Island", null, null, new DateTime(2020, 11, 25, 7, 50, 5, 535, DateTimeKind.Local).AddTicks(7900), new DateTime(2020, 11, 25, 7, 50, 5, 535, DateTimeKind.Local).AddTicks(7900), false, true, true, 0.0, 33.399999999999999, 45.899999999999999, "Plot 610 - Anchorage", 3 },
                    { 2, 30.0, "Block 8A Balogun Street, Orange Island", null, null, new DateTime(2020, 11, 25, 7, 50, 5, 531, DateTimeKind.Local).AddTicks(6690), new DateTime(2020, 11, 25, 7, 50, 5, 535, DateTimeKind.Local).AddTicks(7320), false, true, true, 0.0, 33.399999999999999, 45.899999999999999, "Plot 126 - Arkansas", 3 },
                    { 20, 30.0, "Block 8A Balogun Street, Orange Island", null, null, new DateTime(2020, 11, 25, 7, 50, 5, 535, DateTimeKind.Local).AddTicks(7950), new DateTime(2020, 11, 25, 7, 50, 5, 535, DateTimeKind.Local).AddTicks(7950), false, true, true, 0.0, 33.399999999999999, 45.899999999999999, "Plot 121B - Madison", 2 },
                    { 19, 30.0, "Block 8A Balogun Street, Orange Island", null, null, new DateTime(2020, 11, 25, 7, 50, 5, 535, DateTimeKind.Local).AddTicks(7950), new DateTime(2020, 11, 25, 7, 50, 5, 535, DateTimeKind.Local).AddTicks(7950), false, true, true, 0.0, 33.399999999999999, 45.899999999999999, "Plot 122 - Virginia Campton", 2 },
                    { 14, 30.0, "Block 8A Balogun Street, Orange Island", null, null, new DateTime(2020, 11, 25, 7, 50, 5, 535, DateTimeKind.Local).AddTicks(7930), new DateTime(2020, 11, 25, 7, 50, 5, 535, DateTimeKind.Local).AddTicks(7930), false, true, true, 0.0, 33.399999999999999, 45.899999999999999, "Plot 100A - Boston Lansing", 2 },
                    { 13, 30.0, "Block 8A Balogun Street, Orange Island", null, null, new DateTime(2020, 11, 25, 7, 50, 5, 535, DateTimeKind.Local).AddTicks(7930), new DateTime(2020, 11, 25, 7, 50, 5, 535, DateTimeKind.Local).AddTicks(7930), false, true, true, 0.0, 33.399999999999999, 45.899999999999999, "Plot 103 - Des Moines", 2 },
                    { 12, 30.0, "Block 8A Balogun Street, Orange Island", null, null, new DateTime(2020, 11, 25, 7, 50, 5, 535, DateTimeKind.Local).AddTicks(7930), new DateTime(2020, 11, 25, 7, 50, 5, 535, DateTimeKind.Local).AddTicks(7930), false, true, true, 0.0, 33.399999999999999, 45.899999999999999, "Plot 113 - Topeka", 2 },
                    { 6, 30.0, "Block 8A Balogun Street, Orange Island", null, null, new DateTime(2020, 11, 25, 7, 50, 5, 535, DateTimeKind.Local).AddTicks(7910), new DateTime(2020, 11, 25, 7, 50, 5, 535, DateTimeKind.Local).AddTicks(7910), false, true, true, 0.0, 33.399999999999999, 45.899999999999999, "Plot 100B - Phonenix", 2 },
                    { 3, 30.0, "Block 8A Balogun Street, Orange Island", null, null, new DateTime(2020, 11, 25, 7, 50, 5, 535, DateTimeKind.Local).AddTicks(7880), new DateTime(2020, 11, 25, 7, 50, 5, 535, DateTimeKind.Local).AddTicks(7890), false, true, true, 0.0, 33.399999999999999, 45.899999999999999, "Plot 512 - Arizona", 2 },
                    { 61, 30.0, "1289 Road, Alabama Ogundaide Street, Orange Island", null, null, new DateTime(2020, 11, 25, 7, 50, 5, 535, DateTimeKind.Local).AddTicks(7950), new DateTime(2020, 11, 25, 7, 50, 5, 535, DateTimeKind.Local).AddTicks(7950), false, true, true, 0.0, 33.399999999999999, 45.899999999999999, "Plot 1289, Road 6B - Alabama", 1 },
                    { 18, 30.0, "Block 8A Balogun Street, Orange Island", null, null, new DateTime(2020, 11, 25, 7, 50, 5, 535, DateTimeKind.Local).AddTicks(7940), new DateTime(2020, 11, 25, 7, 50, 5, 535, DateTimeKind.Local).AddTicks(7950), false, true, true, 0.0, 33.399999999999999, 45.899999999999999, "Plot 111 - Cheyenne", 1 },
                    { 17, 30.0, "Block 8A Balogun Street, Orange Island", null, null, new DateTime(2020, 11, 25, 7, 50, 5, 535, DateTimeKind.Local).AddTicks(7940), new DateTime(2020, 11, 25, 7, 50, 5, 535, DateTimeKind.Local).AddTicks(7940), false, true, true, 0.0, 33.399999999999999, 45.899999999999999, "Plot 1960 - Augusta Manopolis", 1 },
                    { 16, 30.0, "Block 8A Balogun Street, Orange Island", null, null, new DateTime(2020, 11, 25, 7, 50, 5, 535, DateTimeKind.Local).AddTicks(7940), new DateTime(2020, 11, 25, 7, 50, 5, 535, DateTimeKind.Local).AddTicks(7940), false, true, true, 0.0, 33.399999999999999, 45.899999999999999, "Plot 197 - Nankling Tushe, West Bridge", 1 },
                    { 8, 30.0, "Block 8A Balogun Street, Orange Island", null, null, new DateTime(2020, 11, 25, 7, 50, 5, 535, DateTimeKind.Local).AddTicks(7910), new DateTime(2020, 11, 25, 7, 50, 5, 535, DateTimeKind.Local).AddTicks(7910), false, true, true, 0.0, 33.399999999999999, 45.899999999999999, "Plot 162 - Hartford", 1 },
                    { 7, 30.0, "Block 8A Balogun Street, Orange Island", null, null, new DateTime(2020, 11, 25, 7, 50, 5, 535, DateTimeKind.Local).AddTicks(7910), new DateTime(2020, 11, 25, 7, 50, 5, 535, DateTimeKind.Local).AddTicks(7910), false, true, true, 0.0, 33.399999999999999, 45.899999999999999, "Plot 181A - Sacramento", 1 },
                    { 11, 30.0, "Block 8A Balogun Street, Orange Island", null, null, new DateTime(2020, 11, 25, 7, 50, 5, 535, DateTimeKind.Local).AddTicks(7920), new DateTime(2020, 11, 25, 7, 50, 5, 535, DateTimeKind.Local).AddTicks(7920), false, true, true, 0.0, 33.399999999999999, 45.899999999999999, "Plot 132 - Honolulu)", 3 },
                    { 15, 30.0, "Block 8A Balogun Street, Orange Island", null, null, new DateTime(2020, 11, 25, 7, 50, 5, 535, DateTimeKind.Local).AddTicks(7940), new DateTime(2020, 11, 25, 7, 50, 5, 535, DateTimeKind.Local).AddTicks(7940), false, true, true, 0.0, 33.399999999999999, 45.899999999999999, "Plot 201 - Louisville", 3 }
                });
        }
    }
}
