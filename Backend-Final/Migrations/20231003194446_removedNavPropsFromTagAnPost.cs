using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_Final.Migrations
{
    public partial class removedNavPropsFromTagAnPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tag_Blog_BlogId",
                table: "Tag");

            migrationBuilder.DropForeignKey(
                name: "FK_Tag_Course_CourseId",
                table: "Tag");

            migrationBuilder.DropForeignKey(
                name: "FK_Tag_Event_EventId",
                table: "Tag");

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "Tag",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "Tag",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BlogId",
                table: "Tag",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Tag_Blog_BlogId",
                table: "Tag",
                column: "BlogId",
                principalTable: "Blog",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tag_Course_CourseId",
                table: "Tag",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tag_Event_EventId",
                table: "Tag",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tag_Blog_BlogId",
                table: "Tag");

            migrationBuilder.DropForeignKey(
                name: "FK_Tag_Course_CourseId",
                table: "Tag");

            migrationBuilder.DropForeignKey(
                name: "FK_Tag_Event_EventId",
                table: "Tag");

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "Tag",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "Tag",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BlogId",
                table: "Tag",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tag_Blog_BlogId",
                table: "Tag",
                column: "BlogId",
                principalTable: "Blog",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tag_Course_CourseId",
                table: "Tag",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tag_Event_EventId",
                table: "Tag",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
