using CarRentals.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalsWebAPI.Models
{
    public class BaseModel : IModelForCrud
    {
        public int Id { get; set; }
    }
}
