using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedMissingDbSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CarCategories",
                keyColumn: "Id",
                keyValue: new Guid("2c5cf880-2c46-4c3c-b3c6-8973c97aefca"));

            migrationBuilder.DeleteData(
                table: "CarCategories",
                keyColumn: "Id",
                keyValue: new Guid("30bf3a89-6f37-40dd-aa77-1dd7cd53c055"));

            migrationBuilder.DeleteData(
                table: "CarCategories",
                keyColumn: "Id",
                keyValue: new Guid("591901ff-3a4b-404d-a134-def5d5204b5f"));

            migrationBuilder.DeleteData(
                table: "CarCategories",
                keyColumn: "Id",
                keyValue: new Guid("5f8f3579-3a00-44ad-943e-f326e5826a3e"));

            migrationBuilder.DeleteData(
                table: "CarCategories",
                keyColumn: "Id",
                keyValue: new Guid("760afc14-be66-47b0-ad76-c1ec28177ca7"));

            migrationBuilder.DeleteData(
                table: "CarCategories",
                keyColumn: "Id",
                keyValue: new Guid("7c76a145-2f67-49aa-96be-488c97c532bd"));

            migrationBuilder.DeleteData(
                table: "CarCategories",
                keyColumn: "Id",
                keyValue: new Guid("7f28935f-f0cd-45c7-8043-cc4e2733a457"));

            migrationBuilder.DeleteData(
                table: "CarCategories",
                keyColumn: "Id",
                keyValue: new Guid("80fd0fb7-39ab-4adb-8b2d-1f4f42feb032"));

            migrationBuilder.DeleteData(
                table: "CarCategories",
                keyColumn: "Id",
                keyValue: new Guid("aa0bcc23-4564-424f-9ffd-ee65eca655ce"));

            migrationBuilder.InsertData(
                table: "CarCategories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[,]
                {
                    { new Guid("1338a480-86d6-4e13-9487-75332a5693b8"), "Sedan" },
                    { new Guid("2abe6cde-7922-425f-9434-c32397936e68"), "Coupe" },
                    { new Guid("2fa2dbcc-9c7b-48f7-accb-997ad67b9221"), "Pickup truck" },
                    { new Guid("3c056cb6-33f1-493b-b74a-46a170bfa65f"), "Hatchback" },
                    { new Guid("5731cf38-645f-408b-861d-164af7e21ace"), "Convertible" },
                    { new Guid("59596ccc-8122-470b-8c44-31c2a68f89c2"), "Sports car" },
                    { new Guid("8915e1f3-00a9-47d1-ad9f-eae55df9025b"), "SUV" },
                    { new Guid("8dbeaf5e-ad68-4fcc-a792-6a9426d69bb3"), "Minivan" },
                    { new Guid("97cbcbfa-2cc7-45f9-88f9-e5bfcf8a3a9a"), "Roadster" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CarCategories",
                keyColumn: "Id",
                keyValue: new Guid("1338a480-86d6-4e13-9487-75332a5693b8"));

            migrationBuilder.DeleteData(
                table: "CarCategories",
                keyColumn: "Id",
                keyValue: new Guid("2abe6cde-7922-425f-9434-c32397936e68"));

            migrationBuilder.DeleteData(
                table: "CarCategories",
                keyColumn: "Id",
                keyValue: new Guid("2fa2dbcc-9c7b-48f7-accb-997ad67b9221"));

            migrationBuilder.DeleteData(
                table: "CarCategories",
                keyColumn: "Id",
                keyValue: new Guid("3c056cb6-33f1-493b-b74a-46a170bfa65f"));

            migrationBuilder.DeleteData(
                table: "CarCategories",
                keyColumn: "Id",
                keyValue: new Guid("5731cf38-645f-408b-861d-164af7e21ace"));

            migrationBuilder.DeleteData(
                table: "CarCategories",
                keyColumn: "Id",
                keyValue: new Guid("59596ccc-8122-470b-8c44-31c2a68f89c2"));

            migrationBuilder.DeleteData(
                table: "CarCategories",
                keyColumn: "Id",
                keyValue: new Guid("8915e1f3-00a9-47d1-ad9f-eae55df9025b"));

            migrationBuilder.DeleteData(
                table: "CarCategories",
                keyColumn: "Id",
                keyValue: new Guid("8dbeaf5e-ad68-4fcc-a792-6a9426d69bb3"));

            migrationBuilder.DeleteData(
                table: "CarCategories",
                keyColumn: "Id",
                keyValue: new Guid("97cbcbfa-2cc7-45f9-88f9-e5bfcf8a3a9a"));

            migrationBuilder.InsertData(
                table: "CarCategories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[,]
                {
                    { new Guid("2c5cf880-2c46-4c3c-b3c6-8973c97aefca"), "Sports car" },
                    { new Guid("30bf3a89-6f37-40dd-aa77-1dd7cd53c055"), "Coupe" },
                    { new Guid("591901ff-3a4b-404d-a134-def5d5204b5f"), "SUV" },
                    { new Guid("5f8f3579-3a00-44ad-943e-f326e5826a3e"), "Roadster" },
                    { new Guid("760afc14-be66-47b0-ad76-c1ec28177ca7"), "Hatchback" },
                    { new Guid("7c76a145-2f67-49aa-96be-488c97c532bd"), "Minivan" },
                    { new Guid("7f28935f-f0cd-45c7-8043-cc4e2733a457"), "Sedan" },
                    { new Guid("80fd0fb7-39ab-4adb-8b2d-1f4f42feb032"), "Convertible" },
                    { new Guid("aa0bcc23-4564-424f-9ffd-ee65eca655ce"), "Pickup truck" }
                });
        }
    }
}
