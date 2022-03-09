using CarRentalsWebAPI.Models;
using System;

namespace CarRentalsWebAPI.DTO
{
    public class RentalDto
    {
        public int Id { get; set; }
        public DateTime Beginning { get; set; }
        public DateTime End { get; set; }
        public CustomerDto Customer { get; set; }
        public CarDto Car { get; set; }
        public float Price { get; set; }

        public RentalDto() { }
        public RentalDto(Rental rental)
        {
            Id = rental.Id;
            Beginning = rental.Beginning;
            End = rental.End;
            Customer = new CustomerDto(rental.Customer);
            Car = new CarDto(rental.Car);
            Price = rental.Price;
        }

        public static Rental DtoToEntity(RentalDto dto)
        {
            Rental rental = new Rental();
            rental.Id = dto.Id;
            rental.Beginning = dto.Beginning;
            rental.End = dto.End;
            rental.Price = dto.Price;
            rental.Customer = CustomerDto.DtoToEntity(dto.Customer);
            rental.Car = CarDto.DtoToEntity(dto.Car);

            return rental;
        }
    }
}

