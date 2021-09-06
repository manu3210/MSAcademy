using CarRentals.Enum;
using System;
using System.Text;

namespace Models
{
    public class Car
    {
        public int Id { get; set; }
        public int Model { get; set; }
        public int Doors { get; set; }
        public string Color { get; set; }
        public Transmition Transmition { get; set; }
        public Brand Brand { get; set; }

        public Car()
        {

        }

        public override string ToString()
        {
            return "id: " + Id + "\nModel: " + Model + "\nNumber of doors: " + Doors + "\nColor: " + Color + "\nTransmition: " + Transmition.ToString() + "\nBrand: " + Brand.ToString();
        }


    }
}
