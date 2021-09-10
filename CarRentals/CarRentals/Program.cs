using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Models;
using System;
using System.Threading.Tasks;

namespace CarRentals
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();
            await host.RunAsync();
        }

        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, configuration) =>
                {
                    configuration.Sources.Clear();

                    configuration
                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

                    IConfigurationRoot configurationRoot = configuration.Build();

                    var options = new ProgramOptions();

                    options.JsonFile = configurationRoot[ProgramOptions.sectionName];

                    var carControl = new CarCRUD(options);
                    Test(carControl);
                });
        static void Test(CarCRUD Control)
        {
            //Control.Update(new Car() { Id = 5, Brand = Enum.Brand.Fiat, Color = "Black", Doors = 2, Model = 2020, Transmition = Enum.Transmition.Automatic });
            Console.WriteLine("\n\n\n" + Control.JsonFile.ReadFile());
            Console.ReadKey();
        }
    }
}
