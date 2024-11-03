using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedCarCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
