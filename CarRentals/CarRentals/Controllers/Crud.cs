using CarRentals.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CarRentals.Controllers
{
    public abstract class Crud<T> : IDataProcessing<T> where T : IModelForCrud
    {
        protected List<T> List { get; set; }
        public ManageJson<T> Json { get; set; }

        public Crud(ProgramOptions configuration)
        {
            Json = new ManageJson<T>(configuration.JsonFile);
            List = Json.ReadJson();
        }

        public void Create(T element)
        {
            if (element != null)
                List.Add(element);
            Json.SaveChanges(List);
        }

        public T Get(int id)
        {
            T Result = List.Where(element => element.Id == id).FirstOrDefault();
            return Result;
        }

        public void Delete(int id)
        {
            T ToDelete = Get(id);

            if (List.Contains(ToDelete))
            {
                List.Remove(ToDelete);
            }

            Json.SaveChanges(List);
        }

        public List<T> GetAll()
        {
            return List;
        }

        public abstract T Update(T element); // To override in child classes
    }
}
