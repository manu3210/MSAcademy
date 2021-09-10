using Models;
using System;

namespace CarRentals.Models
{
    class Rental
    {
        DateTime Beginning { get; set; }
        DateTime End { get; set; }
        Customer Customer { get; set; }
        Car Car { get; set; }
    }
}
