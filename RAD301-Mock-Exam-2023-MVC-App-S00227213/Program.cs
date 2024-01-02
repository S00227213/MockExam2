using Tracker.WebAPIClient;
using Microsoft.EntityFrameworkCore;
using Rad301_Mock_Exam_2023_DataModel_S00227213;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure the FlightContext with the connection string from appsettings.json
builder.Services.AddDbContext<FlightContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FlightContextConnection")));

var app = builder.Build();

// Insert the ActivityAPIClient.Track call here
ActivityAPIClient.Track(StudentID: "S00227213", StudentName: "Your Name", activityName: "Rad301 Mock Exam 2023", Task: "Exam Start");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
