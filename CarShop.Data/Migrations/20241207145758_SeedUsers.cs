using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("49317ff2-5aac-426d-a8bd-d4bee288c776"), 0, "88af43d6-b760-42fb-aec4-85f52a8a1e7b", "admin@example.com", false, false, null, "ADMIN@EXAMPLE.COM", "АDMIN", "AQAAAAIAAYagAAAAEOnOEIyZRd/kNB9bwCilw9x2Uc7hB4fQ2QGizQS/Qe1Qo9sNnfnwiOs8hVxDWTQ2IA==", null, false, "61bb41e7-9d47-4c30-b2c5-85634ae54c15", false, "Admin" },
                    { new Guid("4c2d88cd-675a-4904-a431-23a043e8313e"), 0, "d67b1254-f34d-48cb-b3c5-c3923d66ec43", "testuser123@gmail.com", false, false, null, "TESTUSER123@GMAIL.COM", "USER", "AQAAAAIAAYagAAAAEP1jK6/uEy38CfKYeZcJYhXU77ZNgMHAT2XCey5/pilfatlAQ7ig/5TDM8u1VjjH0A==", null, false, "3ce5b5d1-a125-4d14-b700-8e4182f66f86", false, "User" },
                    { new Guid("7d98badc-6c8c-4588-a4f5-d4a43ca9d741"), 0, "cf72bc8e-d3d8-48ca-a6fc-8d5601502f43", "dragomir@yahoo.ca", false, false, null, "DRAGOMIR@YAHOO.CA", "DRAGOMIR", "AQAAAAIAAYagAAAAECSzbiUUZ8gTRclJr6cNdGtFgrDNheWmEaUIM0/Bm07tAVMObYEqHopNz6els5ddhA==", null, false, "31b063eb-2273-4a51-a1ce-15412960d9a0", false, "Dragomir" }
                });

            migrationBuilder.UpdateData(
                table: "DamageReports",
                keyColumn: "Id",
                keyValue: new Guid("6e92a04a-c225-4d2a-a0fe-c85ffa59e726"),
                column: "ReportedDate",
                value: new DateTime(2024, 12, 2, 14, 57, 57, 877, DateTimeKind.Utc).AddTicks(3460));

            migrationBuilder.UpdateData(
                table: "DamageReports",
                keyColumn: "Id",
                keyValue: new Guid("9f6c5e4c-9f4f-48d1-8adb-bc842bfca9b7"),
                column: "ReportedDate",
                value: new DateTime(2024, 11, 30, 14, 57, 57, 877, DateTimeKind.Utc).AddTicks(3472));

            migrationBuilder.UpdateData(
                table: "DamageReports",
                keyColumn: "Id",
                keyValue: new Guid("a03fad62-483f-4f88-b7e9-1c857c5650de"),
                column: "ReportedDate",
                value: new DateTime(2024, 11, 27, 14, 57, 57, 877, DateTimeKind.Utc).AddTicks(3457));

            migrationBuilder.UpdateData(
                table: "DamageReports",
                keyColumn: "Id",
                keyValue: new Guid("a8faafb7-9cd4-49fc-8edc-d1d76c37db8a"),
                column: "ReportedDate",
                value: new DateTime(2024, 11, 22, 14, 57, 57, 877, DateTimeKind.Utc).AddTicks(3469));

            migrationBuilder.UpdateData(
                table: "DamageReports",
                keyColumn: "Id",
                keyValue: new Guid("cdca012a-0a63-4b99-bb3e-45aef2b5d1a3"),
                column: "ReportedDate",
                value: new DateTime(2024, 12, 4, 14, 57, 57, 877, DateTimeKind.Utc).AddTicks(3439));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("49317ff2-5aac-426d-a8bd-d4bee288c776"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4c2d88cd-675a-4904-a431-23a043e8313e"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7d98badc-6c8c-4588-a4f5-d4a43ca9d741"));

            migrationBuilder.UpdateData(
                table: "DamageReports",
                keyColumn: "Id",
                keyValue: new Guid("6e92a04a-c225-4d2a-a0fe-c85ffa59e726"),
                column: "ReportedDate",
                value: new DateTime(2024, 12, 2, 14, 30, 45, 247, DateTimeKind.Utc).AddTicks(9678));

            migrationBuilder.UpdateData(
                table: "DamageReports",
                keyColumn: "Id",
                keyValue: new Guid("9f6c5e4c-9f4f-48d1-8adb-bc842bfca9b7"),
                column: "ReportedDate",
                value: new DateTime(2024, 11, 30, 14, 30, 45, 247, DateTimeKind.Utc).AddTicks(9689));

            migrationBuilder.UpdateData(
                table: "DamageReports",
                keyColumn: "Id",
                keyValue: new Guid("a03fad62-483f-4f88-b7e9-1c857c5650de"),
                column: "ReportedDate",
                value: new DateTime(2024, 11, 27, 14, 30, 45, 247, DateTimeKind.Utc).AddTicks(9675));

            migrationBuilder.UpdateData(
                table: "DamageReports",
                keyColumn: "Id",
                keyValue: new Guid("a8faafb7-9cd4-49fc-8edc-d1d76c37db8a"),
                column: "ReportedDate",
                value: new DateTime(2024, 11, 22, 14, 30, 45, 247, DateTimeKind.Utc).AddTicks(9682));

            migrationBuilder.UpdateData(
                table: "DamageReports",
                keyColumn: "Id",
                keyValue: new Guid("cdca012a-0a63-4b99-bb3e-45aef2b5d1a3"),
                column: "ReportedDate",
                value: new DateTime(2024, 12, 4, 14, 30, 45, 247, DateTimeKind.Utc).AddTicks(9661));
        }
    }
}
