using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_Final.Migrations
{
    public partial class changedTeacherSkillTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TeacherSkill_TeacherId",
                table: "TeacherSkill");

            migrationBuilder.RenameColumn(
                name: "Skill",
                table: "TeacherSkill",
                newName: "Language");

            migrationBuilder.RenameColumn(
                name: "Percent",
                table: "TeacherSkill",
                newName: "TeamLeader");

            migrationBuilder.AddColumn<double>(
                name: "Communication",
                table: "TeacherSkill",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Design",
                table: "TeacherSkill",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Development",
                table: "TeacherSkill",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Innovation",
                table: "TeacherSkill",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

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
                name: "IX_TeacherSkill_TeacherId",
                table: "TeacherSkill",
                column: "TeacherId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TeacherSkill_TeacherId",
                table: "TeacherSkill");

            migrationBuilder.DropColumn(
                name: "Communication",
                table: "TeacherSkill");

            migrationBuilder.DropColumn(
                name: "Design",
                table: "TeacherSkill");

            migrationBuilder.DropColumn(
                name: "Development",
                table: "TeacherSkill");

            migrationBuilder.DropColumn(
                name: "Innovation",
                table: "TeacherSkill");

            migrationBuilder.RenameColumn(
                name: "TeamLeader",
                table: "TeacherSkill",
                newName: "Percent");

            migrationBuilder.RenameColumn(
                name: "Language",
                table: "TeacherSkill",
                newName: "Skill");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "AdminRoleId",
                column: "ConcurrencyStamp",
                value: "1d5136f3-aff1-4f94-8ab8-b031b4b3eef4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "MemberRoleId",
                column: "ConcurrencyStamp",
                value: "1f66608e-7ace-4857-87a9-abdfe8e8107d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "SuperAdminRoleId",
                column: "ConcurrencyStamp",
                value: "5902f3cc-71b7-4662-9216-b10c0afc3660");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherSkill_TeacherId",
                table: "TeacherSkill",
                column: "TeacherId");
        }
    }
}
