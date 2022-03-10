using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalsWebAPI.Interfaces
{
    public interface IService<T>
    {
        Task<T> CreateAsync(T element);
        Task<T> GetAsync(int id);
        Task<T> UpdateAsync(int id, T element);
        Task DeleteAsync(int id);
        Task<List<T>> GetAll();
    }
}
