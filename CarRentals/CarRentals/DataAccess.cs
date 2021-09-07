using CarRentals.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentals
{
    public class DataAccess : IDataAccess
    {
        public string JsonFilePath()
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            var configuration = builder.Build();
            string path = configuration["JsonFile"];
            return path;
        }
    }
}
