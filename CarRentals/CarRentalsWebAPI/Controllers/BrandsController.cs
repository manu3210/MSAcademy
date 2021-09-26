using CarRentalsWebAPI.DTO;
using CarRentalsWebAPI.Models;
using CarRentalsWebAPI.Services;
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
        public ActionResult<List<BrandDto>> GetBrands()
        {
            List<BrandDto> list = new List<BrandDto>();

            foreach (Brand item in _brandService.GetAll())
            {
                list.Add(new BrandDto(item));
            }

            return list;
        }

        // GET: api/Brands/5
        [HttpGet("{id}")]
        public ActionResult<BrandDto> GetBrand(int id)
        {
            var brand = _brandService.Get(id);

            if (brand == null)
            {
                return NotFound();
            }

            return new BrandDto(brand);
        }

        // PUT: api/Brands/5
        [HttpPut("{id}")]
        public IActionResult PutBrand(int id, BrandDto brand)
        {
            var toUpdate = _brandService.Update(id, BrandDto.DtoToEntity(brand));

            if (toUpdate == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Brands
        [HttpPost]
        public ActionResult<BrandDto> PostBrand(BrandDto brandDto)
        {
            var brand = BrandDto.DtoToEntity(brandDto);
            var brandAdded = _brandService.Create(brand);

            return new BrandDto(brandAdded);
        }

        // DELETE: api/Brands/5
        [HttpDelete("{id}")]
        public IActionResult DeleteBrand(int id)
        {
            _brandService.Delete(id);

            return NoContent();
        }
    }
}
