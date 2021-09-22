using CarRentals.Interfaces;

namespace CarRentalsWebAPI.Models
{
    public class Brand : IModelForCrud
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
    }
}
