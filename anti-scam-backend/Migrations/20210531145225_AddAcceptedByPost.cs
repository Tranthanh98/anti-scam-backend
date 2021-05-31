using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace anti_scam_backend.Migrations
{
    public partial class AddAcceptedByPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoleAdmins",
                keyColumns: new[] { "RoldId", "UserId" },
                keyValues: new object[] { 1, new Guid("4a78990a-99a0-4d52-bb7f-a673980cb3d2") });

            migrationBuilder.DeleteData(
                table: "RoleAdmins",
                keyColumns: new[] { "RoldId", "UserId" },
                keyValues: new object[] { 2, new Guid("4a78990a-99a0-4d52-bb7f-a673980cb3d2") });

            migrationBuilder.DeleteData(
                table: "RoleAdmins",
                keyColumns: new[] { "RoldId", "UserId" },
                keyValues: new object[] { 1, new Guid("53badd43-670c-4b69-a4de-e6df33199cd3") });

            migrationBuilder.DeleteData(
                table: "RoleAdmins",
                keyColumns: new[] { "RoldId", "UserId" },
                keyValues: new object[] { 2, new Guid("53badd43-670c-4b69-a4de-e6df33199cd3") });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4a78990a-99a0-4d52-bb7f-a673980cb3d2"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("53badd43-670c-4b69-a4de-e6df33199cd3"));

            migrationBuilder.AddColumn<Guid>(
                name: "AcceptedById",
                table: "Posts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeValidate", "Email", "IsActive", "IsAdmin", "JoinedDate", "Password", "Salt", "UserName" },
                values: new object[] { new Guid("9be6c423-9beb-4f9f-a779-d95fea720573"), "123456", "Trantienthanh2412@gmail.com", true, true, new DateTimeOffset(new DateTime(2021, 5, 31, 14, 52, 24, 125, DateTimeKind.Unspecified).AddTicks(7588), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAEAACcQAAAAEBAPlUdwTj0sci7gABciifU0cXR+sD/GUUtK99iAzlEcmqzuCE4Z8TflzHN9Nv6+KQ==", "pscznq", "Admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeValidate", "Email", "IsActive", "IsAdmin", "JoinedDate", "Password", "Salt", "UserName" },
                values: new object[] { new Guid("e9467e36-91ec-49b4-9013-4ff7cfbcfb19"), "123456", "antiscam.contact@gmail.comm", true, true, new DateTimeOffset(new DateTime(2021, 5, 31, 14, 52, 24, 126, DateTimeKind.Unspecified).AddTicks(1183), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAEAACcQAAAAEBAPlUdwTj0sci7gABciifU0cXR+sD/GUUtK99iAzlEcmqzuCE4Z8TflzHN9Nv6+KQ==", "pscznq", "Admin" });

            migrationBuilder.InsertData(
                table: "RoleAdmins",
                columns: new[] { "RoldId", "UserId" },
                values: new object[,]
                {
                    { 1, new Guid("9be6c423-9beb-4f9f-a779-d95fea720573") },
                    { 2, new Guid("9be6c423-9beb-4f9f-a779-d95fea720573") },
                    { 1, new Guid("e9467e36-91ec-49b4-9013-4ff7cfbcfb19") },
                    { 2, new Guid("e9467e36-91ec-49b4-9013-4ff7cfbcfb19") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_AcceptedById",
                table: "Posts",
                column: "AcceptedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_AcceptedById",
                table: "Posts",
                column: "AcceptedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_AcceptedById",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_AcceptedById",
                table: "Posts");

            migrationBuilder.DeleteData(
                table: "RoleAdmins",
                keyColumns: new[] { "RoldId", "UserId" },
                keyValues: new object[] { 1, new Guid("9be6c423-9beb-4f9f-a779-d95fea720573") });

            migrationBuilder.DeleteData(
                table: "RoleAdmins",
                keyColumns: new[] { "RoldId", "UserId" },
                keyValues: new object[] { 2, new Guid("9be6c423-9beb-4f9f-a779-d95fea720573") });

            migrationBuilder.DeleteData(
                table: "RoleAdmins",
                keyColumns: new[] { "RoldId", "UserId" },
                keyValues: new object[] { 1, new Guid("e9467e36-91ec-49b4-9013-4ff7cfbcfb19") });

            migrationBuilder.DeleteData(
                table: "RoleAdmins",
                keyColumns: new[] { "RoldId", "UserId" },
                keyValues: new object[] { 2, new Guid("e9467e36-91ec-49b4-9013-4ff7cfbcfb19") });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9be6c423-9beb-4f9f-a779-d95fea720573"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e9467e36-91ec-49b4-9013-4ff7cfbcfb19"));

            migrationBuilder.DropColumn(
                name: "AcceptedById",
                table: "Posts");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeValidate", "Email", "IsActive", "IsAdmin", "JoinedDate", "Password", "Salt", "UserName" },
                values: new object[] { new Guid("4a78990a-99a0-4d52-bb7f-a673980cb3d2"), "123456", "Trantienthanh2412@gmail.com", true, true, new DateTimeOffset(new DateTime(2021, 5, 31, 14, 21, 46, 911, DateTimeKind.Unspecified).AddTicks(3669), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAEAACcQAAAAEBAPlUdwTj0sci7gABciifU0cXR+sD/GUUtK99iAzlEcmqzuCE4Z8TflzHN9Nv6+KQ==", "pscznq", "Admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeValidate", "Email", "IsActive", "IsAdmin", "JoinedDate", "Password", "Salt", "UserName" },
                values: new object[] { new Guid("53badd43-670c-4b69-a4de-e6df33199cd3"), "123456", "antiscam.contact@gmail.comm", true, true, new DateTimeOffset(new DateTime(2021, 5, 31, 14, 21, 46, 911, DateTimeKind.Unspecified).AddTicks(7309), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAEAACcQAAAAEBAPlUdwTj0sci7gABciifU0cXR+sD/GUUtK99iAzlEcmqzuCE4Z8TflzHN9Nv6+KQ==", "pscznq", "Admin" });

            migrationBuilder.InsertData(
                table: "RoleAdmins",
                columns: new[] { "RoldId", "UserId" },
                values: new object[,]
                {
                    { 1, new Guid("4a78990a-99a0-4d52-bb7f-a673980cb3d2") },
                    { 2, new Guid("4a78990a-99a0-4d52-bb7f-a673980cb3d2") },
                    { 1, new Guid("53badd43-670c-4b69-a4de-e6df33199cd3") },
                    { 2, new Guid("53badd43-670c-4b69-a4de-e6df33199cd3") }
                });
        }
    }
}
