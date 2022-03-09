using CarRentalsWebAPI.Interfaces;
using CarRentalsWebAPI.Models;
using CarRentalsWebAPI.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRentalsWebAPI.Services
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _repository;

        public BrandService(IBrandRepository repository)
        {
            _repository = repository;
        }

        public async Task<Brand> CreateAsync(Brand brand)
        {
            var list = _repository.GetAll();

            foreach(Brand item in list)
            {
                if(item.BrandName.Equals(brand.BrandName))
                {
                    return null;
                }
            }

            var newBrand = await _repository.CreateAsync(brand);

            return newBrand;
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<Brand> GetAsync(int id)
        {
            return await _repository.GetAsync(id);
        }

        public List<Brand> GetAll()
        {
            return _repository.GetAll();
        }

        public async Task<Brand> UpdateAsync(int id, Brand element)
        {
            return await _repository.UpdateAsync(id, element);
        }
    }
}
