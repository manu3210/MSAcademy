using AutoMapper;
using CarRentalsWebAPI.DTO;
using CarRentalsWebAPI.Models;

namespace CarRentalsWebAPI.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
        }
    }
}
