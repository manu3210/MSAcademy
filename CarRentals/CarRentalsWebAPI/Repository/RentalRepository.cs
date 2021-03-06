using CarRentals.Models;
using CarRentalsWebAPI.Interfaces;
using CarRentalsWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public override async Task<Rental> GetAsync(int id)
        {
            return await _context.Rentals.Where(r => r.Id == id)
                .Include(v => v.Car)
                .ThenInclude(b => b.Brand)
                .Include(c => c.Customer)
                .FirstOrDefaultAsync();
        }

        public override List<Rental> GetAll()
        {
            return _context.Rentals
                .Include(v => v.Car)
                .ThenInclude(b => b.Brand)
                .Include(c => c.Customer)
                .ToList();
        }
    }
}
