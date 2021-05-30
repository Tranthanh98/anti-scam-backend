using Microsoft.EntityFrameworkCore.Migrations;

namespace anti_scam_backend.Migrations
{
    public partial class AddPrimaryKeyTypePost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TypePosts",
                table: "TypePosts");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "TypePosts",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypePosts",
                table: "TypePosts",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TypePosts_PostId",
                table: "TypePosts",
                column: "PostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TypePosts",
                table: "TypePosts");

            migrationBuilder.DropIndex(
                name: "IX_TypePosts_PostId",
                table: "TypePosts");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "TypePosts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypePosts",
                table: "TypePosts",
                columns: new[] { "PostId", "TypeId" });
        }
    }
}
