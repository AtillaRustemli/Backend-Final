using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_Final.Migrations
{
    public partial class changedStartsColumnDataTypeToDateTimeInCourseFeatureTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Assesment",
                table: "CourseFeature",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ClassDuration",
                table: "CourseFeature",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Duration",
                table: "CourseFeature",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "CourseFeature",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SkillLevel",
                table: "CourseFeature",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Starts",
                table: "CourseFeature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Students",
                table: "CourseFeature",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Assesment",
                table: "CourseFeature");

            migrationBuilder.DropColumn(
                name: "ClassDuration",
                table: "CourseFeature");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "CourseFeature");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "CourseFeature");

            migrationBuilder.DropColumn(
                name: "SkillLevel",
                table: "CourseFeature");

            migrationBuilder.DropColumn(
                name: "Starts",
                table: "CourseFeature");

            migrationBuilder.DropColumn(
                name: "Students",
                table: "CourseFeature");
        }
    }
}
