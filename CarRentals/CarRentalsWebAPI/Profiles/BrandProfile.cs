using AutoMapper;
using CarRentalsWebAPI.DTO;
using CarRentalsWebAPI.Models;

namespace CarRentalsWebAPI.Profiles
{
    public class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<Brand, BrandDto>().ReverseMap();
        }
    }
}
