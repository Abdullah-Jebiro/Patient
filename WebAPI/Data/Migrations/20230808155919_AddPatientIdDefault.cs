using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPatientIdDefault : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("709b7361-81cd-454f-b383-e22625a8d599"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("7fa8643f-6c0a-4e68-8f67-789aa58a3226"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Patients",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Address1", "Address2", "Birthdate", "CitizenId", "City", "ContactPerson", "ContactPhone", "ContactRelation", "Country", "Email", "FileNo", "FirstVisitDate", "Gender", "Name", "Nationality", "PhoneNumber", "RecordCreationDate", "Street" },
                values: new object[,]
                {
                    { new Guid("0b012b07-f109-4b55-9057-782cae29d675"), "Suite 8B", "Tower ABC", new DateTime(1990, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "987654321", "Toronto", "John Doe", "444-789-1234", "Sibling", "Canada", "jane.smith@example.com", 1002, new DateTime(2021, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Jane Smith", "Canada", "555-123-4567", new DateTime(2023, 8, 8, 18, 59, 18, 970, DateTimeKind.Local).AddTicks(1351), "456 Elm Street" },
                    { new Guid("640d6a12-7f39-48ba-bf48-482b70efead0"), "Apartment 4A", "Building XYZ", new DateTime(1985, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "123456789", "New York", "Jane Smith", "987-654-3210", "Spouse", "United States", "john.doe@example.com", 1001, new DateTime(2022, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "John Doe", "USA", "123-456-7890", new DateTime(2023, 8, 8, 18, 59, 18, 970, DateTimeKind.Local).AddTicks(1322), "123 Main Street" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("0b012b07-f109-4b55-9057-782cae29d675"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("640d6a12-7f39-48ba-bf48-482b70efead0"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Patients",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "NEWID()");

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Address1", "Address2", "Birthdate", "CitizenId", "City", "ContactPerson", "ContactPhone", "ContactRelation", "Country", "Email", "FileNo", "FirstVisitDate", "Gender", "Name", "Nationality", "PhoneNumber", "RecordCreationDate", "Street" },
                values: new object[,]
                {
                    { new Guid("709b7361-81cd-454f-b383-e22625a8d599"), "Apartment 4A", "Building XYZ", new DateTime(1985, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "123456789", "New York", "Jane Smith", "987-654-3210", "Spouse", "United States", "john.doe@example.com", 1001, new DateTime(2022, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "John Doe", "USA", "123-456-7890", new DateTime(2023, 8, 8, 18, 49, 4, 312, DateTimeKind.Local).AddTicks(8815), "123 Main Street" },
                    { new Guid("7fa8643f-6c0a-4e68-8f67-789aa58a3226"), "Suite 8B", "Tower ABC", new DateTime(1990, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "987654321", "Toronto", "John Doe", "444-789-1234", "Sibling", "Canada", "jane.smith@example.com", 1002, new DateTime(2021, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Jane Smith", "Canada", "555-123-4567", new DateTime(2023, 8, 8, 18, 49, 4, 312, DateTimeKind.Local).AddTicks(8851), "456 Elm Street" }
                });
        }
    }
}
