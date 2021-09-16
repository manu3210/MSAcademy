using CarRentals.Models;
using System;

namespace CarRentals.Controllers
{
    public class CustomerCRUD : JsonStorage<Customer>
    {
        public CustomerCRUD(JsonFile configuration) : base(configuration.CustomersJsonFile)
        {

        }
        protected override void UpdateData(Customer element, Customer toUpdate)
        {
            toUpdate.FirstName = element.FirstName;
            toUpdate.LastName = element.LastName;
            toUpdate.Adress = element.Adress;
            toUpdate.City = element.City;
            toUpdate.Dni = element.Dni;
            toUpdate.Phone = element.Phone;
            toUpdate.Province = element.Province;
            toUpdate.ZipCode = element.ZipCode;
            toUpdate.LastModification = DateTime.UtcNow;
        }
    }
}
