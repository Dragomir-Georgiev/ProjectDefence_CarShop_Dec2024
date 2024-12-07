using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedFeedbacks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("49317ff2-5aac-426d-a8bd-d4bee288c776"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e7e6520c-ce64-4054-b455-1f618851f7f2", "AQAAAAIAAYagAAAAEC5gDY5390cXhrzHexuixz0L2gQXAPjmUFkoLsXIwCb2QFR0Hy2SSLsQPrVi7NT+hw==", "ee886ccb-f537-45be-a208-195104eeed9c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4c2d88cd-675a-4904-a431-23a043e8313e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "be4f29c3-591c-456b-a034-2b48c1746875", "AQAAAAIAAYagAAAAELjpNCah0NefiiM+g33W+ozcLKRUGnWbrtP3/7PQfJUtFizBiODW5Hb7QVfjlqjykg==", "a25f4f25-6564-4df1-8e08-9edeea589012" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7d98badc-6c8c-4588-a4f5-d4a43ca9d741"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2d5be83f-4b71-44e7-8d05-a61c2f208970", "AQAAAAIAAYagAAAAEAf50lJVHHJe3Kr2qvntX4CPRuF6nqwf3uzt14OrSYaDbuYWmbdPlYSMDeFG3cJ+MA==", "45f0bfdc-3f16-42bc-a9a3-fb92ad292b56" });

            migrationBuilder.UpdateData(
                table: "DamageReports",
                keyColumn: "Id",
                keyValue: new Guid("6e92a04a-c225-4d2a-a0fe-c85ffa59e726"),
                column: "ReportedDate",
                value: new DateTime(2024, 12, 2, 15, 24, 34, 302, DateTimeKind.Utc).AddTicks(2828));

            migrationBuilder.UpdateData(
                table: "DamageReports",
                keyColumn: "Id",
                keyValue: new Guid("9f6c5e4c-9f4f-48d1-8adb-bc842bfca9b7"),
                column: "ReportedDate",
                value: new DateTime(2024, 11, 30, 15, 24, 34, 302, DateTimeKind.Utc).AddTicks(2840));

            migrationBuilder.UpdateData(
                table: "DamageReports",
                keyColumn: "Id",
                keyValue: new Guid("a03fad62-483f-4f88-b7e9-1c857c5650de"),
                column: "ReportedDate",
                value: new DateTime(2024, 11, 27, 15, 24, 34, 302, DateTimeKind.Utc).AddTicks(2824));

            migrationBuilder.UpdateData(
                table: "DamageReports",
                keyColumn: "Id",
                keyValue: new Guid("a8faafb7-9cd4-49fc-8edc-d1d76c37db8a"),
                column: "ReportedDate",
                value: new DateTime(2024, 11, 22, 15, 24, 34, 302, DateTimeKind.Utc).AddTicks(2831));

            migrationBuilder.UpdateData(
                table: "DamageReports",
                keyColumn: "Id",
                keyValue: new Guid("cdca012a-0a63-4b99-bb3e-45aef2b5d1a3"),
                column: "ReportedDate",
                value: new DateTime(2024, 12, 4, 15, 24, 34, 302, DateTimeKind.Utc).AddTicks(2805));

            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "Id", "ApplicationUserId", "CarId", "Comment", "FeedbackDate", "Rating" },
                values: new object[,]
                {
                    { new Guid("c4fea403-c09e-4418-8cf9-91c63cee8c4f"), new Guid("7d98badc-6c8c-4588-a4f5-d4a43ca9d741"), new Guid("29480900-2b63-4503-8818-647fde2a47e5"), "Great car, smooth ride!", new DateTime(2024, 11, 29, 15, 24, 34, 302, DateTimeKind.Utc).AddTicks(4677), 5 },
                    { new Guid("e871ea89-16a7-47eb-a874-38c32dd1b0fd"), new Guid("4c2d88cd-675a-4904-a431-23a043e8313e"), new Guid("29480900-2b63-4503-8818-647fde2a47e5"), "The car was decent but had a few issues.", new DateTime(2024, 12, 1, 15, 24, 34, 302, DateTimeKind.Utc).AddTicks(4689), 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: new Guid("c4fea403-c09e-4418-8cf9-91c63cee8c4f"));

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: new Guid("e871ea89-16a7-47eb-a874-38c32dd1b0fd"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("49317ff2-5aac-426d-a8bd-d4bee288c776"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "88af43d6-b760-42fb-aec4-85f52a8a1e7b", "AQAAAAIAAYagAAAAEOnOEIyZRd/kNB9bwCilw9x2Uc7hB4fQ2QGizQS/Qe1Qo9sNnfnwiOs8hVxDWTQ2IA==", "61bb41e7-9d47-4c30-b2c5-85634ae54c15" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4c2d88cd-675a-4904-a431-23a043e8313e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d67b1254-f34d-48cb-b3c5-c3923d66ec43", "AQAAAAIAAYagAAAAEP1jK6/uEy38CfKYeZcJYhXU77ZNgMHAT2XCey5/pilfatlAQ7ig/5TDM8u1VjjH0A==", "3ce5b5d1-a125-4d14-b700-8e4182f66f86" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7d98badc-6c8c-4588-a4f5-d4a43ca9d741"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cf72bc8e-d3d8-48ca-a6fc-8d5601502f43", "AQAAAAIAAYagAAAAECSzbiUUZ8gTRclJr6cNdGtFgrDNheWmEaUIM0/Bm07tAVMObYEqHopNz6els5ddhA==", "31b063eb-2273-4a51-a1ce-15412960d9a0" });

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
    }
}
