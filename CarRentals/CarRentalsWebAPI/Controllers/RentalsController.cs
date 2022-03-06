using CarRentals.Models;
using CarRentalsWebAPI.DTO;
using CarRentalsWebAPI.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRentalsWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        private readonly IRentalService _rentalService;

        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        // GET: api/Customer
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<RentalDto>))]
        public IActionResult GetRentals()
        {
            var list = new List<RentalDto>();

            foreach (Rental item in _rentalService.GetAll())
            {
                list.Add(new RentalDto(item));
            }

            return Ok(list);
        }

        // GET: api/Customer/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RentalDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetRental(int id)
        {
            var rental = await _rentalService.GetAsync(id);

            if (rental == null)
            {
                return NotFound();
            }

            return Ok(new RentalDto(rental));
        }

        // PUT: api/Customer/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RentalDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutRental(int id, RentalDto rental)
        {
            var toUpdate = await _rentalService.UpdateAsync(id, RentalDto.DtoToEntity(rental));

            if (toUpdate == null)
            {
                return NotFound();
            }

            return Ok(rental);
        }

        // POST: api/Customer
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RentalDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PostRental(RentalDto rentalDto)
        {
            var rental = RentalDto.DtoToEntity(rentalDto);
            var rentalAdded = await _rentalService.CreateAsync(rental);

            if (rentalAdded == null)
            {
                return BadRequest();
            }

            return Ok(new RentalDto(rentalAdded));
        }

        // DELETE: api/Customer/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteRental(int id)
        {
            await _rentalService.DeleteAsync(id);

            return NoContent();
        }
    }
}
