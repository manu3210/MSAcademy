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
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public Customer Create(Customer customer)
        {
            var list = _repository.GetAll();

            foreach (Customer item in list)
            {
                if (item.Dni.Equals(customer.Dni))
                {
                    return null;
                }
            }

            var newCustomer = _repository.Create(customer);

            return newCustomer;
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public Customer Get(int id)
        {
            return _repository.Get(id);
        }

        public List<Customer> GetAll()
        {
            return _repository.GetAll();
        }

        public Customer Update(int id, Customer element)
        {
            return _repository.Update(id, element);
        }
    }
}
