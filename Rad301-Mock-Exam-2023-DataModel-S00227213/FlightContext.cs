using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rad301_Mock_Exam_2023_DataModel_S00227213
{
    using Microsoft.EntityFrameworkCore;
    using Tracker.WebAPIClient;

    public class FlightContext : DbContext
    {
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Passenger> Passengers { get; set; }

        public FlightContext(DbContextOptions<FlightContext> options)
            : base(options)
        {
            // Add the track message in the constructor
            ActivityAPIClient.Track(StudentID: "S00227213", StudentName: "Jack Monaghan", activityName: "Rad301 Mock Exam 2023", Task: "Seeding Data Model");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flight>().HasData(
                new Flight { FlightId = 1, FlightNumber = "IT-001", DepartureDate = new DateTime(2021, 1, 12, 22, 0, 0), Origin = "Dublin", Destination = "Rome", Country = "Italy", MaxSeats = 110 },
                new Flight { FlightId = 2, FlightNumber = "EN-002", DepartureDate = new DateTime(2022, 1, 23, 12, 50, 0), Origin = "Dublin", Destination = "London", Country = "England", MaxSeats = 110 },
                new Flight { FlightId = 3, FlightNumber = "FR-001", DepartureDate = new DateTime(2022, 1, 4, 7, 0, 0), Origin = "Dublin", Destination = "Paris", Country = "France", MaxSeats = 120 },
                new Flight { FlightId = 4, FlightNumber = "BE-001", DepartureDate = new DateTime(2022, 1, 5, 16, 30, 0), Origin = "Dublin", Destination = "Brussels", Country = "Belgium", MaxSeats = 88 },
                new Flight { FlightId = 5, FlightNumber = "DU-001", DepartureDate = new DateTime(2022, 1, 24, 11, 0, 0), Origin = "London", Destination = "Dublin", Country = "Ireland", MaxSeats = 110 }
            );

            modelBuilder.Entity<Passenger>().HasData(
                new Passenger { PassengerId = 1, Name = "Fred Farnell", TicketType = "Economy", TicketPrice = 51.83m, BaggageCharge = 30.00m, FlightId = 2 },
                new Passenger { PassengerId = 2, Name = "Tom Mc Manus", TicketType = "First Class", TicketPrice = 127.00m, BaggageCharge = 10.00m, FlightId = 2 },
                new Passenger { PassengerId = 3, Name = "Bill Trimble", TicketType = "First Class", TicketPrice = 140.00m, BaggageCharge = 10.00m, FlightId = 3 },
                new Passenger { PassengerId = 4, Name = "Freda Mc Donald", TicketType = "Economy", TicketPrice = 50.92m, BaggageCharge = 15.00m, FlightId = 4 },
                new Passenger { PassengerId = 5, Name = "Mary Malone", TicketType = "Economy", TicketPrice = 66.22m, BaggageCharge = 15.00m, FlightId = 1 },
                new Passenger { PassengerId = 6, Name = "Tom Mc Manus", TicketType = "First Class", TicketPrice = 127.00m, BaggageCharge = 10.00m, FlightId = 5 }
            );
        }

    }

}
