using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class MoreData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("2851f77e-bb54-4aa6-af5a-749606e3eb6b"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("ad9c32c2-6ed6-4357-8e4b-c0ba74508642"));

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Address1", "Address2", "BirthDate", "CitizenId", "City", "ContactPerson", "ContactPhone", "ContactRelation", "Country", "Email", "FileNo", "FirstVisitDate", "Gender", "Name", "Nationality", "PhoneNumber", "RecordCreationDate", "Street" },
                values: new object[,]
                {
                    { new Guid("bf6049b2-8332-4b86-b100-97a78c54e42a"), "Apartment 4A", "Building XYZ", new DateTime(1985, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "123456789", "New York", "Jane Smith", "987-654-3210", "Spouse", "United States", "john.doe@example.com", 1001, new DateTime(2022, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "John Doe", "USA", "123-456-7890", new DateTime(2023, 8, 9, 21, 36, 51, 802, DateTimeKind.Local).AddTicks(3671), "123 Main Street" },
                    { new Guid("0e8a99e3-4b1a-4376-b252-0efdd125ded7"), "Suite 8B", "Tower ABC", new DateTime(1990, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "987654321", "Toronto", "John Doe", "444-789-1234", "Sibling", "Canada", "jane.smith@example.com", 1002, new DateTime(2021, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Jane Smith", "Canada", "555-123-4567", new DateTime(2023, 8, 9, 21, 36, 51, 804, DateTimeKind.Local).AddTicks(3834), "456 Elm Street" },
                    { new Guid("509d5cdf-8fd6-44e5-bb45-392129abf62b"), "Flat 3C", "Manor Gardens", new DateTime(1998, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "789123456", "London", "Sophie Brown", "333-666-9999", "Friend", "United Kingdom", "emily.johnson@example.com", 1003, new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Emily Johnson", "United Kingdom", "222-555-8888", new DateTime(2023, 8, 9, 21, 36, 51, 804, DateTimeKind.Local).AddTicks(3929), "789 Park Lane" },
                    { new Guid("88bfd53c-531d-4893-8e31-208ad6dadbd3"), "Unit 12", "Coastal Towers", new DateTime(1973, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "555777888", "Sydney", "David Smith", "888-444-5555", "Colleague", "Australia", "michael.anderson@example.com", 1004, new DateTime(2022, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Michael Anderson", "Australia", "777-222-3333", new DateTime(2023, 8, 9, 21, 36, 51, 804, DateTimeKind.Local).AddTicks(3946), "321 Beach Road" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("0e8a99e3-4b1a-4376-b252-0efdd125ded7"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("509d5cdf-8fd6-44e5-bb45-392129abf62b"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("88bfd53c-531d-4893-8e31-208ad6dadbd3"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("bf6049b2-8332-4b86-b100-97a78c54e42a"));

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Address1", "Address2", "BirthDate", "CitizenId", "City", "ContactPerson", "ContactPhone", "ContactRelation", "Country", "Email", "FileNo", "FirstVisitDate", "Gender", "Name", "Nationality", "PhoneNumber", "RecordCreationDate", "Street" },
                values: new object[] { new Guid("2851f77e-bb54-4aa6-af5a-749606e3eb6b"), "Apartment 4A", "Building XYZ", new DateTime(1985, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "123456789", "New York", "Jane Smith", "987-654-3210", "Spouse", "United States", "john.doe@example.com", 1001, new DateTime(2022, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "John Doe", "USA", "123-456-7890", new DateTime(2023, 8, 8, 23, 37, 59, 544, DateTimeKind.Local).AddTicks(8249), "123 Main Street" });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Address1", "Address2", "BirthDate", "CitizenId", "City", "ContactPerson", "ContactPhone", "ContactRelation", "Country", "Email", "FileNo", "FirstVisitDate", "Gender", "Name", "Nationality", "PhoneNumber", "RecordCreationDate", "Street" },
                values: new object[] { new Guid("ad9c32c2-6ed6-4357-8e4b-c0ba74508642"), "Suite 8B", "Tower ABC", new DateTime(1990, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "987654321", "Toronto", "John Doe", "444-789-1234", "Sibling", "Canada", "jane.smith@example.com", 1002, new DateTime(2021, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Jane Smith", "Canada", "555-123-4567", new DateTime(2023, 8, 8, 23, 37, 59, 544, DateTimeKind.Local).AddTicks(8274), "456 Elm Street" });
        }
    }
}
