using CarRentals.Models;
using CarRentalsWebAPI.Interfaces;
using CarRentalsWebAPI.Models;

namespace CarRentalsWebAPI.Repository
{
    public class RentalRepository : Repository<Rental>, IRentalRepository
    {
        public RentalRepository(CarRentalsContext context) : base(context) { }

        protected override void UpdateData(Rental element, Rental toUpdate)
        {
            toUpdate.Beginning = element.Beginning;
            toUpdate.End = element.End;
            toUpdate.Price = element.Price;
            toUpdate.Customer = element.Customer;
            toUpdate.Car = element.Car;
        }
    }
}
