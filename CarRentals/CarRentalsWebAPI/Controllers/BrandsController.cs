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
        /// <summary>
        /// Gets the complete list of brand objects
        /// </summary>
        /// <response code="200">Returns a brand list</response>
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
        /// <summary>
        /// Get a specific brand.
        /// </summary>
        /// <param name="id">brand id which we want to get</param>
        /// <response code="200">Returns a specific brand</response>
        /// <response code="404">the brand id specified was not found</response>
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
        /// <summary>
        /// Updates a brand specified by the id parameter
        /// </summary>
        /// <param name="id">Id of the brand to update</param>
        /// <param name="brand">brand object with updated fields</param>
        /// <response code="200">Brand was succesfully updated. It returns the updated Brand</response>
        /// <response code="404">Brand to update was not found</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BrandDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutBrand(int id, BrandDto brand)
        {
            if (brand == null)
            {
                return BadRequest();
            }
            if(await _brandService.GetAsync(id) == null)
            {
                return NotFound();
            }

            var toUpdate = await _brandService.UpdateAsync(id, BrandDto.DtoToEntity(brand));

            if (toUpdate == null)
            {
                return NotFound();
            }

            

            return Ok(brand);
        }

        // POST: api/Brands
        /// <summary>
        /// Add a new brand to the storage
        /// </summary>
        /// <param name="brandDto">Brand that will be added</param>
        /// <response code="200">Brand was succesfully added. It returns the added Brand</response>
        /// <response code="400">Brand to add was null</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BrandDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostBrand(BrandDto brandDto)
        {
            if (brandDto == null)
            {
                return BadRequest();
            }

            var brand = BrandDto.DtoToEntity(brandDto);
            var brandAdded = await _brandService.CreateAsync(brand);

            if(brandAdded == null)
                return BadRequest();

            return Ok(new BrandDto(brandAdded));
        }

        // DELETE: api/Brands/5
        /// <summary>
        /// Delete a brand from the storage
        /// </summary>
        /// <param name="id">Id of the brand we want to delete</param>
        /// <response code="204">brand was succesfully deleted</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            await _brandService.DeleteAsync(id);

            return NoContent();
        }
    }
}
