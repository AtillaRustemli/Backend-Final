using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_Final.Migrations
{
    public partial class changedTagTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_Blog_BlogId",
                table: "Post");

            migrationBuilder.DropForeignKey(
                name: "FK_Tag_Blog_BlogId",
                table: "Tag");

            migrationBuilder.DropIndex(
                name: "IX_Tag_BlogId",
                table: "Tag");

            migrationBuilder.DropIndex(
                name: "IX_Post_BlogId",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "BlogId",
                table: "Tag");

            migrationBuilder.DropColumn(
                name: "BlogId",
                table: "Post");

            migrationBuilder.AlterColumn<string>(
                name: "Vimeo",
                table: "TeacherSocialMedia",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Twitter",
                table: "TeacherSocialMedia",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Pinterest",
                table: "TeacherSocialMedia",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Facebook",
                table: "TeacherSocialMedia",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Vimeo",
                table: "TeacherSocialMedia",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Twitter",
                table: "TeacherSocialMedia",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Pinterest",
                table: "TeacherSocialMedia",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Facebook",
                table: "TeacherSocialMedia",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BlogId",
                table: "Tag",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BlogId",
                table: "Post",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "AdminRoleId",
                column: "ConcurrencyStamp",
                value: "6105c220-a2dd-4ba2-a948-0a5fd38daaaf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "MemberRoleId",
                column: "ConcurrencyStamp",
                value: "d9d89f76-940a-4f1e-ad08-d133e6d1880e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "SuperAdminRoleId",
                column: "ConcurrencyStamp",
                value: "7dc55b5b-c05c-4c63-a151-67922459ab4b");

            migrationBuilder.CreateIndex(
                name: "IX_Tag_BlogId",
                table: "Tag",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_BlogId",
                table: "Post",
                column: "BlogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Blog_BlogId",
                table: "Post",
                column: "BlogId",
                principalTable: "Blog",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tag_Blog_BlogId",
                table: "Tag",
                column: "BlogId",
                principalTable: "Blog",
                principalColumn: "Id");
        }
    }
}
