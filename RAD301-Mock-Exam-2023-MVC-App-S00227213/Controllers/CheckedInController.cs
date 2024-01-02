using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rad301_Mock_Exam_2023_DataModel_S00227213; 
using Tracker.WebAPIClient;

public class CheckedInController : Controller
{
    private readonly FlightContext _context;

    public CheckedInController(FlightContext context)
    {
        _context = context;

        // Tracker call
        ActivityAPIClient.Track(StudentID: "S00227213", StudentName: "Jack Monaghan",
            activityName: "Rad301 Mock Exam 2023", Task: "Creating Checkin Controller");
    }

    // Action to show passenger details for a specific flight
    public IActionResult Index(int flightId)
    {
        var passengers = _context.Passengers
            .Include(p => p.Flight) // Include the Flight navigation property
            .Where(p => p.FlightId == flightId)
            .ToList();
        return View(passengers);
    }

}
