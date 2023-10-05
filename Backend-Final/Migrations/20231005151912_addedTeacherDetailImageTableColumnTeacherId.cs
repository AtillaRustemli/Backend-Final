using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_Final.Migrations
{
    public partial class addedTeacherDetailImageTableColumnTeacherId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "TeacherDetailImage",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeacherDetailImage_TeacherId",
                table: "TeacherDetailImage",
                column: "TeacherId",
                unique: true,
                filter: "[TeacherId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherDetailImage_Teacher_TeacherId",
                table: "TeacherDetailImage",
                column: "TeacherId",
                principalTable: "Teacher",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherDetailImage_Teacher_TeacherId",
                table: "TeacherDetailImage");

            migrationBuilder.DropIndex(
                name: "IX_TeacherDetailImage_TeacherId",
                table: "TeacherDetailImage");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "TeacherDetailImage");
        }
    }
}
