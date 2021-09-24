using CarRentalsWebAPI.Models;

namespace CarRentalsWebAPI.DTO
{
    public class BrandDto
    {
        public int Id { get; set; }
        public string BrandName { get; set; }

        public BrandDto() { }

        public BrandDto(Brand brand)
        {
            Id = brand.Id;
            BrandName = brand.BrandName;
        }

        public static Brand DtoToEntity(BrandDto dto)
        {
            var brand = new Brand();
            brand.Id = dto.Id;
            brand.BrandName = dto.BrandName;

            return brand;
        }
    }
}
