using CarRentals.Enum;
using CarRentals.Exceptions;
using Models;
using System;

namespace CarRentals
{
    class Program
    {
        static void Main(string[] args)
        {
            var car1 = new Car(1, 2020, 5, "Red", Transmition.Manual, Brand.Chevrolet);
            var car2 = new Car(2, 2021, 5, "Blue", Transmition.Automatic, Brand.Peugeot);
            var car3 = new Car(3, 2018, 3, "White", Transmition.Manual, Brand.Volkswagen);
            var car4 = new Car(4, 2019, 3, "Black", Transmition.Manual, Brand.Renault);
            
            CarCRUD option = new CarCRUD();
            
            option.Create(car4);
            option.Create(car3);
            option.Create(car2);
            option.Create(car1);

            

            option.Update(new Car(3, 2018, 3, "grey", Transmition.Manual, Brand.Volkswagen));

            //option.Delete(2);

            //try
            //{
            //    Console.WriteLine(option.Get(2).ToString());
            //}
            //catch (CarNotFoundException e)
            //{
            //    Console.WriteLine(e.Message);
            //}

            Console.WriteLine("\n\n\n" + option.ReadFile());
            Console.ReadKey();
        }
    }
}
