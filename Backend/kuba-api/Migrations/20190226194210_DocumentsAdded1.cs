using Microsoft.EntityFrameworkCore.Migrations;

namespace kubaapi.Migrations
{
    public partial class DocumentsAdded1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Documents",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Anamnese" });

            migrationBuilder.InsertData(
                table: "Documents",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Testung" });

            migrationBuilder.InsertData(
                table: "Documents",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Report" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
