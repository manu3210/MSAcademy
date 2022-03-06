using CarRentalsWebAPI.Interfaces;
using CarRentalsWebAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRentalsWebAPI.Services
{

    public abstract class Service<T> : IService<T> where T : BaseModel
    {
        protected readonly IDataProcessing<T> _repository;

        public Service(IDataProcessing<T> repository)
        {
            _repository = repository;
        }

        public virtual async Task<T> CreateAsync(T element)
        {
            return await _repository.CreateAsync(element);
        }

        public virtual async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public virtual List<T> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual Task<T> GetAsync(int id)
        {
            return _repository.GetAsync(id);
        }

        public virtual async Task<T> UpdateAsync(int id, T element)
        {
            return await _repository.UpdateAsync(id, element);
        }
    }
}
