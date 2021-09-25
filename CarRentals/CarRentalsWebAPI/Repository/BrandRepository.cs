using CarRentalsWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalsWebAPI.Repository
{
    public class BrandRepository : Repository<Brand>, IBrandRepository
    {
        public BrandRepository(CarRentalsContext context) : base(context) { }

        protected override void UpdateData(Brand element, Brand toUpdate)
        {
            toUpdate.BrandName = element.BrandName;
        }
    }
}
