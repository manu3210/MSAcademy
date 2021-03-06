using CarRentalsWebAPI.Interfaces;
using CarRentalsWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalsWebAPI.Repository
{
    public class CarRepository : Repository<Car>, ICarRepository
    {
        public CarRepository(CarRentalsContext context) : base(context) { }

        protected override void UpdateData(Car element, Car toUpdate)
        {
            toUpdate.Doors = element.Doors;
            toUpdate.Brand = element.Brand;
            toUpdate.Color = element.Color;
            toUpdate.IsRented = element.IsRented;
            toUpdate.Transmition = element.Transmition;
            toUpdate.Model = element.Model;
        }

        public override async Task<Car> GetAsync(int id)
        {
            return await _context.Cars.Where(c => c.Id == id).Include(b => b.Brand).FirstOrDefaultAsync();
        }

        public override List<Car> GetAll()
        {
            return _context.Cars.Include(b => b.Brand).ToList();
        }
    }
}
