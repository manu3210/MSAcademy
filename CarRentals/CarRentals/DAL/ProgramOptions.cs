using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentals
{
    public class ProgramOptions
    {
        public static string sectionCarsName = "JsonFile:CarsJsonFile";
        public static string sectionCustomersName = "JsonFile:CustomersJsonFile";
        public static string sectionRentalsName = "JsonFile:RentalsJsonFile";
        public string JsonFile { get; set; }
    }
}
