using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace kubaapi.Migrations
{
    public partial class addReviews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Payed = table.Column<bool>(nullable: false),
                    Exercises = table.Column<string>(nullable: true),
                    Reasons = table.Column<string>(nullable: true),
                    PatientId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 1,
                column: "Birthday",
                value: new DateTime(1988, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Date", "Exercises", "Name", "PatientId", "Payed", "Reasons" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Liegestütze und dann Kaffee trinken", "Befundgespräch", null, true, "Das war dringend notwendig" },
                    { 2, new DateTime(2019, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Liegestütze und dann Kaffee trinken", "1. Review", null, true, "Das war dringend notwendig" },
                    { 3, new DateTime(2019, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Liegestütze und dann Kaffee trinken", "2. Review", null, false, "Das war dringend notwendig" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_PatientId",
                table: "Reviews",
                column: "PatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Documents",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Anamnese" },
                    { 2, "Testung" },
                    { 3, "Report" }
                });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 1,
                column: "Birthday",
                value: new DateTime(1988, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
