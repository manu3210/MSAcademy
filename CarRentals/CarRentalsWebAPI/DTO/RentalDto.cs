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
    }
}

