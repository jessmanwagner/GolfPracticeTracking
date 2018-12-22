using System;
using GolfPracticeTracker.Data;
using GolfPracticeTracker.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace GolfPracticeTracker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    //Get a DB context instance from the dependency injection container.
                    var context = services.GetRequiredService<GolfPracticeTrackerContext>();
                    // After deleting database from SSOX, uncomment the following line and this will create the database
                    // Then comment it out and uncomment the DbInitializer to seed the database
                    //context.Database.EnsureCreated(); 
                    DbInitializer.Initialize(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB");
                }
            }
            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
