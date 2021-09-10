using System;

namespace CarRentals.Models
{
    class Customer
    {
        string Dni { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Phone { get; set; }
        string Adress { get; set; }
        string City { get; set; }
        string Province { get; set; }
        int ZipCode { get; set; }
        DateTime LastModification { get; set; }
    }
}
