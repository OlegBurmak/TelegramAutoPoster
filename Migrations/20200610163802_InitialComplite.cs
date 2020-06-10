using Microsoft.EntityFrameworkCore.Migrations;

namespace TAPoster.Migrations
{
    public partial class InitialComplite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WallId",
                table: "PostSetting");

            migrationBuilder.AddColumn<string>(
                name: "GroupUrl",
                table: "PostSetting",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GroupUrl",
                table: "PostSetting");

            migrationBuilder.AddColumn<string>(
                name: "WallId",
                table: "PostSetting",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
