using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace kubaapi.Migrations
{
    public partial class addTestungData2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TestungQuestions",
                columns: new[] { "Id", "ChapterId", "Label", "TestungChapterId", "Type", "Value" },
                values: new object[,]
                {
                    { 1, 1, "Aufrichten aus Rückenlage in den Stand", null, "radio", "" },
                    { 2, 1, "Aufrichten aus Bauchlage in den Stand", null, "radio", "" },
                    { 3, 1, "Romberg Test (Augen geöffnet)", null, "radio", "" },
                    { 4, 1, "Tandem Gang (rückwärts)", null, "radio", "" }
                });

            migrationBuilder.UpdateData(
                table: "Testungen",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2019, 3, 18, 20, 57, 11, 783, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Testungen",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2019, 3, 18, 20, 55, 52, 568, DateTimeKind.Local));
        }
    }
}
