using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_Final.Migrations
{
    public partial class changedTeacherSocialMediaTablesssss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FaceBook",
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NameUrl",
                table: "TeacherSocialMedia",
                newName: "Vimeo");

            migrationBuilder.RenameColumn(
                name: "Icon",
                table: "TeacherSocialMedia",
                newName: "Twitter");

            migrationBuilder.AddColumn<string>(
                name: "FaceBook",
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
        }
    }
}
