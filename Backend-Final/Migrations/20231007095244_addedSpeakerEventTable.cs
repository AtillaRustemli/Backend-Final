using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_Final.Migrations
{
    public partial class addedSpeakerEventTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Speakers_Event_EventId",
                table: "Speakers");

            migrationBuilder.DropIndex(
                name: "IX_Speakers_EventId",
                table: "Speakers");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Speakers");

            migrationBuilder.CreateTable(
                name: "SpeakerEvent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    SpeakerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpeakerEvent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpeakerEvent_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpeakerEvent_Speakers_SpeakerId",
                        column: x => x.SpeakerId,
                        principalTable: "Speakers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_SpeakerEvent_EventId",
                table: "SpeakerEvent",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_SpeakerEvent_SpeakerId",
                table: "SpeakerEvent",
                column: "SpeakerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpeakerEvent");

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Speakers",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "AdminRoleId",
                column: "ConcurrencyStamp",
                value: "edb5e069-e0f7-41d7-8291-d8927b218bac");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "MemberRoleId",
                column: "ConcurrencyStamp",
                value: "e766c0f8-c17a-4f81-8912-3931b0f7822f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "SuperAdminRoleId",
                column: "ConcurrencyStamp",
                value: "72cf69a3-58d1-498a-ab35-3442db79dbbf");

            migrationBuilder.CreateIndex(
                name: "IX_Speakers_EventId",
                table: "Speakers",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Speakers_Event_EventId",
                table: "Speakers",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "Id");
        }
    }
}
