using Microsoft.EntityFrameworkCore.Migrations;

namespace anti_scam_backend.Migrations
{
    public partial class UpdateRelationshipUserFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_FileAttachments_CreatedBy",
                table: "FileAttachments",
                column: "CreatedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_FileAttachments_Users_CreatedBy",
                table: "FileAttachments",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileAttachments_Users_CreatedBy",
                table: "FileAttachments");

            migrationBuilder.DropIndex(
                name: "IX_FileAttachments_CreatedBy",
                table: "FileAttachments");
        }
    }
}
