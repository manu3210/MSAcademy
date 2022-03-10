using System;

namespace CarRentalsWebAPI.Models
{
    public class Customer : BaseModel
    {
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
