using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace anti_scam_backend.Migrations
{
    public partial class EditRoleSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoleAdmins",
                keyColumns: new[] { "RoldId", "UserId" },
                keyValues: new object[] { 1, new Guid("a4d805cd-278a-4e0f-814d-19d211933003") });

            migrationBuilder.DeleteData(
                table: "RoleAdmins",
                keyColumns: new[] { "RoldId", "UserId" },
                keyValues: new object[] { 2, new Guid("a4d805cd-278a-4e0f-814d-19d211933003") });

            migrationBuilder.DeleteData(
                table: "RoleAdmins",
                keyColumns: new[] { "RoldId", "UserId" },
                keyValues: new object[] { 1, new Guid("dc9e70ba-508d-476a-9981-624554c24986") });

            migrationBuilder.DeleteData(
                table: "RoleAdmins",
                keyColumns: new[] { "RoldId", "UserId" },
                keyValues: new object[] { 2, new Guid("dc9e70ba-508d-476a-9981-624554c24986") });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a4d805cd-278a-4e0f-814d-19d211933003"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("dc9e70ba-508d-476a-9981-624554c24986"));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Quản trị hệ thống", "SystemManager" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Quản trị nội dung", "ContentManger" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeValidate", "Email", "IsActive", "IsAdmin", "JoinedDate", "Password", "Salt", "UserName" },
                values: new object[,]
                {
                    { new Guid("3e9e260c-071a-4a9b-a8b7-2f1b880a5fa4"), "123456", "Trantienthanh2412@gmail.com", true, true, new DateTimeOffset(new DateTime(2021, 5, 31, 13, 40, 48, 357, DateTimeKind.Unspecified).AddTicks(143), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAEAACcQAAAAEBAPlUdwTj0sci7gABciifU0cXR+sD/GUUtK99iAzlEcmqzuCE4Z8TflzHN9Nv6+KQ==", "pscznq", "Admin" },
                    { new Guid("0676c0ea-a020-4386-9094-5bb322c07181"), "123456", "antiscam.contact@gmail.comm", true, true, new DateTimeOffset(new DateTime(2021, 5, 31, 13, 40, 48, 357, DateTimeKind.Unspecified).AddTicks(3623), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAEAACcQAAAAEBAPlUdwTj0sci7gABciifU0cXR+sD/GUUtK99iAzlEcmqzuCE4Z8TflzHN9Nv6+KQ==", "pscznq", "Admin" }
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { null, "Quản trị hệ thống" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name" },
                values: new object[] { null, "Quản trị nội dung" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeValidate", "Email", "IsActive", "IsAdmin", "JoinedDate", "Password", "Salt", "UserName" },
                values: new object[,]
                {
                    { new Guid("a4d805cd-278a-4e0f-814d-19d211933003"), "123456", "Trantienthanh2412@gmail.com", true, true, new DateTimeOffset(new DateTime(2021, 5, 31, 10, 31, 15, 701, DateTimeKind.Unspecified).AddTicks(2564), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAEAACcQAAAAEBAPlUdwTj0sci7gABciifU0cXR+sD/GUUtK99iAzlEcmqzuCE4Z8TflzHN9Nv6+KQ==", "pscznq", "Admin" },
                    { new Guid("dc9e70ba-508d-476a-9981-624554c24986"), "123456", "antiscam.contact@gmail.comm", true, true, new DateTimeOffset(new DateTime(2021, 5, 31, 10, 31, 15, 701, DateTimeKind.Unspecified).AddTicks(7456), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAEAACcQAAAAEBAPlUdwTj0sci7gABciifU0cXR+sD/GUUtK99iAzlEcmqzuCE4Z8TflzHN9Nv6+KQ==", "pscznq", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "RoleAdmins",
                columns: new[] { "RoldId", "UserId" },
                values: new object[,]
                {
                    { 1, new Guid("a4d805cd-278a-4e0f-814d-19d211933003") },
                    { 2, new Guid("a4d805cd-278a-4e0f-814d-19d211933003") },
                    { 1, new Guid("dc9e70ba-508d-476a-9981-624554c24986") },
                    { 2, new Guid("dc9e70ba-508d-476a-9981-624554c24986") }
                });
        }
    }
}
