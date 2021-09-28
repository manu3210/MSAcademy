using CarRentals.Interfaces;
using CarRentalsWebAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace CarRentalsWebAPI.Repository
{
    public abstract class Repository<T> : IDataProcessing<T> where T : BaseModel
    {
        protected readonly CarRentalsContext _context;

        public Repository(CarRentalsContext context)
        {
            _context = context;
        }

        public T Create(T element)
        {
            _context.Set<T>().Add(element);
            _context.SaveChanges();

            return element;
        }

        public void Delete(int id)
        {
            var toDelete = Get(id);

            _context.Set<T>().Remove(toDelete);
            _context.SaveChanges();
        }

        public virtual T Get(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public virtual List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T Update(int id, T element)
        {
            var toUpdate = Get(id);

            if (toUpdate == null)
            {
                return null;
            }

            UpdateData(element, toUpdate);

            _context.SaveChanges();

            return toUpdate;
        }

        protected abstract void UpdateData(T element, T toUpdate);

        public bool Exist(int id)
        {
            return _context.Set<T>().Any(e => e.Id == id);
        }
    }
}
