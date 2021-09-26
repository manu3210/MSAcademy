using CarRentals.Interfaces;
using CarRentals.Models;

namespace CarRentalsWebAPI.Interfaces
{
    public interface ICustomerRepository : IDataProcessing<Customer>
    {
    }
}
