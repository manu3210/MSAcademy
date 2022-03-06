using CarRentalsWebAPI.Interfaces;
using CarRentalsWebAPI.Models;
using System.Threading.Tasks;

namespace CarRentalsWebAPI.Services
{
    public class BrandService : Service<Brand>, IBrandService
    {
        public BrandService(IDataProcessing<Brand> Repository) : base(Repository) { }

        public override async Task<Brand> CreateAsync(Brand element)
        {
            var list = GetAll();

            foreach (Brand item in list)
            {
                if (item.BrandName.Equals(element.BrandName))
                {
                    return null;
                }
            }

            return await base.CreateAsync(element);
        }
    }
}
