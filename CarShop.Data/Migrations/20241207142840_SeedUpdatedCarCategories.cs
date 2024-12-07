using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedUpdatedCarCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    { new Guid("264e1f65-36e4-44fb-9605-64bec9b9ed7a"), "Coupe" },
                    { new Guid("47b3ba7c-8aaa-450d-bf9f-847106fc8e02"), "Roadster" },
                    { new Guid("5e5b45b5-6bce-4e8c-a05a-eb6d5540f9ce"), "SUV" },
                    { new Guid("8e86c12d-4d99-4c26-be13-befca7323ab3"), "Convertible" },
                    { new Guid("91ac82e0-9aa7-4d53-bba4-cd8128c0b629"), "Hatchback" },
                    { new Guid("9c8e3ead-80a2-45c6-afba-91248baebef3"), "Sports car" },
                    { new Guid("a69fe7ac-6ad4-403f-ba76-eefbc3a691c6"), "Pickup truck" },
                    { new Guid("df2cdc1f-46c7-428b-a54b-e03eb0e33a7f"), "Sedan" },
                    { new Guid("efdd48c4-fa58-48d9-8b86-0b9c3f0d64a6"), "Minivan" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CarCategories",
                keyColumn: "Id",
                keyValue: new Guid("264e1f65-36e4-44fb-9605-64bec9b9ed7a"));

            migrationBuilder.DeleteData(
                table: "CarCategories",
                keyColumn: "Id",
                keyValue: new Guid("47b3ba7c-8aaa-450d-bf9f-847106fc8e02"));

            migrationBuilder.DeleteData(
                table: "CarCategories",
                keyColumn: "Id",
                keyValue: new Guid("5e5b45b5-6bce-4e8c-a05a-eb6d5540f9ce"));

            migrationBuilder.DeleteData(
                table: "CarCategories",
                keyColumn: "Id",
                keyValue: new Guid("8e86c12d-4d99-4c26-be13-befca7323ab3"));

            migrationBuilder.DeleteData(
                table: "CarCategories",
                keyColumn: "Id",
                keyValue: new Guid("91ac82e0-9aa7-4d53-bba4-cd8128c0b629"));

            migrationBuilder.DeleteData(
                table: "CarCategories",
                keyColumn: "Id",
                keyValue: new Guid("9c8e3ead-80a2-45c6-afba-91248baebef3"));

            migrationBuilder.DeleteData(
                table: "CarCategories",
                keyColumn: "Id",
                keyValue: new Guid("a69fe7ac-6ad4-403f-ba76-eefbc3a691c6"));

            migrationBuilder.DeleteData(
                table: "CarCategories",
                keyColumn: "Id",
                keyValue: new Guid("df2cdc1f-46c7-428b-a54b-e03eb0e33a7f"));

            migrationBuilder.DeleteData(
                table: "CarCategories",
                keyColumn: "Id",
                keyValue: new Guid("efdd48c4-fa58-48d9-8b86-0b9c3f0d64a6"));

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
        }
    }
}
