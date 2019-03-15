using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace kubaapi.Migrations
{
    public partial class baseDataAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Testung",
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
                    table.PrimaryKey("PK_Testung", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TestungBaseChapter",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestungBaseChapter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TestungBaseData",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    TestungChapterId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestungBaseData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TestungDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataId = table.Column<int>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    TestungId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestungDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestungDetails_TestungBaseData_DataId",
                        column: x => x.DataId,
                        principalTable: "TestungBaseData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TestungDetails_Testung_TestungId",
                        column: x => x.TestungId,
                        principalTable: "Testung",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "TestungBaseChapter",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "I. TESTS ZUR ÜBERPRÜFUNG DER GROBMOTORISCHEN KOORDINAION UND DES GLEICHGEWICHTS" },
                    { 2, "II. TESTS ZUR MOTORISCHEN ENTWICKLUNG" },
                    { 3, "III. TESTS ZUR ÜBERPRÜFUNG VON KLEINHIRNFUNKTIONEN" }
                });

            migrationBuilder.InsertData(
                table: "TestungBaseData",
                columns: new[] { "Id", "Name", "TestungChapterId" },
                values: new object[,]
                {
                    { 1, "Aufrichten aus Rückenlage in den Stand", 1 },
                    { 2, "Aufrichten aus Bauchlage in den Stand", 1 },
                    { 3, "Romberg Test (Augen geöffnet)", 1 },
                    { 4, "", 1 },
                    { 5, "Romberg Test (Augen geschlossen)", 1 },
                    { 6, "Mann Test (Augen geöffnet)", 1 },
                    { 7, "Mann Test (Augen geschlossen)", 1 },
                    { 8, "Einbeinstand", 1 },
                    { 9, "Marschieren und Umdrehen", 1 },
                    { 10, "Zehenspitzengang (vorwärts)", 1 },
                    { 11, "Zehenspitzengang (rückwärts)", 1 },
                    { 12, "", 1 },
                    { 13, "Kriechen auf dem Bauch", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TestungDetails_DataId",
                table: "TestungDetails",
                column: "DataId");

            migrationBuilder.CreateIndex(
                name: "IX_TestungDetails_TestungId",
                table: "TestungDetails",
                column: "TestungId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestungBaseChapter");

            migrationBuilder.DropTable(
                name: "TestungDetails");

            migrationBuilder.DropTable(
                name: "TestungBaseData");

            migrationBuilder.DropTable(
                name: "Testung");
        }
    }
}
