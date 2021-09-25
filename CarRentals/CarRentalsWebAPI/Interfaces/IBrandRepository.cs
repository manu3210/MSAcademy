using CarRentals.Interfaces;
using CarRentalsWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalsWebAPI.Repository
{
    public interface IBrandRepository : IDataProcessing<Brand>
    {
    }
}
