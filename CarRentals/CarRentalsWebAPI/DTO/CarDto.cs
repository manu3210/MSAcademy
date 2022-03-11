using CarRentals.Enum;

namespace CarRentalsWebAPI.DTO
{
    public class CarDto
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int Doors { get; set; }
        public string Color { get; set; }
        public Transmition Transmition { get; set; }
        public BrandDto Brand { get; set; }
        public bool IsRented { get; set; }
    }
}
