using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedDamageReports : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DamageReports",
                columns: new[] { "Id", "CarId", "CostEstimation", "Description", "ReportedDate" },
                values: new object[,]
                {
                    { new Guid("6e92a04a-c225-4d2a-a0fe-c85ffa59e726"), new Guid("29480900-2b63-4503-8818-647fde2a47e5"), 750.25m, "Left side mirror broken and scratches along the driver-side door.", new DateTime(2024, 12, 2, 14, 30, 45, 247, DateTimeKind.Utc).AddTicks(9678) },
                    { new Guid("9f6c5e4c-9f4f-48d1-8adb-bc842bfca9b7"), new Guid("e3ea8915-979c-478f-b597-4b50e5f31cfd"), 1800.75m, "Tires were slashed and the windshield has a large crack running across.", new DateTime(2024, 11, 30, 14, 30, 45, 247, DateTimeKind.Utc).AddTicks(9689) },
                    { new Guid("a03fad62-483f-4f88-b7e9-1c857c5650de"), new Guid("3f821603-c82c-4b46-bc94-8a246e5ca4c1"), 600.00m, "Rear window shattered after an attempted break-in at the parking lot.", new DateTime(2024, 11, 27, 14, 30, 45, 247, DateTimeKind.Utc).AddTicks(9675) },
                    { new Guid("a8faafb7-9cd4-49fc-8edc-d1d76c37db8a"), new Guid("eea3a59b-1d08-47d5-82f5-863384b9df71"), 1400.00m, "Hood is dented and paint is chipped from debris falling on the car.", new DateTime(2024, 11, 22, 14, 30, 45, 247, DateTimeKind.Utc).AddTicks(9682) },
                    { new Guid("cdca012a-0a63-4b99-bb3e-45aef2b5d1a3"), new Guid("99fed59f-dce8-4359-8ccb-88efa7781faa"), 1200.50m, "Front bumper is severely dented due to a collision with a pole.", new DateTime(2024, 12, 4, 14, 30, 45, 247, DateTimeKind.Utc).AddTicks(9661) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DamageReports",
                keyColumn: "Id",
                keyValue: new Guid("6e92a04a-c225-4d2a-a0fe-c85ffa59e726"));

            migrationBuilder.DeleteData(
                table: "DamageReports",
                keyColumn: "Id",
                keyValue: new Guid("9f6c5e4c-9f4f-48d1-8adb-bc842bfca9b7"));

            migrationBuilder.DeleteData(
                table: "DamageReports",
                keyColumn: "Id",
                keyValue: new Guid("a03fad62-483f-4f88-b7e9-1c857c5650de"));

            migrationBuilder.DeleteData(
                table: "DamageReports",
                keyColumn: "Id",
                keyValue: new Guid("a8faafb7-9cd4-49fc-8edc-d1d76c37db8a"));

            migrationBuilder.DeleteData(
                table: "DamageReports",
                keyColumn: "Id",
                keyValue: new Guid("cdca012a-0a63-4b99-bb3e-45aef2b5d1a3"));
        }
    }
}
