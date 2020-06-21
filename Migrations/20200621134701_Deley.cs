using Microsoft.EntityFrameworkCore.Migrations;

namespace TAPoster.Migrations
{
    public partial class Deley : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostDeley",
                table: "PostSetting");

            migrationBuilder.AddColumn<int>(
                name: "Deley",
                table: "UserSetting",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deley",
                table: "UserSetting");

            migrationBuilder.AddColumn<int>(
                name: "PostDeley",
                table: "PostSetting",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
