using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedRentals : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "195a75b4-3154-4d2d-ba86-55d92ca05ff6", "AQAAAAIAAYagAAAAENi249lGPCi/q0st2amdnf3Q/aRQ/DVyQLs/5/Qyjn10c8LX0X2S8hYJws8ptPu+IA==", "c8e3abb4-1b8a-49cd-a5fb-c61536d43b3c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4c2d88cd-675a-4904-a431-23a043e8313e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "109f24f2-2272-41c8-b319-14258fb99bf4", "AQAAAAIAAYagAAAAELbCqtcAqaAwvqsTvJbzfzb0+c3PEqoej2Lbm5CsaE1JvaQPCiccd/RFBp9/W9Tcuw==", "4f6339d8-b500-4761-81e4-1a2810edb886" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7d98badc-6c8c-4588-a4f5-d4a43ca9d741"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3cd69e3e-a4d7-4720-8c93-eb2a6584bd4e", "AQAAAAIAAYagAAAAEDLfwzIg/TivUnZj6ta1XujCVFkg0ElbK9HyEAn9L8YdmtfXGeuzGs6RSgNwBBn/zQ==", "0058b68f-b8f8-4678-8f15-042809b3d9ea" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("0f3815d0-37b0-440d-978f-22fe3d9416cc"),
                column: "IsAvailable",
                value: false);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("4590f15d-634b-4a10-9f69-32a88931922f"),
                column: "IsAvailable",
                value: false);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("cbc0f0df-2fbf-4d87-ab77-c214efa3e363"),
                column: "IsAvailable",
                value: false);

            migrationBuilder.UpdateData(
                table: "DamageReports",
                keyColumn: "Id",
                keyValue: new Guid("6e92a04a-c225-4d2a-a0fe-c85ffa59e726"),
                column: "ReportedDate",
                value: new DateTime(2024, 12, 2, 15, 42, 1, 430, DateTimeKind.Utc).AddTicks(8575));

            migrationBuilder.UpdateData(
                table: "DamageReports",
                keyColumn: "Id",
                keyValue: new Guid("9f6c5e4c-9f4f-48d1-8adb-bc842bfca9b7"),
                column: "ReportedDate",
                value: new DateTime(2024, 11, 30, 15, 42, 1, 430, DateTimeKind.Utc).AddTicks(8581));

            migrationBuilder.UpdateData(
                table: "DamageReports",
                keyColumn: "Id",
                keyValue: new Guid("a03fad62-483f-4f88-b7e9-1c857c5650de"),
                column: "ReportedDate",
                value: new DateTime(2024, 11, 27, 15, 42, 1, 430, DateTimeKind.Utc).AddTicks(8571));

            migrationBuilder.UpdateData(
                table: "DamageReports",
                keyColumn: "Id",
                keyValue: new Guid("a8faafb7-9cd4-49fc-8edc-d1d76c37db8a"),
                column: "ReportedDate",
                value: new DateTime(2024, 11, 22, 15, 42, 1, 430, DateTimeKind.Utc).AddTicks(8578));

            migrationBuilder.UpdateData(
                table: "DamageReports",
                keyColumn: "Id",
                keyValue: new Guid("cdca012a-0a63-4b99-bb3e-45aef2b5d1a3"),
                column: "ReportedDate",
                value: new DateTime(2024, 12, 4, 15, 42, 1, 430, DateTimeKind.Utc).AddTicks(8495));

            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "Id", "ApplicationUserId", "CarId", "Comment", "FeedbackDate", "Rating" },
                values: new object[,]
                {
                    { new Guid("3a7d6e92-bbac-4a83-b2d2-1c04d17ab5fe"), new Guid("7d98badc-6c8c-4588-a4f5-d4a43ca9d741"), new Guid("29480900-2b63-4503-8818-647fde2a47e5"), "Great car, smooth ride!", new DateTime(2024, 11, 29, 15, 42, 1, 431, DateTimeKind.Utc).AddTicks(6192), 5 },
                    { new Guid("854278f4-662a-40fa-b824-ef5a09ea0e7a"), new Guid("4c2d88cd-675a-4904-a431-23a043e8313e"), new Guid("29480900-2b63-4503-8818-647fde2a47e5"), "The car was decent but had a few issues.", new DateTime(2024, 12, 1, 15, 42, 1, 431, DateTimeKind.Utc).AddTicks(6206), 2 }
                });

            migrationBuilder.InsertData(
                table: "Rentals",
                columns: new[] { "Id", "CarId", "EndDate", "StartDate", "TotalCost" },
                values: new object[,]
                {
                    { new Guid("d58bf2b1-b3b1-4f63-9603-05ba7ad3e6f7"), new Guid("cbc0f0df-2fbf-4d87-ab77-c214efa3e363"), new DateTime(2024, 12, 5, 15, 42, 1, 431, DateTimeKind.Utc).AddTicks(7531), new DateTime(2024, 12, 2, 15, 42, 1, 431, DateTimeKind.Utc).AddTicks(7530), 450.00m },
                    { new Guid("d599bce1-6c7a-401a-9a5b-d10e0736e3d8"), new Guid("0f3815d0-37b0-440d-978f-22fe3d9416cc"), new DateTime(2024, 12, 6, 15, 42, 1, 431, DateTimeKind.Utc).AddTicks(7535), new DateTime(2024, 12, 4, 15, 42, 1, 431, DateTimeKind.Utc).AddTicks(7535), 200.00m },
                    { new Guid("dcf823b4-33f9-4102-a63d-ae28ee7e7708"), new Guid("4590f15d-634b-4a10-9f69-32a88931922f"), new DateTime(2024, 11, 30, 15, 42, 1, 431, DateTimeKind.Utc).AddTicks(7521), new DateTime(2024, 11, 27, 15, 42, 1, 431, DateTimeKind.Utc).AddTicks(7518), 300.00m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: new Guid("3a7d6e92-bbac-4a83-b2d2-1c04d17ab5fe"));

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: new Guid("854278f4-662a-40fa-b824-ef5a09ea0e7a"));

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: new Guid("d58bf2b1-b3b1-4f63-9603-05ba7ad3e6f7"));

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: new Guid("d599bce1-6c7a-401a-9a5b-d10e0736e3d8"));

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: new Guid("dcf823b4-33f9-4102-a63d-ae28ee7e7708"));

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
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("0f3815d0-37b0-440d-978f-22fe3d9416cc"),
                column: "IsAvailable",
                value: true);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("4590f15d-634b-4a10-9f69-32a88931922f"),
                column: "IsAvailable",
                value: true);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("cbc0f0df-2fbf-4d87-ab77-c214efa3e363"),
                column: "IsAvailable",
                value: true);

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
    }
}
