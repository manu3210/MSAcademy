using CarRentalsWebAPI.Interfaces;
using CarRentalsWebAPI.Models;
using System.Threading.Tasks;
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

        public async Task<Rental> CreateAsync(Rental rental)
        {
            if(validateRental(rental))
            {
                return await _repository.CreateAsync(rental);
            }
            else
            {
                return null;
            }
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<Rental> GetAsync(int id)
        {
            return await _repository.GetAsync(id);
        }

        public List<Rental> GetAll()
        {
            return _repository.GetAll();
        }

        public async Task<Rental> UpdateAsync(int id, Rental element)
        {
            if(validateRental(element))
            {
                return await _repository.UpdateAsync(id, element);
            }
            else
            {
                return null;
            }
            
        }

        private bool validateRental(Rental rental)
        {
            
            if (rental.Car != null && rental.Customer != null && rental.End.Subtract(rental.Beginning).Days > 0)
            {
                if (rental.Car.IsRented == false)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
