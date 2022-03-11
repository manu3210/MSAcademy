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
    }
}
