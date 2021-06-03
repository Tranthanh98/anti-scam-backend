using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace anti_scam_backend.Migrations
{
    public partial class UpdatePostCreateBy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoleAdmins",
                keyColumns: new[] { "RoldId", "UserId" },
                keyValues: new object[] { 1, new Guid("62a57169-4e36-4564-a04b-bcd0d65a678d") });

            migrationBuilder.DeleteData(
                table: "RoleAdmins",
                keyColumns: new[] { "RoldId", "UserId" },
                keyValues: new object[] { 2, new Guid("62a57169-4e36-4564-a04b-bcd0d65a678d") });

            migrationBuilder.DeleteData(
                table: "RoleAdmins",
                keyColumns: new[] { "RoldId", "UserId" },
                keyValues: new object[] { 1, new Guid("7dd6264f-25d9-4f09-8fef-b3fb3d53008e") });

            migrationBuilder.DeleteData(
                table: "RoleAdmins",
                keyColumns: new[] { "RoldId", "UserId" },
                keyValues: new object[] { 2, new Guid("7dd6264f-25d9-4f09-8fef-b3fb3d53008e") });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("62a57169-4e36-4564-a04b-bcd0d65a678d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7dd6264f-25d9-4f09-8fef-b3fb3d53008e"));

            migrationBuilder.AddColumn<string>(
                name: "CreateBy",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "Users");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeValidate", "Email", "IsActive", "IsAdmin", "JoinedDate", "Password", "Salt", "UserName" },
                values: new object[] { new Guid("7dd6264f-25d9-4f09-8fef-b3fb3d53008e"), "123456", "Trantienthanh2412@gmail.com", true, true, new DateTimeOffset(new DateTime(2021, 6, 1, 14, 44, 58, 746, DateTimeKind.Unspecified).AddTicks(6753), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAEAACcQAAAAEBAPlUdwTj0sci7gABciifU0cXR+sD/GUUtK99iAzlEcmqzuCE4Z8TflzHN9Nv6+KQ==", "pscznq", "Admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeValidate", "Email", "IsActive", "IsAdmin", "JoinedDate", "Password", "Salt", "UserName" },
                values: new object[] { new Guid("62a57169-4e36-4564-a04b-bcd0d65a678d"), "123456", "antiscam.contact@gmail.comm", true, true, new DateTimeOffset(new DateTime(2021, 6, 1, 14, 44, 58, 747, DateTimeKind.Unspecified).AddTicks(322), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAEAACcQAAAAEBAPlUdwTj0sci7gABciifU0cXR+sD/GUUtK99iAzlEcmqzuCE4Z8TflzHN9Nv6+KQ==", "pscznq", "Admin" });

            migrationBuilder.InsertData(
                table: "RoleAdmins",
                columns: new[] { "RoldId", "UserId" },
                values: new object[,]
                {
                    { 1, new Guid("7dd6264f-25d9-4f09-8fef-b3fb3d53008e") },
                    { 2, new Guid("7dd6264f-25d9-4f09-8fef-b3fb3d53008e") },
                    { 1, new Guid("62a57169-4e36-4564-a04b-bcd0d65a678d") },
                    { 2, new Guid("62a57169-4e36-4564-a04b-bcd0d65a678d") }
                });
        }
    }
}
