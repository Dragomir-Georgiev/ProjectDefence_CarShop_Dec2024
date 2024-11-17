using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixedDbSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserRental_AspNetUsers_ApplicationUserId",
                table: "ApplicationUserRental");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserRental_Rentals_RentalId",
                table: "ApplicationUserRental");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUserRental",
                table: "ApplicationUserRental");

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

            migrationBuilder.RenameTable(
                name: "ApplicationUserRental",
                newName: "ApplicationsUsersRentals");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUserRental_RentalId",
                table: "ApplicationsUsersRentals",
                newName: "IX_ApplicationsUsersRentals_RentalId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationsUsersRentals",
                table: "ApplicationsUsersRentals",
                columns: new[] { "ApplicationUserId", "RentalId" });

            migrationBuilder.InsertData(
                table: "CarCategories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[,]
                {
                    { new Guid("245848e3-fb8c-4b1b-bde9-6f5c2672e371"), "Hatchback" },
                    { new Guid("4c67efd8-0760-4b86-9cbe-43e84b0285c4"), "Convertible" },
                    { new Guid("6ff430a9-89b8-4c9b-865e-d75ca3000d8f"), "Pickup truck" },
                    { new Guid("9dc4a6f4-c24e-43be-9eb0-89d6769ace30"), "Minivan" },
                    { new Guid("b063881f-c4f9-440f-8c8f-b4cde5e86b21"), "Coupe" },
                    { new Guid("ba0c459f-0557-48da-ae3f-775f13a7865a"), "SUV" },
                    { new Guid("d0e45564-1f90-4ac9-87dc-70bbf9dc468b"), "Roadster" },
                    { new Guid("e7fea868-aca6-4d89-adfc-bccc1a0cb36d"), "Sports car" },
                    { new Guid("e9bbe931-5369-4fe3-be28-2fb914dce985"), "Sedan" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationsUsersRentals_AspNetUsers_ApplicationUserId",
                table: "ApplicationsUsersRentals",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationsUsersRentals_Rentals_RentalId",
                table: "ApplicationsUsersRentals",
                column: "RentalId",
                principalTable: "Rentals",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationsUsersRentals_AspNetUsers_ApplicationUserId",
                table: "ApplicationsUsersRentals");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationsUsersRentals_Rentals_RentalId",
                table: "ApplicationsUsersRentals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationsUsersRentals",
                table: "ApplicationsUsersRentals");

            migrationBuilder.DeleteData(
                table: "CarCategories",
                keyColumn: "Id",
                keyValue: new Guid("245848e3-fb8c-4b1b-bde9-6f5c2672e371"));

            migrationBuilder.DeleteData(
                table: "CarCategories",
                keyColumn: "Id",
                keyValue: new Guid("4c67efd8-0760-4b86-9cbe-43e84b0285c4"));

            migrationBuilder.DeleteData(
                table: "CarCategories",
                keyColumn: "Id",
                keyValue: new Guid("6ff430a9-89b8-4c9b-865e-d75ca3000d8f"));

            migrationBuilder.DeleteData(
                table: "CarCategories",
                keyColumn: "Id",
                keyValue: new Guid("9dc4a6f4-c24e-43be-9eb0-89d6769ace30"));

            migrationBuilder.DeleteData(
                table: "CarCategories",
                keyColumn: "Id",
                keyValue: new Guid("b063881f-c4f9-440f-8c8f-b4cde5e86b21"));

            migrationBuilder.DeleteData(
                table: "CarCategories",
                keyColumn: "Id",
                keyValue: new Guid("ba0c459f-0557-48da-ae3f-775f13a7865a"));

            migrationBuilder.DeleteData(
                table: "CarCategories",
                keyColumn: "Id",
                keyValue: new Guid("d0e45564-1f90-4ac9-87dc-70bbf9dc468b"));

            migrationBuilder.DeleteData(
                table: "CarCategories",
                keyColumn: "Id",
                keyValue: new Guid("e7fea868-aca6-4d89-adfc-bccc1a0cb36d"));

            migrationBuilder.DeleteData(
                table: "CarCategories",
                keyColumn: "Id",
                keyValue: new Guid("e9bbe931-5369-4fe3-be28-2fb914dce985"));

            migrationBuilder.RenameTable(
                name: "ApplicationsUsersRentals",
                newName: "ApplicationUserRental");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationsUsersRentals_RentalId",
                table: "ApplicationUserRental",
                newName: "IX_ApplicationUserRental_RentalId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUserRental",
                table: "ApplicationUserRental",
                columns: new[] { "ApplicationUserId", "RentalId" });

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

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserRental_AspNetUsers_ApplicationUserId",
                table: "ApplicationUserRental",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserRental_Rentals_RentalId",
                table: "ApplicationUserRental",
                column: "RentalId",
                principalTable: "Rentals",
                principalColumn: "Id");
        }
    }
}
