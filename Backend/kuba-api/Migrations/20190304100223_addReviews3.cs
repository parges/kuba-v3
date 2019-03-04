using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace kubaapi.Migrations
{
    public partial class addReviews3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Avatar", "Birthday", "Firstname", "Lastname", "Tele" },
                values: new object[] { 2, null, new DateTime(1988, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stefan", "Parge", "0177123457" });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Date", "Exercises", "Name", "PatientId", "Payed", "Reasons" },
                values: new object[] { 4, new DateTime(2019, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Liegestütze und dann Kaffee trinken", "Befundgespräch", 2, true, "Das war dringend notwendig" });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Date", "Exercises", "Name", "PatientId", "Payed", "Reasons" },
                values: new object[] { 5, new DateTime(2019, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Liegestütze und dann Kaffee trinken", "1. Review", 2, false, "Das war dringend notwendig" });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Date", "Exercises", "Name", "PatientId", "Payed", "Reasons" },
                values: new object[] { 6, new DateTime(2019, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Liegestütze und dann Kaffee trinken", "2. Review", 2, false, "Das war dringend notwendig" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
