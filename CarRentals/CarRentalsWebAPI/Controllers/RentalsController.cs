using CarRentals.Models;
using CarRentalsWebAPI.DTO;
using CarRentalsWebAPI.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        public IActionResult GetRental(int id)
        {
            var rental = _rentalService.Get(id);

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
        public IActionResult PutRental(int id, RentalDto rental)
        {
            var toUpdate = _rentalService.Update(id, RentalDto.DtoToEntity(rental));

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
        public IActionResult PostRental(RentalDto rentalDto)
        {
            var rental = RentalDto.DtoToEntity(rentalDto);
            var rentalAdded = _rentalService.Create(rental);

            if (rentalAdded == null)
            {
                return BadRequest();
            }

            return Ok(new RentalDto(rentalAdded));
        }

        // DELETE: api/Customer/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult DeleteRental(int id)
        {
            _rentalService.Delete(id);

            return NoContent();
        }
    }
}
