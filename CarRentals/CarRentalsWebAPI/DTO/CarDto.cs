using CarRentals.Enum;
using Models;

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

        public CarDto() { }
        public CarDto(Car car)
        {
            Id = car.Id;
            Model = car.Model;
            Doors = car.Doors;
            Color = car.Color;
            Transmition = car.Transmition;
            Brand = new BrandDto(car.Brand);
            IsRented = car.IsRented;
        }

        public static Car DtoToEntity(CarDto dto)
        {
            var car = new Car();

            car.Id = dto.Id;
            car.Model = dto.Model;
            car.Doors = dto.Doors;
            car.Transmition = dto.Transmition;
            car.Brand = BrandDto.DtoToEntity(dto.Brand);
            car.IsRented = dto.IsRented;
            car.Color = dto.Color;

            return car;
        }
    }
}
