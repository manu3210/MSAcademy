﻿using CarRentalsWebAPI.DTO;
using CarRentalsWebAPI.Interfaces;
using CarRentalsWebAPI.Mediator.Querys;
using CarRentalsWebAPI.Models;
using MediatR;
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
        private readonly IMediator _mediator;

        public RentalsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Rentals
        /// <summary>
        /// Gets the complete list of rental objects
        /// </summary>
        /// <response code="200">Returns a rental list</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<RentalDto>))]
        public async Task<IActionResult> GetRentals()
        {
            return Ok(await _mediator.Send(new GetAllRentals()));
        }

        // GET: api/Rentals/5
        /// <summary>
        /// Get a specific rental.
        /// </summary>
        /// <param name="id">rental id which we want to get</param>
        /// <response code="200">Returns a specific rental</response>
        /// <response code="404">the rental id specified was not found</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RentalDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetRental(int id)
        {
            var rental = await _mediator.Send(new GetRentalById(id));

            if (rental == null)
            {
                return NotFound();
            }

            return Ok(rental);
        }

        // PUT: api/Rentals/5
        /// <summary>
        /// Updates a rental specified by the id parameter
        /// </summary>
        /// <param name="id">Id of the customer to update</param>
        /// <param name="rental">rental object with updated fields</param>
        /// <response code="200">rental was succesfully updated. It returns the updated rental</response>
        /// <response code="404">rental to update was not found</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RentalDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutRental(int id, RentalDto rental)
        {
            if (rental == null)
                return BadRequest();

            var toUpdate = await _mediator.Send(new UpdateRental(id, rental));

            if (toUpdate == null)
            {
                return NotFound();
            }

            return Ok(toUpdate);
        }

        // POST: api/Rentals
        /// <summary>
        /// Add a new rental to the storage
        /// </summary>
        /// <param name="rentalDto">rental that will be added</param>
        /// <response code="200">rental was succesfully added. It returns the added rental</response>
        /// <response code="400">rental to add was null</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RentalDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PostRental(RentalDto rentalDto)
        {
            if (rentalDto == null)
                return BadRequest();

            var rentalAdded = await _mediator.Send(new CreateRental(rentalDto));

            if (rentalAdded == null)
            {
                return BadRequest();
            }

            return Ok(rentalAdded);
        }

        // DELETE: api/Rentals/5
        /// <summary>
        /// Delete a rental from the storage
        /// </summary>
        /// <param name="id">Id of the rental we want to delete</param>
        /// <response code="204">rental was succesfully deleted</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteRental(int id)
        {
            await _mediator.Send(DeleteRental(id));
            return NoContent();
        }
    }
}
