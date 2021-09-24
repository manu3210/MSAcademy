using CarRentalsWebAPI.DTO;
using CarRentalsWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalsWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly CarRentalsContext _context;

        public BrandsController(CarRentalsContext context)
        {
            _context = context;
        }

        // GET: api/Brands
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BrandDto>>> GetBrands()
        {
            return await _context.Brands.Select(x => new BrandDto(x)).ToListAsync();
        }

        // GET: api/Brands/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BrandDto>> GetBrand(int id)
        {
            var brand = await _context.Brands.FindAsync(id);

            if (brand == null)
            {
                return NotFound();
            }

            return new BrandDto(brand);
        }

        // PUT: api/Brands/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBrand(int id, BrandDto brand)
        {
            if (id != brand.Id)
            {
                return BadRequest();
            }

            var brandModel = await _context.Brands.FindAsync(id);

            if (brandModel == null)
            {
                return NotFound();
            }

            brandModel.Id = brand.Id;
            brandModel.BrandName = brand.BrandName;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BrandExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Brands
        [HttpPost]
        public async Task<ActionResult<BrandDto>> PostBrand(BrandDto brandDto)
        {
            _context.Brands.Add(BrandDto.DtoToEntity(brandDto));
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBrand", new { id = brandDto.Id }, brandDto);
        }

        // DELETE: api/Brands/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            var brand = await _context.Brands.FindAsync(id);
            if (brand == null)
            {
                return NotFound();
            }

            _context.Brands.Remove(brand);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BrandExists(int id)
        {
            return _context.Brands.Any(e => e.Id == id);
        }
    }
}
