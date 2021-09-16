using CarRentals.Controllers;
using Models;

namespace CarRentals
{
    public class CarCRUD : JsonStorage<Car>
    {
        public CarCRUD(JsonFile configuration) : base(configuration.CarsJsonFile)
        {

        }

        protected override void UpdateData(Car element, Car toUpdate)
        {
            toUpdate.Doors = element.Doors;
            toUpdate.Brand = element.Brand;
            toUpdate.Color = element.Color;
            toUpdate.Model = element.Model;
            toUpdate.Transmition = element.Transmition;
        }
    }
}
