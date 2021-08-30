using CarRentals.Enum;
using System;
using System.Text;

namespace CarRentals
{
    public class Car
    {

        public int Id { get; set; }
        public int Model { get; set; }
        public int Doors { get; set; }
        public string Color { get; set; }
        public Transmition Transmition { get; set; }
        public Brand Brand { get; set; }

        public Car(int id, int model, int doors, string color, Transmition transmition, Brand brand)
        {
            this.Model = model;
            this.Doors = doors;
            this.Color = color;
            this.Transmition = transmition;
            this.Brand = brand;
            this.Id = id;
        }

        public Car()
        {

        }

        public override string ToString()
        {
            return "id: " + Id + "\nModel: " + Model + "\nNumber of doors: " + Doors + "\nColor: " + Color + "\nTransmition: " + Transmition.ToString() + "\nBrand: " + Brand.ToString();
        }


    }
}
