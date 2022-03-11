using AutoMapper;
using CarRentalsWebAPI.DTO;
using CarRentalsWebAPI.Models;

namespace CarRentalsWebAPI.Profiles
{
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            CreateMap<Car, CarDto>().ReverseMap();
        }
    }
}
