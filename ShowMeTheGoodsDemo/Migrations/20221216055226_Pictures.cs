using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShowMeTheGoodsDemo.Migrations
{
    public partial class Pictures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PictureLink",
                table: "EventsType",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PictureLink",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PictureLink",
                table: "EventsType");

            migrationBuilder.DropColumn(
                name: "PictureLink",
                table: "Events");
        }
    }
}
