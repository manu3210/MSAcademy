using CarRentalsWebAPI.DTO;
using CarRentalsWebAPI.Interfaces;
using CarRentalsWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CarRentalsWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        // GET: api/Cars
        /// <summary>
        /// Gets the complete list of car objects
        /// </summary>
        /// <response code="200">Returns a car list</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CarDto>))]
        public IActionResult GetCars()
        {
            var list = new List<CarDto>();

            foreach (Car item in _carService.GetAll())
            {
                list.Add(new CarDto(item));
            }

            return Ok(list);
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
        public IActionResult GetCar(int id)
        {
            var car = _carService.Get(id);

            if (car == null)
            {
                return NotFound();
            }

            return Ok(new CarDto(car));
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
        public IActionResult PutCar(int id, CarDto car)
        {
            var toUpdate = _carService.Update(id, CarDto.DtoToEntity(car));

            if (toUpdate == null)
            {
                return NotFound();
            }

            return Ok(car);
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
        public IActionResult PostCar(CarDto carDto)
        {
            var car = CarDto.DtoToEntity(carDto);
            var carAdded = _carService.Create(car);

            if (carAdded == null)
            {
                return BadRequest();
            }

            return Ok(new CarDto(carAdded));
        }

        // DELETE: api/Cars/5
        /// <summary>
        /// Delete a car from the storage
        /// </summary>
        /// <param name="id">Id of the car we want to delete</param>
        /// <response code="204">car was succesfully deleted</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult DeleteCar(int id)
        {
            _carService.Delete(id);

            return NoContent();
        }
    }
}
