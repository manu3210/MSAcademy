using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRentalsWebAPI.Interfaces
{
    public interface IService<T> : IDataProcessing<T>
    {
    }
}
