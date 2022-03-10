using CarRentalsWebAPI.DTO;
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
    public class CarsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Cars
        /// <summary>
        /// Gets the complete list of car objects
        /// </summary>
        /// <response code="200">Returns a car list</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CarDto>))]
        public async Task<IActionResult> GetCars()
        {
            return Ok(await _mediator.Send(new GetAllCars()));
        }

        // GET: api/Cars/5
        /// <summary>
        /// Get a specific car.
        /// </summary>
        /// <param name="id">car id which we want to get</param>
        /// <response code="200">Returns a specific car</response>
        /// <response code="404">the car id specified was not found</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CarDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCar(int id)
        {
            var car = await _mediator.Send(new GetCarById(id));

            if (car == null)
            {
                return NotFound();
            }

            return Ok(car);
        }

        // PUT: api/Cars/5
        /// <summary>
        /// Updates a car specified by the id parameter
        /// </summary>
        /// <param name="id">Id of the car to update</param>
        /// <param name="car">car object with updated fields</param>
        /// <response code="200">car was succesfully updated. It returns the updated car</response>
        /// <response code="404">car to update was not found</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CarDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutCar(int id, CarDto car)
        {
            if(car == null)
                return BadRequest();

            var toUpdate = await _mediator.Send(new UpdateCar(id, car));

            if (toUpdate == null)
            {
                return NotFound();
            }

            return Ok(toUpdate);
        }

        // POST: api/Cars
        /// <summary>
        /// Add a new car to the storage
        /// </summary>
        /// <param name="carDto">car that will be added</param>
        /// <response code="200">car was succesfully added. It returns the added car</response>
        /// <response code="400">car to add was null</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CarDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostCar(CarDto carDto)
        {
            if (carDto == null)
                return BadRequest();

            var carAdded = await _mediator.Send(new CreateCar(carDto));

            if (carAdded == null)
            {
                return BadRequest();
            }

            return Ok(carAdded);
        }

        // DELETE: api/Cars/5
        /// <summary>
        /// Delete a car from the storage
        /// </summary>
        /// <param name="id">Id of the car we want to delete</param>
        /// <response code="204">car was succesfully deleted</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteCar(int id)
        {
            await _mediator.Send(new DeleteCar(id));

            return NoContent();
        }
    }
}
