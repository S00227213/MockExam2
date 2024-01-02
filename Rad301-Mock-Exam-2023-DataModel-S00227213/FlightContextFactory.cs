using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Rad301_Mock_Exam_2023_DataModel_S00227213
{
    public class FlightContextFactory : IDesignTimeDbContextFactory<FlightContext>
    {
        public FlightContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) 
                .AddJsonFile("appsettings.json") 
                .Build();

            var builder = new DbContextOptionsBuilder<FlightContext>();
            var connectionString = configuration.GetConnectionString("FlightContextConnection");

            builder.UseSqlServer(connectionString);

            return new FlightContext(builder.Options);
        }
    }
}
