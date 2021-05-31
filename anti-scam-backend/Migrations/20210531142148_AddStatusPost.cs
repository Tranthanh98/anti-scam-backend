using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace anti_scam_backend.Migrations
{
    public partial class AddStatusPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoleAdmins",
                keyColumns: new[] { "RoldId", "UserId" },
                keyValues: new object[] { 1, new Guid("0676c0ea-a020-4386-9094-5bb322c07181") });

            migrationBuilder.DeleteData(
                table: "RoleAdmins",
                keyColumns: new[] { "RoldId", "UserId" },
                keyValues: new object[] { 2, new Guid("0676c0ea-a020-4386-9094-5bb322c07181") });

            migrationBuilder.DeleteData(
                table: "RoleAdmins",
                keyColumns: new[] { "RoldId", "UserId" },
                keyValues: new object[] { 1, new Guid("3e9e260c-071a-4a9b-a8b7-2f1b880a5fa4") });

            migrationBuilder.DeleteData(
                table: "RoleAdmins",
                keyColumns: new[] { "RoldId", "UserId" },
                keyValues: new object[] { 2, new Guid("3e9e260c-071a-4a9b-a8b7-2f1b880a5fa4") });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0676c0ea-a020-4386-9094-5bb322c07181"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3e9e260c-071a-4a9b-a8b7-2f1b880a5fa4"));

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Posts");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Posts");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Posts",
                type: "bit",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeValidate", "Email", "IsActive", "IsAdmin", "JoinedDate", "Password", "Salt", "UserName" },
                values: new object[] { new Guid("3e9e260c-071a-4a9b-a8b7-2f1b880a5fa4"), "123456", "Trantienthanh2412@gmail.com", true, true, new DateTimeOffset(new DateTime(2021, 5, 31, 13, 40, 48, 357, DateTimeKind.Unspecified).AddTicks(143), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAEAACcQAAAAEBAPlUdwTj0sci7gABciifU0cXR+sD/GUUtK99iAzlEcmqzuCE4Z8TflzHN9Nv6+KQ==", "pscznq", "Admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeValidate", "Email", "IsActive", "IsAdmin", "JoinedDate", "Password", "Salt", "UserName" },
                values: new object[] { new Guid("0676c0ea-a020-4386-9094-5bb322c07181"), "123456", "antiscam.contact@gmail.comm", true, true, new DateTimeOffset(new DateTime(2021, 5, 31, 13, 40, 48, 357, DateTimeKind.Unspecified).AddTicks(3623), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAEAACcQAAAAEBAPlUdwTj0sci7gABciifU0cXR+sD/GUUtK99iAzlEcmqzuCE4Z8TflzHN9Nv6+KQ==", "pscznq", "Admin" });

            migrationBuilder.InsertData(
                table: "RoleAdmins",
                columns: new[] { "RoldId", "UserId" },
                values: new object[,]
                {
                    { 1, new Guid("3e9e260c-071a-4a9b-a8b7-2f1b880a5fa4") },
                    { 2, new Guid("3e9e260c-071a-4a9b-a8b7-2f1b880a5fa4") },
                    { 1, new Guid("0676c0ea-a020-4386-9094-5bb322c07181") },
                    { 2, new Guid("0676c0ea-a020-4386-9094-5bb322c07181") }
                });
        }
    }
}
