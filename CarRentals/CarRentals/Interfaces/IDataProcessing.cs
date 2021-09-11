namespace CarRentals.Interfaces
{
    public interface IDataProcessing<T>
    {
        public void Create(T element);
        public T Get(int id);
        public T Update(T element);
        public void Delete(int id);
    }
}
