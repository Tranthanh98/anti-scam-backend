using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace anti_scam_backend.Migrations
{
    public partial class AddFieldAcceptedDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "AcceptedDate",
                table: "Posts",
                type: "datetimeoffset",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "AcceptedDate",
                table: "Posts");

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
        }
    }
}
