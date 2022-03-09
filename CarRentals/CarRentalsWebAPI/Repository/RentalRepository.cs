using CarRentalsWebAPI.Interfaces;
using CarRentalsWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

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

        public override Rental Get(int id)
        {
            return _context.Rentals.Where(r => r.Id == id)
                .Include(v => v.Car)
                .ThenInclude(b => b.Brand)
                .Include(c => c.Customer)
                .FirstOrDefault();
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
