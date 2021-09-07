using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
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


        public static string JsonFilePath()
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            var configuration = builder.Build();
            string path = configuration["JsonFile"];
            return path;
        }



















        static void Test(CarCRUD carControl)
        {
            Console.WriteLine("\n\n\n" + carControl.ReadFile());
            Console.ReadKey();
        }
    }
}
