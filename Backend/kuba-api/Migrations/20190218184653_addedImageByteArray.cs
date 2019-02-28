using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace kubaapi.Migrations
{
    public partial class addedImageByteArray : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Patients",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Birthday", "Firstname", "Image", "Lastname", "Tele" },
                values: new object[] { 1, new DateTime(1988, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kleiner", null, "Hase", "0177123456" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Patients");

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Birthday", "Firstname", "Lastname", "Tele" },
                values: new object[] { 1, new DateTime(1988, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kleiner", "Hase", "0177123456" });
        }
    }
}
