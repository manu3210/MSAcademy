using CarRentals.Models;

namespace CarRentals.Controllers
{
    class RentalCRUD : JsonStorage<Rental>
    {
        public RentalCRUD(JsonFile configuration) : base(configuration.RentalsJsonFile)
        {

        }
        protected override void UpdateData(Rental element, Rental toUpdate)
        {
            toUpdate.Id = element.Id;
            toUpdate.Car = element.Car;
            toUpdate.Beginning = element.Beginning;
            toUpdate.Customer = element.Customer;
            toUpdate.End = element.End;
            toUpdate.price = toUpdate.price;
        }
    }
}
