using CarRentals.Models;
using System;

namespace CarRentalsWebAPI.DTO
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Dni { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public int ZipCode { get; set; }
        public DateTime LastModification { get; set; }

        public CustomerDto() { }
        public CustomerDto(Customer customer)
        {
            Id = customer.Id;
            Dni = customer.Dni;
            FirstName = customer.FirstName;
            LastName = customer.LastName;
            Phone = customer.Phone;
            Adress = customer.Adress;
            City = customer.City;
            Province = customer.Province;
            ZipCode = customer.ZipCode;
            LastModification = customer.LastModification;
        }

        public static Customer DtoToEntity(CustomerDto dto)
        {
            Customer customer = new Customer();

            customer.Id = dto.Id;
            customer.Dni = dto.Dni;
            customer.FirstName = dto.FirstName;
            customer.LastName = dto.LastName;
            customer.Phone = dto.Phone;
            customer.Adress = dto.Adress;
            customer.City = dto.City;
            customer.Province = dto.Province;
            customer.ZipCode = dto.ZipCode;
            customer.LastModification = dto.LastModification;

            return customer;
        }
    }
}
