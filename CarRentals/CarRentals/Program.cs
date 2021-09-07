using CarRentals.Interfaces;
using System;

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
            IDataAccess DataAccess = new DataAccess();
            var carControl = new CarCRUD(DataAccess);

            Console.WriteLine(carControl.ReadFile());
            Console.ReadKey();
        }

        
    }
}
