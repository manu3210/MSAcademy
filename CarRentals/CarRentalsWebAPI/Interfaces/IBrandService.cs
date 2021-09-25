using CarRentals.Interfaces;
using CarRentalsWebAPI.DTO;
using CarRentalsWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalsWebAPI.Services
{
    public interface IBrandService : IDataProcessing<Brand>
    {
    }
}
