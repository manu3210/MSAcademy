using CarRentals.Models;
using CarRentalsWebAPI.Interfaces;
using System.Collections.Generic;

namespace CarRentalsWebAPI.Services
{
    public class RentalService : IRentalService
    {
        private readonly IRentalRepository _repository;

        public RentalService(IRentalRepository repository)
        {
            _repository = repository;
        }

        public Rental Create(Rental rental)
        {
            var newRental = _repository.Create(rental);

            return newRental;
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public Rental Get(int id)
        {
            return _repository.Get(id);
        }

        public List<Rental> GetAll()
        {
            return _repository.GetAll();
        }

        public Rental Update(int id, Rental element)
        {
            return _repository.Update(id, element);
        }
    }
}
