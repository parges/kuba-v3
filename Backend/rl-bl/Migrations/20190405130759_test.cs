using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace kubaapi.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReviewChapter_Reviews_ReviewId",
                table: "ReviewChapter");

            migrationBuilder.DropForeignKey(
                name: "FK_ReviewQuestion_ReviewChapter_ReviewChapterId",
                table: "ReviewQuestion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReviewChapter",
                table: "ReviewChapter");

            migrationBuilder.RenameTable(
                name: "ReviewChapter",
                newName: "ReviewChapters");

            migrationBuilder.RenameIndex(
                name: "IX_ReviewChapter_ReviewId",
                table: "ReviewChapters",
                newName: "IX_ReviewChapters_ReviewId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReviewChapters",
                table: "ReviewChapters",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Anamnesen",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2019, 4, 5, 15, 7, 58, 871, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Testungen",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2019, 4, 5, 15, 7, 58, 865, DateTimeKind.Local));

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewChapters_Reviews_ReviewId",
                table: "ReviewChapters",
                column: "ReviewId",
                principalTable: "Reviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewQuestion_ReviewChapters_ReviewChapterId",
                table: "ReviewQuestion",
                column: "ReviewChapterId",
                principalTable: "ReviewChapters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReviewChapters_Reviews_ReviewId",
                table: "ReviewChapters");

            migrationBuilder.DropForeignKey(
                name: "FK_ReviewQuestion_ReviewChapters_ReviewChapterId",
                table: "ReviewQuestion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReviewChapters",
                table: "ReviewChapters");

            migrationBuilder.RenameTable(
                name: "ReviewChapters",
                newName: "ReviewChapter");

            migrationBuilder.RenameIndex(
                name: "IX_ReviewChapters_ReviewId",
                table: "ReviewChapter",
                newName: "IX_ReviewChapter_ReviewId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReviewChapter",
                table: "ReviewChapter",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Anamnesen",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2019, 4, 4, 19, 48, 38, 622, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Testungen",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2019, 4, 4, 19, 48, 38, 616, DateTimeKind.Local));

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewChapter_Reviews_ReviewId",
                table: "ReviewChapter",
                column: "ReviewId",
                principalTable: "Reviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewQuestion_ReviewChapter_ReviewChapterId",
                table: "ReviewQuestion",
                column: "ReviewChapterId",
                principalTable: "ReviewChapter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
