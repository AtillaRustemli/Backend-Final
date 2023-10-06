using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_Final.Migrations
{
    public partial class deletedEventDetailImageTableAndDateColumnFromEventTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventDetailImage");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0366da04-719e-4a03-b9ea-bf93bb2d45dd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0cfceee5-7483-4720-885d-8041cae73c6b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "50a9c424-3538-4c5b-8f37-306cd9b6e5f6");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Event");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OpenTime",
                table: "Event",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CloseTime",
                table: "Event",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "15015732-86cd-42da-a6eb-4c73e26169fc", "cd2c428d-d0cb-4683-8e13-b6b53eeb30b2", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "29bce9d5-2dac-41ff-add5-59a7c6841a94", "a3b5e0b6-13a2-45a3-9986-bbf94eaad09d", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ceec4c83-73ab-4cd6-8989-01f66e5fccf1", "54d73a7a-b6e0-4205-a0d2-6f3e2d5ceeb2", "SuperAdmin", "SUPERADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "15015732-86cd-42da-a6eb-4c73e26169fc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bce9d5-2dac-41ff-add5-59a7c6841a94");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ceec4c83-73ab-4cd6-8989-01f66e5fccf1");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "OpenTime",
                table: "Event",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "CloseTime",
                table: "Event",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Event",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "EventDetailImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventDetailImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventDetailImage_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0366da04-719e-4a03-b9ea-bf93bb2d45dd", "3be3838c-2af0-41c4-83c7-fe94541ea017", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0cfceee5-7483-4720-885d-8041cae73c6b", "7e7fb945-1b8c-4095-83e2-94ccd14778a1", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "50a9c424-3538-4c5b-8f37-306cd9b6e5f6", "377a5ea8-690e-4be0-88aa-3dab73c9027f", "SuperAdmin", "SUPERADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_EventDetailImage_EventId",
                table: "EventDetailImage",
                column: "EventId",
                unique: true);
        }
    }
}
