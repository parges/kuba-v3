using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace kubaapi.Migrations
{
    public partial class AddProblemhierarchy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "initialValue",
                table: "ProblemHierarchie",
                newName: "InitialValue");

            migrationBuilder.RenameColumn(
                name: "changedValue",
                table: "ProblemHierarchie",
                newName: "ChangedValue");

            migrationBuilder.UpdateData(
                table: "Anamnesen",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2019, 4, 4, 19, 48, 38, 622, DateTimeKind.Local));

            migrationBuilder.InsertData(
                table: "ProblemHierarchie",
                columns: new[] { "Id", "ChangedValue", "InitialValue", "ReviewId" },
                values: new object[,]
                {
                    { 1, null, null, 53 },
                    { 2, null, null, 53 },
                    { 3, null, null, 53 }
                });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExerciseAccomplishment", "ObservationsChild", "ObservationsParents" },
                values: new object[] { "Medium ...", "Meinung Kind", "Meinung Eltern" });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ExerciseAccomplishment", "ObservationsChild", "ObservationsParents" },
                values: new object[] { "Medium ...", "Meinung Kind", "Meinung Eltern" });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ExerciseAccomplishment", "ObservationsChild", "ObservationsParents" },
                values: new object[] { "Medium ...", "Meinung Kind", "Meinung Eltern" });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ExerciseAccomplishment", "ObservationsChild", "ObservationsParents" },
                values: new object[] { "Medium ...", "Meinung Kind", "Meinung Eltern" });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ExerciseAccomplishment", "ObservationsChild", "ObservationsParents" },
                values: new object[] { "Medium ...", "Meinung Kind", "Meinung Eltern" });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ExerciseAccomplishment", "ObservationsChild", "ObservationsParents" },
                values: new object[] { "Medium ...", "Meinung Kind", "Meinung Eltern" });

            migrationBuilder.UpdateData(
                table: "Testungen",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2019, 4, 4, 19, 48, 38, 616, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProblemHierarchie",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProblemHierarchie",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProblemHierarchie",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameColumn(
                name: "InitialValue",
                table: "ProblemHierarchie",
                newName: "initialValue");

            migrationBuilder.RenameColumn(
                name: "ChangedValue",
                table: "ProblemHierarchie",
                newName: "changedValue");

            migrationBuilder.UpdateData(
                table: "Anamnesen",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2019, 4, 4, 15, 6, 20, 780, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExerciseAccomplishment", "ObservationsChild", "ObservationsParents" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ExerciseAccomplishment", "ObservationsChild", "ObservationsParents" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ExerciseAccomplishment", "ObservationsChild", "ObservationsParents" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ExerciseAccomplishment", "ObservationsChild", "ObservationsParents" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ExerciseAccomplishment", "ObservationsChild", "ObservationsParents" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ExerciseAccomplishment", "ObservationsChild", "ObservationsParents" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Testungen",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2019, 4, 4, 15, 6, 20, 773, DateTimeKind.Local));
        }
    }
}
