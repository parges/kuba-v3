using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace kubaapi.Migrations
{
    public partial class newCols : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Patients",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AnamneseDate",
                table: "Patients",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AnamnesePayed",
                table: "Patients",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DiagnostikDate",
                table: "Patients",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "DiagnostikPayed",
                table: "Patients",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ElternDate",
                table: "Patients",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ElternPayed",
                table: "Patients",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProblemHierarchy",
                table: "Patients",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "AnamneseDate",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "AnamnesePayed",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "DiagnostikDate",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "DiagnostikPayed",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "ElternDate",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "ElternPayed",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "ProblemHierarchy",
                table: "Patients");
        }
    }
}
