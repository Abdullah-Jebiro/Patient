using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeBirthdateToBirthDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("674a2e8e-a19b-4f99-bdee-c75538fe2c1e"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("fb8483ec-6049-4318-92c6-b1006d47f851"));

            migrationBuilder.RenameColumn(
                name: "Birthdate",
                table: "Patients",
                newName: "BirthDate");

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Address1", "Address2", "BirthDate", "CitizenId", "City", "ContactPerson", "ContactPhone", "ContactRelation", "Country", "Email", "FileNo", "FirstVisitDate", "Gender", "Name", "Nationality", "PhoneNumber", "RecordCreationDate", "Street" },
                values: new object[,]
                {
                    { new Guid("2851f77e-bb54-4aa6-af5a-749606e3eb6b"), "Apartment 4A", "Building XYZ", new DateTime(1985, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "123456789", "New York", "Jane Smith", "987-654-3210", "Spouse", "United States", "john.doe@example.com", 1001, new DateTime(2022, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "John Doe", "USA", "123-456-7890", new DateTime(2023, 8, 8, 23, 37, 59, 544, DateTimeKind.Local).AddTicks(8249), "123 Main Street" },
                    { new Guid("ad9c32c2-6ed6-4357-8e4b-c0ba74508642"), "Suite 8B", "Tower ABC", new DateTime(1990, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "987654321", "Toronto", "John Doe", "444-789-1234", "Sibling", "Canada", "jane.smith@example.com", 1002, new DateTime(2021, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Jane Smith", "Canada", "555-123-4567", new DateTime(2023, 8, 8, 23, 37, 59, 544, DateTimeKind.Local).AddTicks(8274), "456 Elm Street" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("2851f77e-bb54-4aa6-af5a-749606e3eb6b"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("ad9c32c2-6ed6-4357-8e4b-c0ba74508642"));

            migrationBuilder.RenameColumn(
                name: "BirthDate",
                table: "Patients",
                newName: "Birthdate");

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Address1", "Address2", "Birthdate", "CitizenId", "City", "ContactPerson", "ContactPhone", "ContactRelation", "Country", "Email", "FileNo", "FirstVisitDate", "Gender", "Name", "Nationality", "PhoneNumber", "RecordCreationDate", "Street" },
                values: new object[,]
                {
                    { new Guid("674a2e8e-a19b-4f99-bdee-c75538fe2c1e"), "Apartment 4A", "Building XYZ", new DateTime(1985, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "123456789", "New York", "Jane Smith", "987-654-3210", "Spouse", "United States", "john.doe@example.com", 1001, new DateTime(2022, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "John Doe", "USA", "123-456-7890", new DateTime(2023, 8, 8, 20, 54, 37, 188, DateTimeKind.Local).AddTicks(128), "123 Main Street" },
                    { new Guid("fb8483ec-6049-4318-92c6-b1006d47f851"), "Suite 8B", "Tower ABC", new DateTime(1990, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "987654321", "Toronto", "John Doe", "444-789-1234", "Sibling", "Canada", "jane.smith@example.com", 1002, new DateTime(2021, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Jane Smith", "Canada", "555-123-4567", new DateTime(2023, 8, 8, 20, 54, 37, 188, DateTimeKind.Local).AddTicks(175), "456 Elm Street" }
                });
        }
    }
}
