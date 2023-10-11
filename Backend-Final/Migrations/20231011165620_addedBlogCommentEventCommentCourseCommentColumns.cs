using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_Final.Migrations
{
    public partial class addedBlogCommentEventCommentCourseCommentColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BlogComment",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CourseComment",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EventComment",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "AdminRoleId",
                column: "ConcurrencyStamp",
                value: "00646d12-c422-45d1-ae14-a87644f81d72");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "MemberRoleId",
                column: "ConcurrencyStamp",
                value: "cf5e70b0-825c-4f8c-968a-1317d2e61f2d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "SuperAdminRoleId",
                column: "ConcurrencyStamp",
                value: "a29bce52-c55a-49f4-9a24-8417cbc4c56c");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BlogComment",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "CourseComment",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "EventComment",
                table: "Comments");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "AdminRoleId",
                column: "ConcurrencyStamp",
                value: "9ad0e647-4935-43c6-a82b-278c791237c7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "MemberRoleId",
                column: "ConcurrencyStamp",
                value: "6f05470b-4f1e-4aa4-b3a3-a0c83e5e0037");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "SuperAdminRoleId",
                column: "ConcurrencyStamp",
                value: "2cb71a3b-696c-4750-9ca3-f8cb9820fe16");
        }
    }
}
