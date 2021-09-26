using CarRentals.Interfaces;
using CarRentals.Models;

namespace CarRentalsWebAPI.Interfaces
{
    public interface ICustomerService : IDataProcessing<Customer>
    {
    }
}
