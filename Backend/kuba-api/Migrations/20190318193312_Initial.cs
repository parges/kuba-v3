using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace kubaapi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Firstname = table.Column<string>(nullable: true),
                    Lastname = table.Column<string>(nullable: true),
                    Tele = table.Column<string>(nullable: true),
                    Birthday = table.Column<DateTime>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Avatar = table.Column<string>(nullable: true),
                    AnamneseDate = table.Column<DateTime>(nullable: true),
                    AnamnesePayed = table.Column<bool>(nullable: true),
                    DiagnostikDate = table.Column<DateTime>(nullable: true),
                    DiagnostikPayed = table.Column<bool>(nullable: true),
                    ElternDate = table.Column<DateTime>(nullable: true),
                    ElternPayed = table.Column<bool>(nullable: true),
                    ProblemHierarchy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "Testungen",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    PatientId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Testungen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Testungen_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TestungChapters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    TestungId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestungChapters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestungChapters_Testungen_TestungId",
                        column: x => x.TestungId,
                        principalTable: "Testungen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TestungQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(nullable: true),
                    Label = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    ChapterId = table.Column<int>(nullable: true),
                    TestungChapterId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestungQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestungQuestions_TestungChapters_TestungChapterId",
                        column: x => x.TestungChapterId,
                        principalTable: "TestungChapters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Address", "AnamneseDate", "AnamnesePayed", "Avatar", "Birthday", "DiagnostikDate", "DiagnostikPayed", "ElternDate", "ElternPayed", "Firstname", "Lastname", "ProblemHierarchy", "Tele" },
                values: new object[] { 1, null, null, null, null, new DateTime(1988, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Kleiner", "Hase", null, "0177123456" });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Address", "AnamneseDate", "AnamnesePayed", "Avatar", "Birthday", "DiagnostikDate", "DiagnostikPayed", "ElternDate", "ElternPayed", "Firstname", "Lastname", "ProblemHierarchy", "Tele" },
                values: new object[] { 2, null, null, null, null, new DateTime(1988, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Stefan", "Parge", null, "0177123457" });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Date", "Exercises", "Name", "PatientId", "Payed", "Reasons" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Liegestütze und dann Kaffee trinken", "Befundgespräch", 1, true, "Das war dringend notwendig" },
                    { 2, new DateTime(2019, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Liegestütze und dann Kaffee trinken", "1. Review", 1, true, "Das war dringend notwendig" },
                    { 3, new DateTime(2019, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Liegestütze und dann Kaffee trinken", "2. Review", 1, false, "Das war dringend notwendig" },
                    { 4, new DateTime(2019, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Liegestütze und dann Kaffee trinken", "Befundgespräch", 2, true, "Das war dringend notwendig" },
                    { 5, new DateTime(2019, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Liegestütze und dann Kaffee trinken", "1. Review", 2, false, "Das war dringend notwendig" },
                    { 6, new DateTime(2019, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Liegestütze und dann Kaffee trinken", "2. Review", 2, false, "Das war dringend notwendig" }
                });

            migrationBuilder.InsertData(
                table: "Testungen",
                columns: new[] { "Id", "Date", "Name", "PatientId" },
                values: new object[] { 1, new DateTime(2019, 3, 18, 20, 33, 12, 781, DateTimeKind.Local), "Erste Testung", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_PatientId",
                table: "Reviews",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_TestungChapters_TestungId",
                table: "TestungChapters",
                column: "TestungId");

            migrationBuilder.CreateIndex(
                name: "IX_Testungen_PatientId",
                table: "Testungen",
                column: "PatientId",
                unique: true,
                filter: "[PatientId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TestungQuestions_TestungChapterId",
                table: "TestungQuestions",
                column: "TestungChapterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "TestungQuestions");

            migrationBuilder.DropTable(
                name: "TestungChapters");

            migrationBuilder.DropTable(
                name: "Testungen");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
