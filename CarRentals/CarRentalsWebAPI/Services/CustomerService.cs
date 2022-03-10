using CarRentalsWebAPI.Interfaces;
using CarRentalsWebAPI.Models;
using System.Threading.Tasks;
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

        public async Task<Customer> CreateAsync(Customer customer)
        {
            var list = await _repository.GetAll();

            foreach (Customer item in list)
            {
                if (item.Dni.Equals(customer.Dni))
                {
                    return null;
                }
            }

            var newCustomer = await _repository.CreateAsync(customer);

            return newCustomer;
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<Customer> GetAsync(int id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<List<Customer>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Customer> UpdateAsync(int id, Customer element)
        {
            return await _repository.UpdateAsync(id, element);
        }
    }
}
