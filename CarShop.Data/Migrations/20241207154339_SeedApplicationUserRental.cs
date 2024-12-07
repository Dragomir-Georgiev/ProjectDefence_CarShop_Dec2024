using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedApplicationUserRental : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: new Guid("3a7d6e92-bbac-4a83-b2d2-1c04d17ab5fe"));

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: new Guid("854278f4-662a-40fa-b824-ef5a09ea0e7a"));

            migrationBuilder.InsertData(
                table: "ApplicationsUsersRentals",
                columns: new[] { "ApplicationUserId", "RentalId" },
                values: new object[,]
                {
                    { new Guid("4c2d88cd-675a-4904-a431-23a043e8313e"), new Guid("d58bf2b1-b3b1-4f63-9603-05ba7ad3e6f7") },
                    { new Guid("4c2d88cd-675a-4904-a431-23a043e8313e"), new Guid("d599bce1-6c7a-401a-9a5b-d10e0736e3d8") },
                    { new Guid("4c2d88cd-675a-4904-a431-23a043e8313e"), new Guid("dcf823b4-33f9-4102-a63d-ae28ee7e7708") }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("49317ff2-5aac-426d-a8bd-d4bee288c776"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a2e223c7-8b64-496f-8a09-82833afaa340", "AQAAAAIAAYagAAAAEErQqhERgt2Kuwfh8/AUd4EPFy/4yBKYPuaEH5Es39TD51wlQikOszCKxPMKJsSJ8w==", "089176ca-4081-4d3c-9ee7-eafc263ee3bb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4c2d88cd-675a-4904-a431-23a043e8313e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "70bc9e3a-4022-46cd-a3ec-af6d282bdfd8", "AQAAAAIAAYagAAAAECRpobjRzY0WNeTRjj4r5RcZBnGva3/8SBKzm3aV7S/CJ+bW3Gjmir/dFktfQwo8og==", "fcdc10ec-0bbf-404f-8d3b-478a416615dd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7d98badc-6c8c-4588-a4f5-d4a43ca9d741"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "78b54a7f-65c0-4e2f-90e5-df7f39ecda8e", "AQAAAAIAAYagAAAAENUcTvc1MRBFShlai9U2TsQZPytxMxtPxkU7zeudyDLboVL8+2wSkqeS4xhmbiLfow==", "c7b05dd4-0299-489a-b4ed-cd36be1fa02e" });

            migrationBuilder.UpdateData(
                table: "DamageReports",
                keyColumn: "Id",
                keyValue: new Guid("6e92a04a-c225-4d2a-a0fe-c85ffa59e726"),
                column: "ReportedDate",
                value: new DateTime(2024, 12, 2, 15, 43, 39, 96, DateTimeKind.Utc).AddTicks(8293));

            migrationBuilder.UpdateData(
                table: "DamageReports",
                keyColumn: "Id",
                keyValue: new Guid("9f6c5e4c-9f4f-48d1-8adb-bc842bfca9b7"),
                column: "ReportedDate",
                value: new DateTime(2024, 11, 30, 15, 43, 39, 96, DateTimeKind.Utc).AddTicks(8300));

            migrationBuilder.UpdateData(
                table: "DamageReports",
                keyColumn: "Id",
                keyValue: new Guid("a03fad62-483f-4f88-b7e9-1c857c5650de"),
                column: "ReportedDate",
                value: new DateTime(2024, 11, 27, 15, 43, 39, 96, DateTimeKind.Utc).AddTicks(8289));

            migrationBuilder.UpdateData(
                table: "DamageReports",
                keyColumn: "Id",
                keyValue: new Guid("a8faafb7-9cd4-49fc-8edc-d1d76c37db8a"),
                column: "ReportedDate",
                value: new DateTime(2024, 11, 22, 15, 43, 39, 96, DateTimeKind.Utc).AddTicks(8296));

            migrationBuilder.UpdateData(
                table: "DamageReports",
                keyColumn: "Id",
                keyValue: new Guid("cdca012a-0a63-4b99-bb3e-45aef2b5d1a3"),
                column: "ReportedDate",
                value: new DateTime(2024, 12, 4, 15, 43, 39, 96, DateTimeKind.Utc).AddTicks(8267));

            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "Id", "ApplicationUserId", "CarId", "Comment", "FeedbackDate", "Rating" },
                values: new object[,]
                {
                    { new Guid("9fdb67f3-35d5-426e-9b16-4c73fa839f6d"), new Guid("7d98badc-6c8c-4588-a4f5-d4a43ca9d741"), new Guid("29480900-2b63-4503-8818-647fde2a47e5"), "Great car, smooth ride!", new DateTime(2024, 11, 29, 15, 43, 39, 96, DateTimeKind.Utc).AddTicks(9420), 5 },
                    { new Guid("bcb6417a-3a68-4ffb-966f-20a2c3a59111"), new Guid("4c2d88cd-675a-4904-a431-23a043e8313e"), new Guid("29480900-2b63-4503-8818-647fde2a47e5"), "The car was decent but had a few issues.", new DateTime(2024, 12, 1, 15, 43, 39, 96, DateTimeKind.Utc).AddTicks(9434), 2 }
                });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: new Guid("d58bf2b1-b3b1-4f63-9603-05ba7ad3e6f7"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 5, 15, 43, 39, 97, DateTimeKind.Utc).AddTicks(613), new DateTime(2024, 12, 2, 15, 43, 39, 97, DateTimeKind.Utc).AddTicks(612) });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: new Guid("d599bce1-6c7a-401a-9a5b-d10e0736e3d8"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 6, 15, 43, 39, 97, DateTimeKind.Utc).AddTicks(617), new DateTime(2024, 12, 4, 15, 43, 39, 97, DateTimeKind.Utc).AddTicks(616) });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: new Guid("dcf823b4-33f9-4102-a63d-ae28ee7e7708"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 11, 30, 15, 43, 39, 97, DateTimeKind.Utc).AddTicks(601), new DateTime(2024, 11, 27, 15, 43, 39, 97, DateTimeKind.Utc).AddTicks(598) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ApplicationsUsersRentals",
                keyColumns: new[] { "ApplicationUserId", "RentalId" },
                keyValues: new object[] { new Guid("4c2d88cd-675a-4904-a431-23a043e8313e"), new Guid("d58bf2b1-b3b1-4f63-9603-05ba7ad3e6f7") });

            migrationBuilder.DeleteData(
                table: "ApplicationsUsersRentals",
                keyColumns: new[] { "ApplicationUserId", "RentalId" },
                keyValues: new object[] { new Guid("4c2d88cd-675a-4904-a431-23a043e8313e"), new Guid("d599bce1-6c7a-401a-9a5b-d10e0736e3d8") });

            migrationBuilder.DeleteData(
                table: "ApplicationsUsersRentals",
                keyColumns: new[] { "ApplicationUserId", "RentalId" },
                keyValues: new object[] { new Guid("4c2d88cd-675a-4904-a431-23a043e8313e"), new Guid("dcf823b4-33f9-4102-a63d-ae28ee7e7708") });

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: new Guid("9fdb67f3-35d5-426e-9b16-4c73fa839f6d"));

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: new Guid("bcb6417a-3a68-4ffb-966f-20a2c3a59111"));

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

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: new Guid("d58bf2b1-b3b1-4f63-9603-05ba7ad3e6f7"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 5, 15, 42, 1, 431, DateTimeKind.Utc).AddTicks(7531), new DateTime(2024, 12, 2, 15, 42, 1, 431, DateTimeKind.Utc).AddTicks(7530) });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: new Guid("d599bce1-6c7a-401a-9a5b-d10e0736e3d8"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 6, 15, 42, 1, 431, DateTimeKind.Utc).AddTicks(7535), new DateTime(2024, 12, 4, 15, 42, 1, 431, DateTimeKind.Utc).AddTicks(7535) });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: new Guid("dcf823b4-33f9-4102-a63d-ae28ee7e7708"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 11, 30, 15, 42, 1, 431, DateTimeKind.Utc).AddTicks(7521), new DateTime(2024, 11, 27, 15, 42, 1, 431, DateTimeKind.Utc).AddTicks(7518) });
        }
    }
}
