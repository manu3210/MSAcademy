using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentals.Interfaces
{
    interface IDataProcessing
    {
        public void Create(Car car);
        public Car Get(int id);
        public Car Update(Car car);
        public void Delete(int id);
    }
}
