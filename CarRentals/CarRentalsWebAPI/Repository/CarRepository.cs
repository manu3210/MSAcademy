using CarRentalsWebAPI.Interfaces;
using CarRentalsWebAPI.Models;
using Models;

namespace CarRentalsWebAPI.Repository
{
    public class CarRepository : Repository<Car>, ICarRepository
    {
        public CarRepository(CarRentalsContext context) : base(context) { }

        protected override void UpdateData(Car element, Car toUpdate)
        {
            toUpdate.Doors = element.Doors;
            toUpdate.Brand = element.Brand;
            toUpdate.Color = element.Color;
            toUpdate.IsRented = element.IsRented;
            toUpdate.Transmition = element.Transmition;
            toUpdate.Model = element.Model;
        }
    }
}
