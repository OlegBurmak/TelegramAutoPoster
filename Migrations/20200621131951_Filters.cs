using Microsoft.EntityFrameworkCore.Migrations;

namespace TAPoster.Migrations
{
    public partial class Filters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PostItemComment",
                table: "PostSetting",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PostItemLike",
                table: "PostSetting",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PostItemRepost",
                table: "PostSetting",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PostItemView",
                table: "PostSetting",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostItemComment",
                table: "PostSetting");

            migrationBuilder.DropColumn(
                name: "PostItemLike",
                table: "PostSetting");

            migrationBuilder.DropColumn(
                name: "PostItemRepost",
                table: "PostSetting");

            migrationBuilder.DropColumn(
                name: "PostItemView",
                table: "PostSetting");
        }
    }
}
