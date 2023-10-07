using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_Final.Migrations
{
    public partial class changedTeacherSocialMediaTableAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TeacherSocialMedia_TeacherId",
                table: "TeacherSocialMedia");

            migrationBuilder.RenameColumn(
                name: "NameUrl",
                table: "TeacherSocialMedia",
                newName: "Vimeo");

            migrationBuilder.RenameColumn(
                name: "Icon",
                table: "TeacherSocialMedia",
                newName: "Twitter");

            migrationBuilder.AddColumn<string>(
                name: "Facebook",
                table: "TeacherSocialMedia",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Pinterest",
                table: "TeacherSocialMedia",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
                name: "IX_TeacherSocialMedia_TeacherId",
                table: "TeacherSocialMedia",
                column: "TeacherId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TeacherSocialMedia_TeacherId",
                table: "TeacherSocialMedia");

            migrationBuilder.DropColumn(
                name: "Facebook",
                table: "TeacherSocialMedia");

            migrationBuilder.DropColumn(
                name: "Pinterest",
                table: "TeacherSocialMedia");

            migrationBuilder.RenameColumn(
                name: "Vimeo",
                table: "TeacherSocialMedia",
                newName: "NameUrl");

            migrationBuilder.RenameColumn(
                name: "Twitter",
                table: "TeacherSocialMedia",
                newName: "Icon");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "AdminRoleId",
                column: "ConcurrencyStamp",
                value: "8c823498-5fc0-4a49-9db1-43a75920a9c0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "MemberRoleId",
                column: "ConcurrencyStamp",
                value: "48243fe4-e204-42b9-9547-725e17d4c6de");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "SuperAdminRoleId",
                column: "ConcurrencyStamp",
                value: "b9136d62-27d1-4b21-8e62-e7fa89284328");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherSocialMedia_TeacherId",
                table: "TeacherSocialMedia",
                column: "TeacherId");
        }
    }
}
