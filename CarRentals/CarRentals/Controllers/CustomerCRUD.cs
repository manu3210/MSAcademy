using CarRentals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentals.Controllers
{
    public class CustomerCRUD : Crud<Customer>
    {
        public CustomerCRUD(ProgramOptions configuration) : base(configuration)
        {

        }
        public override Customer Update(Customer element)
        {
            Customer toUpdate = Get(element.Id);

            toUpdate.FirstName = element.FirstName;
            toUpdate.LastName = element.LastName;
            toUpdate.Adress = element.Adress;
            toUpdate.City = element.City;
            toUpdate.Dni = element.Dni;
            toUpdate.Phone = element.Phone;
            toUpdate.Province = element.Province;
            toUpdate.Id = element.Id;
            toUpdate.ZipCode = element.ZipCode;
            toUpdate.LastModification = DateTime.UtcNow;

            Json.SaveChanges(List);
            return element;
        }
    }
}
