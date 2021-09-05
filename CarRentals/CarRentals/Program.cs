using CarRentals.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Models;
using System;
using System.IO;

namespace CarRentals
{
    class Program
    {
        static void Main(string[] args)
        {
            Test();
        }

        static void Test ()
        {
            var carControl = new CarCRUD();

            //carControl.Create(car4);
            //carControl.Create(car3);
            //carControl.Create(car2);
            //carControl.Create(car1);

            //Console.WriteLine(carControl.Get(3).ToString());

            //carControl.Update(new Car(3, 2018, 3, "grey", Transmition.Manual, Brand.Volkswagen));

            //carControl.Delete(2);

            Console.WriteLine("\n\n\n" + carControl.ReadFile());
            Console.ReadKey();
        }

        public static string JsonFilePath ()
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            var configuration = builder.Build();
            string path = configuration["JsonFile"];
            return path;
        }
    }
}
