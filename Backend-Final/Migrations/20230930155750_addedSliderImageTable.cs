using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_Final.Migrations
{
    public partial class addedSliderImageTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SliderImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsMain = table.Column<bool>(type: "bit", nullable: false),
                    SliderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SliderImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SliderImage_Slider_SliderId",
                        column: x => x.SliderId,
                        principalTable: "Slider",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SliderImage_SliderId",
                table: "SliderImage",
                column: "SliderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SliderImage");
        }
    }
}
