using CarRentalsWebAPI.Interfaces;
using CarRentalsWebAPI.Models;
using System.Threading.Tasks;

namespace CarRentalsWebAPI.Services
{
    public class CustomerService : Service<Customer>, ICustomerService
    {
        public CustomerService(IDataProcessing<Customer> repository) : base(repository) { }

        public async override Task<Customer> CreateAsync(Customer element)
        {
            var list = GetAll();

            foreach (Customer item in list)
            {
                if (item.Dni.Equals(element.Dni))
                {
                    return null;
                }
            }

            return await base.CreateAsync(element);
        }
    }
}
