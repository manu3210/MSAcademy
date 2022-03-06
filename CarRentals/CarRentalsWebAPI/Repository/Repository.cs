using CarRentals.Interfaces;
using CarRentalsWebAPI.Interfaces;
using CarRentalsWebAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalsWebAPI.Repository
{
    public class Repository<T> : IDataProcessing<T> where T : BaseModel
    {
        protected readonly CarRentalsContext _context;

        public Repository(CarRentalsContext context)
        {
            _context = context;
        }

        public async Task<T> CreateAsync(T element)
        {
            _context.Set<T>().Add(element);
            await _context.SaveChangesAsync();

            return element;
        }

        public async Task DeleteAsync(int id)
        {
            var toDelete = await GetAsync(id);

            _context.Set<T>().Remove(toDelete);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<T> GetAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public virtual List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public async Task<T> UpdateAsync(int id, T element)
        {
            var toUpdate = await GetAsync(id);

            if (toUpdate == null)
            {
                return null;
            }

            UpdateData(element, toUpdate);

            await _context.SaveChangesAsync();

            return toUpdate;
        }

        protected virtual void UpdateData(T element, T toUpdate) { }

        public bool Exist(int id)
        {
            return _context.Set<T>().Any(e => e.Id == id);
        }
    }
}
