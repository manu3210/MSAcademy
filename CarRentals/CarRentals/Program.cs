using CarRentals.Enum;
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
            
            var carControl = new CarCRUD();

            //carControl.Create(car4);
            //carControl.Create(car3);
            //carControl.Create(car2);
            //carControl.Create(car1);

            //Console.WriteLine(carControl.Get(3).ToString());

            //carControl.Update(new Car(30, 2018, 3, "grey", Transmition.Manual, Brand.Volkswagen));

            //carControl.Delete(2);

            Console.WriteLine("\n\n\n" + carControl.ReadFile());
            Console.ReadKey();
        }
    }
}
