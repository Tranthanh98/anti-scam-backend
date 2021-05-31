using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace anti_scam_backend.Migrations
{
    public partial class SeedingDataAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoleAdmins",
                keyColumns: new[] { "RoldId", "UserId" },
                keyValues: new object[] { 1, new Guid("2a74ddb2-4aed-4976-9855-0256763840ac") });

            migrationBuilder.DeleteData(
                table: "RoleAdmins",
                keyColumns: new[] { "RoldId", "UserId" },
                keyValues: new object[] { 2, new Guid("2a74ddb2-4aed-4976-9855-0256763840ac") });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2a74ddb2-4aed-4976-9855-0256763840ac"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeValidate", "Email", "IsActive", "IsAdmin", "JoinedDate", "Password", "Salt", "UserName" },
                values: new object[] { new Guid("a4d805cd-278a-4e0f-814d-19d211933003"), "123456", "Trantienthanh2412@gmail.com", true, true, new DateTimeOffset(new DateTime(2021, 5, 31, 10, 31, 15, 701, DateTimeKind.Unspecified).AddTicks(2564), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAEAACcQAAAAEBAPlUdwTj0sci7gABciifU0cXR+sD/GUUtK99iAzlEcmqzuCE4Z8TflzHN9Nv6+KQ==", "pscznq", "Admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeValidate", "Email", "IsActive", "IsAdmin", "JoinedDate", "Password", "Salt", "UserName" },
                values: new object[] { new Guid("dc9e70ba-508d-476a-9981-624554c24986"), "123456", "antiscam.contact@gmail.comm", true, true, new DateTimeOffset(new DateTime(2021, 5, 31, 10, 31, 15, 701, DateTimeKind.Unspecified).AddTicks(7456), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAEAACcQAAAAEBAPlUdwTj0sci7gABciifU0cXR+sD/GUUtK99iAzlEcmqzuCE4Z8TflzHN9Nv6+KQ==", "pscznq", "Admin" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeValidate", "Email", "IsActive", "IsAdmin", "JoinedDate", "Password", "Salt", "UserName" },
                values: new object[] { new Guid("2a74ddb2-4aed-4976-9855-0256763840ac"), "123456", "Trantienthanh2412@gmail.com", true, true, new DateTimeOffset(new DateTime(2021, 5, 31, 10, 26, 11, 665, DateTimeKind.Unspecified).AddTicks(1775), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAEAACcQAAAAEBAPlUdwTj0sci7gABciifU0cXR+sD/GUUtK99iAzlEcmqzuCE4Z8TflzHN9Nv6+KQ==", "pscznq", "Admin" });

            migrationBuilder.InsertData(
                table: "RoleAdmins",
                columns: new[] { "RoldId", "UserId" },
                values: new object[] { 1, new Guid("2a74ddb2-4aed-4976-9855-0256763840ac") });

            migrationBuilder.InsertData(
                table: "RoleAdmins",
                columns: new[] { "RoldId", "UserId" },
                values: new object[] { 2, new Guid("2a74ddb2-4aed-4976-9855-0256763840ac") });
        }
    }
}
