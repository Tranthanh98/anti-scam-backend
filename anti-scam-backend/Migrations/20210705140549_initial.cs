using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace anti_scam_backend.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoleAdmins",
                keyColumns: new[] { "RoldId", "UserId" },
                keyValues: new object[] { 1, new Guid("20924cd5-bd2a-4375-a45f-c5299ef3ac02") });

            migrationBuilder.DeleteData(
                table: "RoleAdmins",
                keyColumns: new[] { "RoldId", "UserId" },
                keyValues: new object[] { 2, new Guid("20924cd5-bd2a-4375-a45f-c5299ef3ac02") });

            migrationBuilder.DeleteData(
                table: "RoleAdmins",
                keyColumns: new[] { "RoldId", "UserId" },
                keyValues: new object[] { 1, new Guid("57099f1e-99c0-43a8-a9a2-721fc1aeeacf") });

            migrationBuilder.DeleteData(
                table: "RoleAdmins",
                keyColumns: new[] { "RoldId", "UserId" },
                keyValues: new object[] { 2, new Guid("57099f1e-99c0-43a8-a9a2-721fc1aeeacf") });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("20924cd5-bd2a-4375-a45f-c5299ef3ac02"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("57099f1e-99c0-43a8-a9a2-721fc1aeeacf"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeValidate", "CreateBy", "Email", "IsActive", "IsAdmin", "JoinedDate", "Password", "Salt", "UserName" },
                values: new object[] { new Guid("8ed1e886-4cf9-494c-ba64-955a7e781827"), "123456", null, "Trantienthanh2412@gmail.com", true, true, new DateTimeOffset(new DateTime(2021, 7, 5, 14, 5, 48, 973, DateTimeKind.Unspecified).AddTicks(3290), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAEAACcQAAAAEBAPlUdwTj0sci7gABciifU0cXR+sD/GUUtK99iAzlEcmqzuCE4Z8TflzHN9Nv6+KQ==", "pscznq", "Admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeValidate", "CreateBy", "Email", "IsActive", "IsAdmin", "JoinedDate", "Password", "Salt", "UserName" },
                values: new object[] { new Guid("5c01f99e-8db9-4947-869a-14b711167611"), "123456", null, "antiscam.contact@gmail.com", true, true, new DateTimeOffset(new DateTime(2021, 7, 5, 14, 5, 48, 973, DateTimeKind.Unspecified).AddTicks(9660), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAEAACcQAAAAEBAPlUdwTj0sci7gABciifU0cXR+sD/GUUtK99iAzlEcmqzuCE4Z8TflzHN9Nv6+KQ==", "pscznq", "Admin" });

            migrationBuilder.InsertData(
                table: "RoleAdmins",
                columns: new[] { "RoldId", "UserId" },
                values: new object[,]
                {
                    { 1, new Guid("8ed1e886-4cf9-494c-ba64-955a7e781827") },
                    { 2, new Guid("8ed1e886-4cf9-494c-ba64-955a7e781827") },
                    { 1, new Guid("5c01f99e-8db9-4947-869a-14b711167611") },
                    { 2, new Guid("5c01f99e-8db9-4947-869a-14b711167611") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoleAdmins",
                keyColumns: new[] { "RoldId", "UserId" },
                keyValues: new object[] { 1, new Guid("5c01f99e-8db9-4947-869a-14b711167611") });

            migrationBuilder.DeleteData(
                table: "RoleAdmins",
                keyColumns: new[] { "RoldId", "UserId" },
                keyValues: new object[] { 2, new Guid("5c01f99e-8db9-4947-869a-14b711167611") });

            migrationBuilder.DeleteData(
                table: "RoleAdmins",
                keyColumns: new[] { "RoldId", "UserId" },
                keyValues: new object[] { 1, new Guid("8ed1e886-4cf9-494c-ba64-955a7e781827") });

            migrationBuilder.DeleteData(
                table: "RoleAdmins",
                keyColumns: new[] { "RoldId", "UserId" },
                keyValues: new object[] { 2, new Guid("8ed1e886-4cf9-494c-ba64-955a7e781827") });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5c01f99e-8db9-4947-869a-14b711167611"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8ed1e886-4cf9-494c-ba64-955a7e781827"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeValidate", "CreateBy", "Email", "IsActive", "IsAdmin", "JoinedDate", "Password", "Salt", "UserName" },
                values: new object[] { new Guid("57099f1e-99c0-43a8-a9a2-721fc1aeeacf"), "123456", null, "Trantienthanh2412@gmail.com", true, true, new DateTimeOffset(new DateTime(2021, 6, 6, 9, 38, 50, 58, DateTimeKind.Unspecified).AddTicks(8727), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAEAACcQAAAAEBAPlUdwTj0sci7gABciifU0cXR+sD/GUUtK99iAzlEcmqzuCE4Z8TflzHN9Nv6+KQ==", "pscznq", "Admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeValidate", "CreateBy", "Email", "IsActive", "IsAdmin", "JoinedDate", "Password", "Salt", "UserName" },
                values: new object[] { new Guid("20924cd5-bd2a-4375-a45f-c5299ef3ac02"), "123456", null, "antiscam.contact@gmail.com", true, true, new DateTimeOffset(new DateTime(2021, 6, 6, 9, 38, 50, 59, DateTimeKind.Unspecified).AddTicks(2081), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAEAACcQAAAAEBAPlUdwTj0sci7gABciifU0cXR+sD/GUUtK99iAzlEcmqzuCE4Z8TflzHN9Nv6+KQ==", "pscznq", "Admin" });

            migrationBuilder.InsertData(
                table: "RoleAdmins",
                columns: new[] { "RoldId", "UserId" },
                values: new object[,]
                {
                    { 1, new Guid("57099f1e-99c0-43a8-a9a2-721fc1aeeacf") },
                    { 2, new Guid("57099f1e-99c0-43a8-a9a2-721fc1aeeacf") },
                    { 1, new Guid("20924cd5-bd2a-4375-a45f-c5299ef3ac02") },
                    { 2, new Guid("20924cd5-bd2a-4375-a45f-c5299ef3ac02") }
                });
        }
    }
}
