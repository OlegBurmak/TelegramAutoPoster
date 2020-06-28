using Microsoft.EntityFrameworkCore.Migrations;

namespace TAPoster.Migrations
{
    public partial class VkPostItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VkPostItem",
                columns: table => new
                {
                    VkPostItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostType = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    Date = table.Column<string>(nullable: true),
                    TypeAttachment = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    Comment = table.Column<int>(nullable: false),
                    Like = table.Column<int>(nullable: false),
                    Reposts = table.Column<int>(nullable: false),
                    Views = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VkPostItem", x => x.VkPostItemId);
                    table.ForeignKey(
                        name: "FK_VkPostItem_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VkPostItem_UserId",
                table: "VkPostItem",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VkPostItem");
        }
    }
}
