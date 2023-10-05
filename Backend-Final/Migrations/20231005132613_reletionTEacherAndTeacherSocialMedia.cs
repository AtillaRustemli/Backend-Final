using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_Final.Migrations
{
    public partial class reletionTEacherAndTeacherSocialMedia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TeacherSocialMedia_TeacherId",
                table: "TeacherSocialMedia");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherSocialMedia_TeacherId",
                table: "TeacherSocialMedia",
                column: "TeacherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TeacherSocialMedia_TeacherId",
                table: "TeacherSocialMedia");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherSocialMedia_TeacherId",
                table: "TeacherSocialMedia",
                column: "TeacherId",
                unique: true);
        }
    }
}
