using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalsWebAPI.Interfaces
{
    public interface IService<T>
    {
        public T Create(T element);
        public T Get(int id);
        public T Update(int id, T element);
        public void Delete(int id);
        public List<T> GetAll();
    }
}
