using CarRentals.Interfaces;
using CarRentalsWebAPI.Models;
using CarRentalsWebAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public Brand Create(Brand brand)
        {
            var newBrand = _repository.Create(brand);

            return newBrand;
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public Brand Get(int id)
        {
            return _repository.Get(id);
        }

        public List<Brand> GetAll()
        {
            return _repository.GetAll();
        }

        public Brand Update(int id, Brand element)
        {
            return _repository.Update(id, element);
        }

        
    }
}
