using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace anti_scam_backend.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoleAdmins",
                keyColumns: new[] { "RoldId", "UserId" },
                keyValues: new object[] { 1, new Guid("44f6e86e-e8ac-405b-b2c0-dd8b9423cf47") });

            migrationBuilder.DeleteData(
                table: "RoleAdmins",
                keyColumns: new[] { "RoldId", "UserId" },
                keyValues: new object[] { 2, new Guid("44f6e86e-e8ac-405b-b2c0-dd8b9423cf47") });

            migrationBuilder.DeleteData(
                table: "RoleAdmins",
                keyColumns: new[] { "RoldId", "UserId" },
                keyValues: new object[] { 1, new Guid("87ec2679-f9fc-414c-805f-0812ae0223d2") });

            migrationBuilder.DeleteData(
                table: "RoleAdmins",
                keyColumns: new[] { "RoldId", "UserId" },
                keyValues: new object[] { 2, new Guid("87ec2679-f9fc-414c-805f-0812ae0223d2") });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("44f6e86e-e8ac-405b-b2c0-dd8b9423cf47"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("87ec2679-f9fc-414c-805f-0812ae0223d2"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { new Guid("44f6e86e-e8ac-405b-b2c0-dd8b9423cf47"), "123456", null, "Trantienthanh2412@gmail.com", true, true, new DateTimeOffset(new DateTime(2021, 6, 3, 14, 5, 33, 820, DateTimeKind.Unspecified).AddTicks(7873), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAEAACcQAAAAEBAPlUdwTj0sci7gABciifU0cXR+sD/GUUtK99iAzlEcmqzuCE4Z8TflzHN9Nv6+KQ==", "pscznq", "Admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeValidate", "CreateBy", "Email", "IsActive", "IsAdmin", "JoinedDate", "Password", "Salt", "UserName" },
                values: new object[] { new Guid("87ec2679-f9fc-414c-805f-0812ae0223d2"), "123456", null, "antiscam.contact@gmail.comm", true, true, new DateTimeOffset(new DateTime(2021, 6, 3, 14, 5, 33, 821, DateTimeKind.Unspecified).AddTicks(1221), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAEAACcQAAAAEBAPlUdwTj0sci7gABciifU0cXR+sD/GUUtK99iAzlEcmqzuCE4Z8TflzHN9Nv6+KQ==", "pscznq", "Admin" });

            migrationBuilder.InsertData(
                table: "RoleAdmins",
                columns: new[] { "RoldId", "UserId" },
                values: new object[,]
                {
                    { 1, new Guid("44f6e86e-e8ac-405b-b2c0-dd8b9423cf47") },
                    { 2, new Guid("44f6e86e-e8ac-405b-b2c0-dd8b9423cf47") },
                    { 1, new Guid("87ec2679-f9fc-414c-805f-0812ae0223d2") },
                    { 2, new Guid("87ec2679-f9fc-414c-805f-0812ae0223d2") }
                });
        }
    }
}
