using CarRentals.Controllers;
using Models;

namespace CarRentals
{
    public class CarCRUD : Crud<Car>
    {
        public CarCRUD(ProgramOptions configuration) : base(configuration)
        {

        }

        public override Car Update(Car car)
        {
            Car toUpdate = Get(car.Id);

            toUpdate.Doors = car.Doors;
            toUpdate.Brand = car.Brand;
            toUpdate.Color = car.Color;
            toUpdate.Model = car.Model;
            toUpdate.Transmition = car.Transmition;

            Json.SaveChanges(List);
            return car;
        }
    }
}
