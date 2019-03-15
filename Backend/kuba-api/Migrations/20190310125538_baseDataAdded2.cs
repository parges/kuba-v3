using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace kubaapi.Migrations
{
    public partial class baseDataAdded2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestungDetails_Testung_TestungId",
                table: "TestungDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Testung",
                table: "Testung");

            migrationBuilder.RenameTable(
                name: "Testung",
                newName: "Testungen");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Testungen",
                table: "Testungen",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "TestungBaseData",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Tandem Gang (rückwärts)");

            migrationBuilder.UpdateData(
                table: "TestungBaseData",
                keyColumn: "Id",
                keyValue: 12,
                column: "Name",
                value: "Tandem Gang (vorwärts)");

            migrationBuilder.InsertData(
                table: "Testungen",
                columns: new[] { "Id", "Date", "Name", "PatientId" },
                values: new object[] { 1, new DateTime(2019, 3, 10, 13, 55, 37, 912, DateTimeKind.Local), "Erste Testung", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Testungen_PatientId",
                table: "Testungen",
                column: "PatientId",
                unique: true,
                filter: "[PatientId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_TestungDetails_Testungen_TestungId",
                table: "TestungDetails",
                column: "TestungId",
                principalTable: "Testungen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Testungen_Patients_PatientId",
                table: "Testungen",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestungDetails_Testungen_TestungId",
                table: "TestungDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Testungen_Patients_PatientId",
                table: "Testungen");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Testungen",
                table: "Testungen");

            migrationBuilder.DropIndex(
                name: "IX_Testungen_PatientId",
                table: "Testungen");

            migrationBuilder.DeleteData(
                table: "Testungen",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameTable(
                name: "Testungen",
                newName: "Testung");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Testung",
                table: "Testung",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "TestungBaseData",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "");

            migrationBuilder.UpdateData(
                table: "TestungBaseData",
                keyColumn: "Id",
                keyValue: 12,
                column: "Name",
                value: "");

            migrationBuilder.AddForeignKey(
                name: "FK_TestungDetails_Testung_TestungId",
                table: "TestungDetails",
                column: "TestungId",
                principalTable: "Testung",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
