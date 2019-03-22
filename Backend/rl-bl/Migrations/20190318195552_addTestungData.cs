using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace kubaapi.Migrations
{
    public partial class addTestungData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TestungChapters",
                columns: new[] { "Id", "Name", "TestungId" },
                values: new object[,]
                {
                    { 1, "I. TESTS ZUR ÜBERPRÜFUNG DER GROBMOTORISCHEN KOORDINAION UND DES GLEICHGEWICHTS", 1 },
                    { 2, "II. TESTS ZUR MOTORISCHEN ENTWICKLUNG", 1 },
                    { 3, "III. TESTS ZUR ÜBERPRÜFUNG VON KLEINHIRNFUNKTIONEN", 1 }
                });

            migrationBuilder.UpdateData(
                table: "Testungen",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2019, 3, 18, 20, 55, 52, 568, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TestungChapters",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TestungChapters",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TestungChapters",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Testungen",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2019, 3, 18, 20, 33, 12, 781, DateTimeKind.Local));
        }
    }
}
