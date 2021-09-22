using CarRentals.Models;
using Microsoft.EntityFrameworkCore;
using Models;

namespace CarRentalsWebAPI.Models
{
    public class CarRentalsContext : DbContext
    {
        public CarRentalsContext(DbContextOptions<CarRentalsContext> options) : base(options)
        {

        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rental> Rentals { get; set; }

    }
}
