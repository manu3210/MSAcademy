using CarRentals.Enum;
using CarRentals.Interfaces;
using CarRentalsWebAPI.Models;

namespace Models
{
    public class Car : IModelForCrud
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int Doors { get; set; }
        public string Color { get; set; }
        public Transmition Transmition { get; set; }
        public Brand Brand { get; set; }
        public bool IsRented { get; set; }
    }
}
