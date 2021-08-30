using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentals.Exceptions
{
    class CarNotFoundException : Exception
    {
        public CarNotFoundException(string msj) : base(msj)
        {

        }
    }
}
