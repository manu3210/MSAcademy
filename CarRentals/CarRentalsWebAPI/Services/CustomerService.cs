using CarRentals.Models;
using CarRentalsWebAPI.Interfaces;
using System.Collections.Generic;

namespace CarRentalsWebAPI.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public Customer Create(Customer Customer)
        {
            var newCustomer = _repository.Create(Customer);

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
