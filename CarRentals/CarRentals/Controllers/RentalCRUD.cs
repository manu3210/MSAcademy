using CarRentals.Models;

namespace CarRentals.Controllers
{
    class RentalCRUD : JsonStorage<Rental>
    {
        public RentalCRUD(JsonFile configuration) : base(configuration.RentalsJsonFile)
        {

        }
        public override Rental Update(Rental element)
        {
            var toUpdate = Get(element.Id);

            toUpdate.Id = element.Id;
            toUpdate.Car = element.Car;
            toUpdate.Beginning = element.Beginning;
            toUpdate.Customer = element.Customer;
            toUpdate.End = element.End;
            toUpdate.price = toUpdate.price;

            SaveChanges(List);
            return element;
        }
    }
}
