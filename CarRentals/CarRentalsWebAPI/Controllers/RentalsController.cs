using CarRentals.Models;
using CarRentalsWebAPI.DTO;
using CarRentalsWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalsWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        private readonly CarRentalsContext _context;

        public RentalsController(CarRentalsContext context)
        {
            _context = context;
        }

        // GET: api/Rentals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RentalDto>>> GetRentals()
        {
            return await _context.Rentals.Select(x => new RentalDto(x)).ToListAsync();
        }

        // GET: api/Rentals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RentalDto>> GetRental(int id)
        {
            var rental = await _context.Rentals.FindAsync(id);

            if (rental == null)
            {
                return NotFound();
            }

            return new RentalDto(rental);
        }

        // PUT: api/Rentals/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRental(int id, RentalDto rental)
        {
            var rentalModel = await _context.Rentals.FindAsync(id);

            if (rentalModel == null)
            {
                return null;
            }

            rentalModel.Id = rental.Id;
            rentalModel.Beginning = rental.Beginning;
            rentalModel.End = rental.End;
            rentalModel.Price = rental.Price;
            rentalModel.Customer = CustomerDto.DtoToEntity(rental.Customer);
            rentalModel.Car = CarDto.DtoToEntity(rental.Car);

            await _context.SaveChangesAsync();
            
            return NoContent();
        }

        // POST: api/Rentals
        [HttpPost]
        public async Task<ActionResult<Rental>> PostRental(RentalDto rental)
        {
            _context.Rentals.Add(RentalDto.DtoToEntity(rental));
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRental", new { id = rental.Id }, rental);
        }

        // DELETE: api/Rentals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRental(int id)
        {
            var rental = await _context.Rentals.FindAsync(id);
            if (rental == null)
            {
                return NotFound();
            }

            _context.Rentals.Remove(rental);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RentalExists(int id)
        {
            return _context.Rentals.Any(e => e.Id == id);
        }
    }
}
