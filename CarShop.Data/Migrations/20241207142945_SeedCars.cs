using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedCars : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CarCategoryId", "CarImage", "DoorsCount", "FuelConsumption", "IsAvailable", "IsDeleted", "Make", "MaximumSpeed", "Model", "PricePerDay", "ProductionYear", "SeatingCapacity", "TankVolume", "TransmissionType" },
                values: new object[,]
                {
                    { new Guid("04f4c07e-045d-457e-af60-b0397cf81225"), new Guid("91ac82e0-9aa7-4d53-bba4-cd8128c0b629"), "", 5, 8.4000000000000004, true, false, "Honda", 270, "Civic Type R", 0m, 2020, 4, 46.0, 1 },
                    { new Guid("0f3815d0-37b0-440d-978f-22fe3d9416cc"), new Guid("47b3ba7c-8aaa-450d-bf9f-847106fc8e02"), "https://www.passportbmw.com/blogs/846/wp-content/uploads/2022/09/P90479453__mid.jpeg", 2, 7.9000000000000004, true, false, "BMW", 250, "Z4", 72m, 2024, 2, 52.0, 0 },
                    { new Guid("29480900-2b63-4503-8818-647fde2a47e5"), new Guid("df2cdc1f-46c7-428b-a54b-e03eb0e33a7f"), "https://www.motortrend.com/uploads/2022/03/2022-Mazda-Mazda3-Sedan-AWD-Turbo-29.jpg", 4, 8.4000000000000004, false, false, "Mazda", 204, "3", 30m, 2022, 5, 50.0, 0 },
                    { new Guid("3f821603-c82c-4b46-bc94-8a246e5ca4c1"), new Guid("efdd48c4-fa58-48d9-8b86-0b9c3f0d64a6"), "https://www.auto-data.net/images/f46/Dodge-Caravan-V-facelift-2011.jpg", 5, 13.800000000000001, false, false, "Dodge", 220, "Caravan", 31.78m, 2011, 7, 76.0, 1 },
                    { new Guid("41f5527c-c52b-409c-a6e8-74e8f6497c80"), new Guid("df2cdc1f-46c7-428b-a54b-e03eb0e33a7f"), "", 4, 5.8099999999999996, true, false, "Toyota", 205, "Camry", 54m, 2023, 5, 60.0, 0 },
                    { new Guid("4590f15d-634b-4a10-9f69-32a88931922f"), new Guid("264e1f65-36e4-44fb-9605-64bec9b9ed7a"), "https://r44performance.com/cdn/shop/articles/R44Performance-Porsche-911-GT3RS.jpg?v=1710775245&width=1500", 2, 13.800000000000001, true, false, "Porsche", 311, "911", 1135.46m, 2024, 2, 64.0, 0 },
                    { new Guid("77b5fe3d-be73-4089-8512-b6665370a2ec"), new Guid("264e1f65-36e4-44fb-9605-64bec9b9ed7a"), "https://s3-ap-southeast-1.amazonaws.com/subaru.asia-cms/articles/logo_1b697b9c5550ddceb41469d84a27d60a.jpg", 2, 9.5, true, false, "Subaru", 226, "BRZ", 45m, 2021, 4, 50.0, 0 },
                    { new Guid("8326b7a1-6a93-46c4-89eb-d1a50330e3b6"), new Guid("91ac82e0-9aa7-4d53-bba4-cd8128c0b629"), "https://www.thedrive.com/wp-content/uploads/2022/06/21/DSC00241.jpg?quality=85", 5, 8.6999999999999993, true, false, "Mazda", 204, "3", 35m, 2022, 5, 50.0, 1 },
                    { new Guid("99fed59f-dce8-4359-8ccb-88efa7781faa"), new Guid("df2cdc1f-46c7-428b-a54b-e03eb0e33a7f"), "https://parkers-images.bauersecure.com/wp-images/174840/bmw_3_series_050.jpg", 4, 7.7999999999999998, false, false, "BMW", 250, "3 Series", 75m, 2022, 5, 59.0, 0 },
                    { new Guid("ba7f77e9-e054-4ec9-8f11-2d7346ea80b5"), new Guid("a69fe7ac-6ad4-403f-ba76-eefbc3a691c6"), "https://dealerinspire-image-library-prod.s3.us-east-1.amazonaws.com/images/G91FpK6If8GqdDPnNyDDqhHR8SEG2pb5lVb3ghli.jpeg", 4, 14.699999999999999, true, false, "Chevrolet", 183, "Silverado 1500", 140m, 2022, 5, 90.799999999999997, 0 },
                    { new Guid("cbc0f0df-2fbf-4d87-ab77-c214efa3e363"), new Guid("8e86c12d-4d99-4c26-be13-befca7323ab3"), "https://www.auto-data.net/images/f24/file8561751.jpg", 2, 7.0, true, false, "Audi", 250, "A5", 430.39m, 2019, 4, 58.0, 0 },
                    { new Guid("e3ea8915-979c-478f-b597-4b50e5f31cfd"), new Guid("9c8e3ead-80a2-45c6-afba-91248baebef3"), "https://images.pistonheads.com/nimg/48142/blobid0.jpg", 2, 12.199999999999999, false, false, "McLaren", 332, "750S Spider", 1797.90m, 2023, 2, 72.0, 0 },
                    { new Guid("e5a47d2a-68fe-4156-8f70-21072e04eb77"), new Guid("5e5b45b5-6bce-4e8c-a05a-eb6d5540f9ce"), "https://manuals.plus/wp-content/uploads/2022/03/HONDA-2022-CR-V-FEATURD3.jpg", 5, 5.9000000000000004, true, false, "Honda", 190, "CR-V", 37m, 2022, 5, 53.0, 0 },
                    { new Guid("eea3a59b-1d08-47d5-82f5-863384b9df71"), new Guid("a69fe7ac-6ad4-403f-ba76-eefbc3a691c6"), "https://www.ramtrucks.com/content/dam/fca-brands/na/ramtrucks/en_us/2025/ram-1500/gallery/desktop/my25-ram-1500-gallery-open-1-d.jpg", 4, 15.699999999999999, false, false, "RAM", 190, "1500", 317.28m, 2024, 6, 125.0, 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("04f4c07e-045d-457e-af60-b0397cf81225"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("0f3815d0-37b0-440d-978f-22fe3d9416cc"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("29480900-2b63-4503-8818-647fde2a47e5"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("3f821603-c82c-4b46-bc94-8a246e5ca4c1"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("41f5527c-c52b-409c-a6e8-74e8f6497c80"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("4590f15d-634b-4a10-9f69-32a88931922f"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("77b5fe3d-be73-4089-8512-b6665370a2ec"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("8326b7a1-6a93-46c4-89eb-d1a50330e3b6"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("99fed59f-dce8-4359-8ccb-88efa7781faa"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("ba7f77e9-e054-4ec9-8f11-2d7346ea80b5"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("cbc0f0df-2fbf-4d87-ab77-c214efa3e363"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("e3ea8915-979c-478f-b597-4b50e5f31cfd"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("e5a47d2a-68fe-4156-8f70-21072e04eb77"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("eea3a59b-1d08-47d5-82f5-863384b9df71"));
        }
    }
}
