using System;
using System.Linq;
using Tracker.WebAPIClient;
using Rad301_Mock_Exam_2023_DataModel_S00227213;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Configure DbContextOptions for FlightContext
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var dbContextOptions = new DbContextOptionsBuilder<FlightContext>()
            .UseSqlServer(configuration.GetConnectionString("FlightContextConnection"))
            .Options;

        // Insert the ActivityAPIClient.Track call
        ActivityAPIClient.Track(StudentID: "S00227213", StudentName: "Jack Monaghan", activityName: "Rad301 Mock Exam 2023", Task: "Running Console Queries");

        Console.WriteLine("Hello, World!");

        // Call your methods here and pass dbContextOptions
        list_passengers(1, dbContextOptions);
        list_flight_revenue(dbContextOptions);
        add_new_flight_and_passenger(dbContextOptions);

        Console.ReadLine();
    }

    // Method to list passengers for a given flight
    static void list_passengers(int flightId, DbContextOptions<FlightContext> options)
    {
        using (var context = new FlightContext(options))
        {
            var passengers = context.Passengers
                                    .Where(p => p.FlightId == flightId)
                                    .Select(p => new { p.Name, p.TicketType, p.Flight.Destination })
                                    .ToList();

            foreach (var passenger in passengers)
            {
                Console.WriteLine($"Name: {passenger.Name}, Ticket Type: {passenger.TicketType}, Destination: {passenger.Destination}");
            }
        }
    }

    // Method to list total revenue for each flight
    static void list_flight_revenue(DbContextOptions<FlightContext> options)
    {
        using (var context = new FlightContext(options))
        {
            var flights = context.Flights
                                 .Select(f => new
                                 {
                                     f.FlightNumber,
                                     f.Destination,
                                     f.DepartureDate,
                                     Revenue = f.Passengers.Sum(p => p.TicketPrice + p.BaggageCharge)
                                 })
                                 .ToList();

            foreach (var flight in flights)
            {
                Console.WriteLine($"Flight Number: {flight.FlightNumber}, Destination: {flight.Destination}, Departure Date: {flight.DepartureDate}, Total Revenue: {flight.Revenue}");
            }
        }
    }

    static void add_new_flight_and_passenger(DbContextOptions<FlightContext> options)
    {
        using (var context = new FlightContext(options))
        {
            var newFlight = new Flight
            {
                FlightNumber = "DU-002",
                DepartureDate = new DateTime(2022, 6, 29, 11, 0, 0),
                Origin = "Dublin",
                Destination = "Sydney",
                Country = "Australia",
                MaxSeats = 210
            };

            var newPassenger = new Passenger
            {
                Name = "Martha Rotter",
                TicketType = "Business",
                TicketPrice = 399.0m,
                BaggageCharge = 30.0m
            
            };

            context.Flights.Add(newFlight);
            context.SaveChanges(); // This will generate FlightId

            newPassenger.FlightId = newFlight.FlightId; 
            context.Passengers.Add(newPassenger);

            context.SaveChanges();
        }
    }

}

