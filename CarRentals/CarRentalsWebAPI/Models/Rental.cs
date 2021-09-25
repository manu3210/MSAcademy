using CarRentals.Interfaces;
using CarRentalsWebAPI.Models;
using Models;
using System;

namespace CarRentals.Models
{
    public class Rental : BaseModel
    {
        public DateTime Beginning { get; set; }
        public DateTime End { get; set; }
        public Customer Customer { get; set; }
        public Car Car { get; set; }
        public float Price { get; set; }
    }
}
