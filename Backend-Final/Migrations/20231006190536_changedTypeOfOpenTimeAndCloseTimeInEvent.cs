using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_Final.Migrations
{
    public partial class changedTypeOfOpenTimeAndCloseTimeInEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1238f080-e47a-4d46-91e2-778b5681f9aa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "171bcaea-0da9-4289-8de8-b5a37f75be51");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "80108fcb-149c-4ffd-aa72-33ba1001a4af");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                values: new object[] { "1238f080-e47a-4d46-91e2-778b5681f9aa", "356d6ddf-3228-4798-9793-90cfdf7577a8", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "171bcaea-0da9-4289-8de8-b5a37f75be51", "b6b15d2b-1b18-4799-8aba-186b4256a036", "SuperAdmin", "SUPERADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "80108fcb-149c-4ffd-aa72-33ba1001a4af", "542fab5d-8b9d-45c9-91db-589f8528172f", "Admin", "ADMIN" });
        }
    }
}
