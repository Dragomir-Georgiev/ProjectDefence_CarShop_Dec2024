using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangedCarAvailabilityDefaultValue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CarCategories",
                keyColumn: "Id",
                keyValue: new Guid("1efe34f6-0e1f-4054-a1b5-856ddf6c70ef"));

            migrationBuilder.DeleteData(
                table: "CarCategories",
                keyColumn: "Id",
                keyValue: new Guid("401a2e1a-8fea-44ac-9431-d19e1a2991d0"));

            migrationBuilder.DeleteData(
                table: "CarCategories",
                keyColumn: "Id",
                keyValue: new Guid("56214e27-720e-4d5e-b93b-bd08612399c6"));

            migrationBuilder.DeleteData(
                table: "CarCategories",
                keyColumn: "Id",
                keyValue: new Guid("6bf86d29-4d69-41c4-880e-ef7ffed27da0"));

            migrationBuilder.DeleteData(
                table: "CarCategories",
                keyColumn: "Id",
                keyValue: new Guid("70ace146-53a7-4896-aabc-2b9bcdf30082"));

            migrationBuilder.DeleteData(
                table: "CarCategories",
                keyColumn: "Id",
                keyValue: new Guid("8bde63ad-9d00-4f21-afd7-7de263957594"));

            migrationBuilder.DeleteData(
                table: "CarCategories",
                keyColumn: "Id",
                keyValue: new Guid("f288666d-c2a8-4664-b811-769f29f5ee2c"));

            migrationBuilder.DeleteData(
                table: "CarCategories",
                keyColumn: "Id",
                keyValue: new Guid("f8aad825-e528-4caa-aa5b-7c6ac552fe06"));

            migrationBuilder.DeleteData(
                table: "CarCategories",
                keyColumn: "Id",
                keyValue: new Guid("fa3d82ce-dcf2-43a9-b140-b4d74bc4245b"));

            migrationBuilder.AlterColumn<bool>(
                name: "IsAvailable",
                table: "Cars",
                type: "bit",
                nullable: false,
                defaultValue: true,
                comment: "Availability of the car",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Availability of the car");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<bool>(
                name: "IsAvailable",
                table: "Cars",
                type: "bit",
                nullable: false,
                comment: "Availability of the car",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true,
                oldComment: "Availability of the car");

            migrationBuilder.InsertData(
                table: "CarCategories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[,]
                {
                    { new Guid("1efe34f6-0e1f-4054-a1b5-856ddf6c70ef"), "Coupe" },
                    { new Guid("401a2e1a-8fea-44ac-9431-d19e1a2991d0"), "Sports car" },
                    { new Guid("56214e27-720e-4d5e-b93b-bd08612399c6"), "Sedan" },
                    { new Guid("6bf86d29-4d69-41c4-880e-ef7ffed27da0"), "Minivan" },
                    { new Guid("70ace146-53a7-4896-aabc-2b9bcdf30082"), "Convertible" },
                    { new Guid("8bde63ad-9d00-4f21-afd7-7de263957594"), "Pickup truck" },
                    { new Guid("f288666d-c2a8-4664-b811-769f29f5ee2c"), "Hatchback" },
                    { new Guid("f8aad825-e528-4caa-aa5b-7c6ac552fe06"), "SUV" },
                    { new Guid("fa3d82ce-dcf2-43a9-b140-b4d74bc4245b"), "Roadster" }
                });
        }
    }
}
