using CarRentalsWebAPI.Interfaces;
using Models;
using System.Collections.Generic;

namespace CarRentalsWebAPI.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _repository;

        public CarService(ICarRepository repository)
        {
            _repository = repository;
        }

        public Car Create(Car brand)
        {
            var newBrand = _repository.Create(brand);

            return newBrand;
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
