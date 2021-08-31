using System;
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
