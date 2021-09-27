using CarRentals.Models;
using CarRentalsWebAPI.DTO;
using CarRentalsWebAPI.Interfaces;
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
        public ActionResult<List<RentalDto>> GetRentals()
        {
            List<RentalDto> list = new List<RentalDto>();

            foreach (Rental item in _rentalService.GetAll())
            {
                list.Add(new RentalDto(item));
            }

            return Ok(list);
        }

        // GET: api/Customer/5
        [HttpGet("{id}")]
        public ActionResult<RentalDto> GetRental(int id)
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
        public IActionResult PutRental(int id, RentalDto rental)
        {
            var toUpdate = _rentalService.Update(id, RentalDto.DtoToEntity(rental));

            if (toUpdate == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Customer
        [HttpPost]
        public ActionResult<RentalDto> PostRental(RentalDto rentalDto)
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
        public IActionResult DeleteRental(int id)
        {
            _rentalService.Delete(id);

            return NoContent();
        }
    }
}
