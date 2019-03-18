using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace kubaapi.Migrations
{
    public partial class addTestungData3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChapterId",
                table: "TestungQuestions");

            migrationBuilder.UpdateData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 1,
                column: "TestungChapterId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 2,
                column: "TestungChapterId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 3,
                column: "TestungChapterId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 4,
                column: "TestungChapterId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Testungen",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2019, 3, 18, 21, 2, 30, 413, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChapterId",
                table: "TestungQuestions",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ChapterId", "TestungChapterId" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ChapterId", "TestungChapterId" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ChapterId", "TestungChapterId" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ChapterId", "TestungChapterId" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Testungen",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2019, 3, 18, 20, 57, 11, 783, DateTimeKind.Local));
        }
    }
}
