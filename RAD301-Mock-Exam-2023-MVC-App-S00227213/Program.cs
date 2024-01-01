using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Tracker.WebAPIClient;

// This is the main entry point for the MVC application.
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// This line adds the necessary services for MVC pattern support.
builder.Services.AddControllersWithViews();

// Build the application.
var app = builder.Build();

// Configure the HTTP request pipeline.
// This section sets up middleware components for handling requests.
if (!app.Environment.IsDevelopment())
{
    // If the app is not in development, use the exception handler for production.
    app.UseExceptionHandler("/Home/Error");

    // Use HTTPS Strict Transport Security Protocol.
    // This is a security feature that prevents downgrade attacks and cookie hijacking.
    app.UseHsts();
}

// Enable HTTPS redirection, which redirects all HTTP requests to HTTPS.
app.UseHttpsRedirection();

// Enable serving static files like images, CSS, and JavaScript files.
app.UseStaticFiles();

// Enable routing, which is required to map incoming requests to the correct controller and action.
app.UseRouting();

// Enable authorization, which allows the application to secure resources with authentication and authorization.
app.UseAuthorization();

// Define the default route for the application.
// This route specifies that the default controller is Home, and the default action is Index.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Here we are adding a custom track message to monitor the activity in the application.
// Replace 's00227213' with your actual student ID and 'Jack Monaghan' with your actual name.
ActivityAPIClient.Track(StudentID: "s00227213", StudentName: "Jack Monaghan",
                        activityName: "Rad301 Mock Exam 2023", Task: "Exam Start");

// Run the application.
app.Run();
