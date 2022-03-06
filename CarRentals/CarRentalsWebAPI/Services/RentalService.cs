using CarRentals.Models;
using CarRentalsWebAPI.Interfaces;
using System.Threading.Tasks;

namespace CarRentalsWebAPI.Services
{
    public class RentalService : Service<Rental>, IRentalService
    {
        public RentalService(IDataProcessing<Rental> repository) : base(repository) { }

        public async override Task<Rental> CreateAsync(Rental element)
        {
            if (validateRental(element))
                return await base.CreateAsync(element);
            else
                return null;
        }

        public override Task<Rental> UpdateAsync(int id, Rental element)
        {
            if (validateRental(element))
                return base.UpdateAsync(id, element);
            else
                return null;
        }

        private bool validateRental(Rental rental)
        {

            if (rental.Car != null && rental.Customer != null && rental.End.Subtract(rental.Beginning).Days > 0)
            {
                if (rental.Car.IsRented == false)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
