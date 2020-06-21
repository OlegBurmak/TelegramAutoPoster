using Microsoft.EntityFrameworkCore.Migrations;

namespace TAPoster.Migrations
{
    public partial class PostDeley : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PostDeley",
                table: "PostSetting",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostDeley",
                table: "PostSetting");
        }
    }
}
