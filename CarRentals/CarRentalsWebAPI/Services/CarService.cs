using CarRentalsWebAPI.Interfaces;
using CarRentalsWebAPI.Models;

namespace CarRentalsWebAPI.Services
{
    public class CarService : Service<Car>, ICarService
    {
        public CarService(IDataProcessing<Car> repository) : base(repository) { }
    }
}
