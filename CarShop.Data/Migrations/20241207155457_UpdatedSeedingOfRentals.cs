using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedSeedingOfRentals : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                values: new object[] { "b1dbcbe5-0d5f-4458-b9d5-6957831a01e1", "AQAAAAIAAYagAAAAEFHz1zTlayA5TE4aKcLi6SZmrKJmTkAkB7FroHMdswKrRsfxH3H5FFjIo3CZHcj35A==", "3d679fcb-5ac8-401f-ac2f-48f6668b7f5a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4c2d88cd-675a-4904-a431-23a043e8313e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fe7bbe36-c399-457d-b1fc-80795f18d21e", "AQAAAAIAAYagAAAAENcvZLOefZKauKiPlSPEpZg8ZNDmtFdPme0BR2dhr9EIQytLmJnQiJSRj+PlEO2Whg==", "4d45d2c7-303a-4c30-83a2-f726a3f9300e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7d98badc-6c8c-4588-a4f5-d4a43ca9d741"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "026d0069-7684-4ee3-8c78-ad7cb01cf592", "AQAAAAIAAYagAAAAEEaFHFR7hITk+DNK1Vvd6uy7EOku9wsh34HxAWGyHaHD707V02mVarru2zefQ/CeKA==", "8f673bbb-bbb6-48df-8a5e-f4f8b4740fa3" });

            migrationBuilder.UpdateData(
                table: "DamageReports",
                keyColumn: "Id",
                keyValue: new Guid("6e92a04a-c225-4d2a-a0fe-c85ffa59e726"),
                column: "ReportedDate",
                value: new DateTime(2024, 12, 2, 15, 54, 56, 640, DateTimeKind.Utc).AddTicks(7197));

            migrationBuilder.UpdateData(
                table: "DamageReports",
                keyColumn: "Id",
                keyValue: new Guid("9f6c5e4c-9f4f-48d1-8adb-bc842bfca9b7"),
                column: "ReportedDate",
                value: new DateTime(2024, 11, 30, 15, 54, 56, 640, DateTimeKind.Utc).AddTicks(7204));

            migrationBuilder.UpdateData(
                table: "DamageReports",
                keyColumn: "Id",
                keyValue: new Guid("a03fad62-483f-4f88-b7e9-1c857c5650de"),
                column: "ReportedDate",
                value: new DateTime(2024, 11, 27, 15, 54, 56, 640, DateTimeKind.Utc).AddTicks(7194));

            migrationBuilder.UpdateData(
                table: "DamageReports",
                keyColumn: "Id",
                keyValue: new Guid("a8faafb7-9cd4-49fc-8edc-d1d76c37db8a"),
                column: "ReportedDate",
                value: new DateTime(2024, 11, 22, 15, 54, 56, 640, DateTimeKind.Utc).AddTicks(7201));

            migrationBuilder.UpdateData(
                table: "DamageReports",
                keyColumn: "Id",
                keyValue: new Guid("cdca012a-0a63-4b99-bb3e-45aef2b5d1a3"),
                column: "ReportedDate",
                value: new DateTime(2024, 12, 4, 15, 54, 56, 640, DateTimeKind.Utc).AddTicks(7170));

            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "Id", "ApplicationUserId", "CarId", "Comment", "FeedbackDate", "Rating" },
                values: new object[,]
                {
                    { new Guid("480894e9-fb88-4264-b074-419e2db6f68a"), new Guid("7d98badc-6c8c-4588-a4f5-d4a43ca9d741"), new Guid("29480900-2b63-4503-8818-647fde2a47e5"), "Great car, smooth ride!", new DateTime(2024, 11, 29, 15, 54, 56, 640, DateTimeKind.Utc).AddTicks(8728), 5 },
                    { new Guid("9b33e8de-e4b9-46ba-96b7-63cbee0b45d2"), new Guid("4c2d88cd-675a-4904-a431-23a043e8313e"), new Guid("29480900-2b63-4503-8818-647fde2a47e5"), "The car was decent but had a few issues.", new DateTime(2024, 12, 1, 15, 54, 56, 640, DateTimeKind.Utc).AddTicks(8739), 2 }
                });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: new Guid("d58bf2b1-b3b1-4f63-9603-05ba7ad3e6f7"),
                columns: new[] { "EndDate", "StartDate", "TotalCost" },
                values: new object[] { new DateTime(2024, 12, 14, 15, 54, 56, 640, DateTimeKind.Utc).AddTicks(9898), new DateTime(2024, 12, 10, 15, 54, 56, 640, DateTimeKind.Utc).AddTicks(9898), 2151.95m });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: new Guid("d599bce1-6c7a-401a-9a5b-d10e0736e3d8"),
                columns: new[] { "EndDate", "StartDate", "TotalCost" },
                values: new object[] { new DateTime(2024, 12, 10, 15, 54, 56, 640, DateTimeKind.Utc).AddTicks(9902), new DateTime(2024, 12, 8, 15, 54, 56, 640, DateTimeKind.Utc).AddTicks(9901), 216m });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: new Guid("dcf823b4-33f9-4102-a63d-ae28ee7e7708"),
                columns: new[] { "EndDate", "StartDate", "TotalCost" },
                values: new object[] { new DateTime(2024, 12, 17, 15, 54, 56, 640, DateTimeKind.Utc).AddTicks(9888), new DateTime(2024, 12, 14, 15, 54, 56, 640, DateTimeKind.Utc).AddTicks(9886), 4541.84m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: new Guid("480894e9-fb88-4264-b074-419e2db6f68a"));

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: new Guid("9b33e8de-e4b9-46ba-96b7-63cbee0b45d2"));

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
                columns: new[] { "EndDate", "StartDate", "TotalCost" },
                values: new object[] { new DateTime(2024, 12, 5, 15, 43, 39, 97, DateTimeKind.Utc).AddTicks(613), new DateTime(2024, 12, 2, 15, 43, 39, 97, DateTimeKind.Utc).AddTicks(612), 450.00m });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: new Guid("d599bce1-6c7a-401a-9a5b-d10e0736e3d8"),
                columns: new[] { "EndDate", "StartDate", "TotalCost" },
                values: new object[] { new DateTime(2024, 12, 6, 15, 43, 39, 97, DateTimeKind.Utc).AddTicks(617), new DateTime(2024, 12, 4, 15, 43, 39, 97, DateTimeKind.Utc).AddTicks(616), 200.00m });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: new Guid("dcf823b4-33f9-4102-a63d-ae28ee7e7708"),
                columns: new[] { "EndDate", "StartDate", "TotalCost" },
                values: new object[] { new DateTime(2024, 11, 30, 15, 43, 39, 97, DateTimeKind.Utc).AddTicks(601), new DateTime(2024, 11, 27, 15, 43, 39, 97, DateTimeKind.Utc).AddTicks(598), 300.00m });
        }
    }
}
