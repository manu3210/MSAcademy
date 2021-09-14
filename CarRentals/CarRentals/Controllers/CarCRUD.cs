using CarRentals.Controllers;
using Models;

namespace CarRentals
{
    public class CarCRUD : JsonStorage<Car>
    {
        public CarCRUD(JsonFile configuration) : base(configuration.CarsJsonFile)
        {

        }

        public override Car Update(Car car)
        {
            var toUpdate = Get(car.Id);

            toUpdate.Doors = car.Doors;
            toUpdate.Brand = car.Brand;
            toUpdate.Color = car.Color;
            toUpdate.Model = car.Model;
            toUpdate.Transmition = car.Transmition;

            SaveChanges(List);
            return car;
        }
    }
}
