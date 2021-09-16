using CarRentals.Interfaces;
using Models;
using System;

namespace CarRentals.Models
{
    public class Rental : IModelForCrud
    {
        public int Id { get; set; }
        public DateTime Beginning { get; set; }
        public DateTime End { get; set; }
        public Customer Customer { get; set; }
        public Car Car { get; set; }
        public float price { get; set; }
    }
}
