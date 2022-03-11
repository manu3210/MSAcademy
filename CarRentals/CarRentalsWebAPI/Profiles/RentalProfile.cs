using AutoMapper;
using CarRentalsWebAPI.DTO;
using CarRentalsWebAPI.Models;

namespace CarRentalsWebAPI.Profiles
{
    public class RentalProfile : Profile
    {
        public RentalProfile()
        {
            CreateMap<Rental, RentalDto>().ReverseMap();
        }
    }
}
