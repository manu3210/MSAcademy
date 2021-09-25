using System.Collections.Generic;

namespace CarRentals.Interfaces
{
    public interface IDataProcessing<T>
    {
        public T Create(T element);
        public T Get(int id);
        public T Update(int id, T element);
        public void Delete(int id);
        public List<T> GetAll();
    }
}
