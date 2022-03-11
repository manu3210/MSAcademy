using CarRentals.Enum;

namespace CarRentalsWebAPI.Models
{
    public class Car : BaseModel
    {
        public string Model { get; set; }
        public int Doors { get; set; }
        public string Color { get; set; }
        public Transmition Transmition { get; set; }
        public Brand Brand { get; set; }
        public bool IsRented { get; set; }
    }
}
