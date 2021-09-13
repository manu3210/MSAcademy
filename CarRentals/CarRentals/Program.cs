using CarRentals.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Models;
using System;
using System.IO;
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

                    if(!Directory.Exists("Data"))
                    {
                        Directory.CreateDirectory("Data");
                    }

                    var CarOptions = new ProgramOptions();
                    CarOptions.JsonFile = configurationRoot[ProgramOptions.sectionCarsName];

                    var CustomerOptions = new ProgramOptions();
                    CustomerOptions.JsonFile = configurationRoot[ProgramOptions.sectionCustomersName];

                    var carControl = new CarCRUD(CarOptions);
                    //Test(carControl);

                    var customerControl = new CustomerCRUD(CustomerOptions);
                    CustomerTest(customerControl);
                });
        static void Test(CarCRUD Control)
        {
            //Control.Update(new Car() { Id = 5, Brand = Enum.Brand.Fiat, Color = "Red", Doors = 2, Model = 2020, Transmition = Enum.Transmition.Automatic });
            Console.WriteLine("\n\n\n" + Control.Json.ReadFile());
            Console.ReadKey();
        }

        static void CustomerTest(CustomerCRUD Control)
        {
            //Control.Update(new Models.Customer { Id = 1, Adress = "Luro 2541", City = "Mar del Plata", Dni = "32165421", FirstName = "Emanuel", LastName = "Rivas", Phone = "2236543211", Province = "Buenos Aires", ZipCode = 7600, LastModification = DateTime.UtcNow });
            Console.WriteLine("\n\n\n" + Control.Json.ReadFile());
            Console.ReadKey();
        }
    }
}
