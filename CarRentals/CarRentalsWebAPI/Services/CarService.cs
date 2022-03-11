using CarRentalsWebAPI.Interfaces;
using CarRentalsWebAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRentalsWebAPI.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _repository;

        public CarService(ICarRepository repository)
        {
            _repository = repository;
        }

        public async Task<Car> CreateAsync(Car car)
        {
            var newCar = await _repository.CreateAsync(car);

            return newCar;
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<Car> GetAsync(int id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<List<Car>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Car> UpdateAsync(int id, Car element)
        {
            return await _repository.UpdateAsync(id, element);
        }
    }
}
