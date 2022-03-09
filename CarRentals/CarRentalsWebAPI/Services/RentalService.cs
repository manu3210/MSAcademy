<<<<<<< HEAD
﻿using CarRentalsWebAPI.Interfaces;
using CarRentalsWebAPI.Models;
using System.Threading.Tasks;
=======
﻿using CarRentals.Models;
using CarRentalsWebAPI.Interfaces;
using System.Collections.Generic;
>>>>>>> parent of 07f9100 (Created Generic Service Layer)

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
            if(validateRental(rental))
            {
                return _repository.Create(rental);
            }
            else
            {
                return null;
            }
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
            if(validateRental(element))
            {
                return _repository.Update(id, element);
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
