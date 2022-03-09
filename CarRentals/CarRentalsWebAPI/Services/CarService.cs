using CarRentalsWebAPI.Interfaces;
<<<<<<< HEAD
using CarRentalsWebAPI.Models;
=======
using Models;
using System.Collections.Generic;
>>>>>>> parent of 07f9100 (Created Generic Service Layer)

namespace CarRentalsWebAPI.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _repository;

        public CarService(ICarRepository repository)
        {
            _repository = repository;
        }

        public Car Create(Car car)
        {
            var newCar = _repository.Create(car);

            return newCar;
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public Car Get(int id)
        {
            return _repository.Get(id);
        }

        public List<Car> GetAll()
        {
            return _repository.GetAll();
        }

        public Car Update(int id, Car element)
        {
            return _repository.Update(id, element);
        }
    }
}
