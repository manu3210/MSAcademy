using CarRentals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentals.Controllers
{
    class RentalCRUD : Crud<Rental>
    {
        public RentalCRUD(ProgramOptions configuration) : base(configuration)
        {

        }
        public override Rental Update(Rental element)
        {
            Rental toUpdate = Get(element.Id);

            toUpdate.Id = element.Id;
            toUpdate.Car = element.Car;
            toUpdate.Beginning = element.Beginning;
            toUpdate.Customer = element.Customer;
            toUpdate.End = element.End;
            toUpdate.price = toUpdate.price;

            Json.SaveChanges(List);
            return element;
        }
    }
}
