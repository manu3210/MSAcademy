using CarRentalsWebAPI.DTO;
using CarRentalsWebAPI.Interfaces;
using CarRentalsWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRentalsWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        // GET: api/Brands
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<BrandDto>))]
        public IActionResult GetBrands()
        {
            var list = new List<BrandDto>();

            foreach (Brand item in _brandService.GetAll())
            {
                list.Add(new BrandDto(item));
            }

            return Ok(list);
        }

        // GET: api/Brands/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BrandDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBrand(int id)
        {
            var brand = await _brandService.GetAsync(id);

            if (brand == null)
            {
                return NotFound();
            }

            return Ok(new BrandDto(brand));
        }

        // PUT: api/Brands/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BrandDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutBrand(int id, BrandDto brand)
        {
            var toUpdate = await _brandService.UpdateAsync(id, BrandDto.DtoToEntity(brand));

            if (toUpdate == null)
            {
                return NotFound();
            }

            return Ok(brand);
        }

        // POST: api/Brands
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BrandDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostBrand(BrandDto brandDto)
        {
            var brand = BrandDto.DtoToEntity(brandDto);
            var brandAdded = await _brandService.CreateAsync(brand);

            if (brandAdded == null)
            {
                return BadRequest();
            }

            return Ok(new BrandDto(brandAdded));
        }

        // DELETE: api/Brands/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            await _brandService.DeleteAsync(id);

            return NoContent();
        }
    }
}
