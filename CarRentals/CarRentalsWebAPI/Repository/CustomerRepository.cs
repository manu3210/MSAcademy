using CarRentalsWebAPI.Interfaces;
using CarRentalsWebAPI.Models;

namespace CarRentalsWebAPI.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(CarRentalsContext context) : base(context) { }
        protected override void UpdateData(Customer element, Customer toUpdate)
        {
            toUpdate.Dni = element.Dni;
            toUpdate.FirstName = element.FirstName;
            toUpdate.LastName = element.LastName;
            toUpdate.Phone = element.Phone;
            toUpdate.Adress = element.Adress;
            toUpdate.City = element.City;
            toUpdate.Province = element.Province;
            toUpdate.LastModification = element.LastModification;
            toUpdate.ZipCode = element.ZipCode;
        }
    }
}
