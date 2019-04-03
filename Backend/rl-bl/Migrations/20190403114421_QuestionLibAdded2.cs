using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace kubaapi.Migrations
{
    public partial class QuestionLibAdded2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GenericChapters_Reviews_ReviewId",
                table: "GenericChapters");

            migrationBuilder.DropIndex(
                name: "IX_GenericChapters_ReviewId",
                table: "GenericChapters");

            migrationBuilder.DropColumn(
                name: "ReviewId",
                table: "GenericChapters");

            migrationBuilder.CreateTable(
                name: "ReviewChapter",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Score = table.Column<int>(nullable: true),
                    ReviewId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewChapter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReviewChapter_Reviews_ReviewId",
                        column: x => x.ReviewId,
                        principalTable: "Reviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReviewQuestion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(nullable: true),
                    Label = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    ReviewChapterId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReviewQuestion_ReviewChapter_ReviewChapterId",
                        column: x => x.ReviewChapterId,
                        principalTable: "ReviewChapter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Anamnesen",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2019, 4, 3, 13, 44, 21, 546, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Testungen",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2019, 4, 3, 13, 44, 21, 540, DateTimeKind.Local));

            migrationBuilder.CreateIndex(
                name: "IX_ReviewChapter_ReviewId",
                table: "ReviewChapter",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewQuestion_ReviewChapterId",
                table: "ReviewQuestion",
                column: "ReviewChapterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReviewQuestion");

            migrationBuilder.DropTable(
                name: "ReviewChapter");

            migrationBuilder.AddColumn<int>(
                name: "ReviewId",
                table: "GenericChapters",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Anamnesen",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2019, 4, 3, 13, 39, 52, 118, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Testungen",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2019, 4, 3, 13, 39, 52, 113, DateTimeKind.Local));

            migrationBuilder.CreateIndex(
                name: "IX_GenericChapters_ReviewId",
                table: "GenericChapters",
                column: "ReviewId");

            migrationBuilder.AddForeignKey(
                name: "FK_GenericChapters_Reviews_ReviewId",
                table: "GenericChapters",
                column: "ReviewId",
                principalTable: "Reviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
