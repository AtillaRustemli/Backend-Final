using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_Final.Migrations
{
    public partial class changedRolesSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "AdminRoleId", "edb5e069-e0f7-41d7-8291-d8927b218bac", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "MemberRoleId", "e766c0f8-c17a-4f81-8912-3931b0f7822f", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "SuperAdminRoleId", "72cf69a3-58d1-498a-ab35-3442db79dbbf", "SuperAdmin", "SUPERADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "AdminRoleId");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "MemberRoleId");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "SuperAdminRoleId");

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
    }
}
