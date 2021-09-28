using CarRentalsWebAPI.DTO;
using CarRentalsWebAPI.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
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
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult DeleteCar(int id)
        {
            _carService.Delete(id);

            return NoContent();
        }
    }
}
