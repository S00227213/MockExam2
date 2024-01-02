using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Rad301_Mock_Exam_2023_DataModel_S00227213.Migrations
{
    /// <inheritdoc />
    public partial class DataMigrationS00227213 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "FlightId", "Country", "DepartureDate", "Destination", "FlightNumber", "MaxSeats", "Origin" },
                values: new object[,]
                {
                    { 1, "Italy", new DateTime(2021, 1, 12, 22, 0, 0, 0, DateTimeKind.Unspecified), "Rome", "IT-001", 110, "Dublin" },
                    { 2, "England", new DateTime(2022, 1, 23, 12, 50, 0, 0, DateTimeKind.Unspecified), "London", "EN-002", 110, "Dublin" },
                    { 3, "France", new DateTime(2022, 1, 4, 7, 0, 0, 0, DateTimeKind.Unspecified), "Paris", "FR-001", 120, "Dublin" },
                    { 4, "Belgium", new DateTime(2022, 1, 5, 16, 30, 0, 0, DateTimeKind.Unspecified), "Brussels", "BE-001", 88, "Dublin" },
                    { 5, "Ireland", new DateTime(2022, 1, 24, 11, 0, 0, 0, DateTimeKind.Unspecified), "Dublin", "DU-001", 110, "London" }
                });

            migrationBuilder.InsertData(
                table: "Passengers",
                columns: new[] { "PassengerId", "BaggageCharge", "FlightId", "Name", "TicketPrice", "TicketType" },
                values: new object[,]
                {
                    { 1, 30.00m, 2, "Fred Farnell", 51.83m, "Economy" },
                    { 2, 10.00m, 2, "Tom Mc Manus", 127.00m, "First Class" },
                    { 3, 10.00m, 3, "Bill Trimble", 140.00m, "First Class" },
                    { 4, 15.00m, 4, "Freda Mc Donald", 50.92m, "Economy" },
                    { 5, 15.00m, 1, "Mary Malone", 66.22m, "Economy" },
                    { 6, 10.00m, 5, "Tom Mc Manus", 127.00m, "First Class" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Passengers",
                keyColumn: "PassengerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Passengers",
                keyColumn: "PassengerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Passengers",
                keyColumn: "PassengerId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Passengers",
                keyColumn: "PassengerId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Passengers",
                keyColumn: "PassengerId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Passengers",
                keyColumn: "PassengerId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "FlightId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "FlightId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "FlightId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "FlightId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "FlightId",
                keyValue: 5);
        }
    }
}
