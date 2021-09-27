using CarRentalsWebAPI.DTO;
using CarRentalsWebAPI.Interfaces;
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
        public ActionResult<List<CarDto>> GetCars()
        {
            List<CarDto> list = new List<CarDto>();

            foreach (Car item in _carService.GetAll())
            {
                list.Add(new CarDto(item));
            }

            return Ok(list);
        }

        // GET: api/Cars/5
        [HttpGet("{id}")]
        public ActionResult<CarDto> GetCar(int id)
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
        public IActionResult PutCar(int id, CarDto car)
        {
            var toUpdate = _carService.Update(id, CarDto.DtoToEntity(car));

            if (toUpdate == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Cars
        [HttpPost]
        public ActionResult<CarDto> PostCar(CarDto carDto)
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
        public IActionResult DeleteCar(int id)
        {
            _carService.Delete(id);

            return NoContent();
        }
    }
}
