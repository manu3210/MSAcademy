using CarRentalsWebAPI.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace CarRentalsWebAPI.IntegrationTests
{
    public class TestingAppFactory<TEntryPoint> : WebApplicationFactory<Program> where TEntryPoint : Program
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType ==
                        typeof(DbContextOptions<CarRentalsContext>));

                if (descriptor != null)
                    services.Remove(descriptor);

                services.AddDbContext<CarRentalsContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryEmployeeTest");
                    options.EnableSensitiveDataLogging();
                });

                var sp = services.BuildServiceProvider();

                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<CarRentalsContext>();
                    var logger = scopedServices
                        .GetRequiredService<ILogger<TestingAppFactory<Program>>>();

                    db.Database.EnsureCreated();

                    Utilities.InitializeDbForTests(db);
                }
            });
        }
    }
}