using CarRentalsWebAPI.Models;

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
