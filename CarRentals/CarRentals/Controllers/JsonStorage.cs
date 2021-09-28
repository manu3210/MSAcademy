using CarRentals.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CarRentals.Controllers
{
    public abstract class JsonStorage<T> : IDataProcessing<T> where T : IModelForCrud
    {
        protected List<T> List { get; set; }
        private string _path { get; set; }

        JsonSerializerOptions options = new()
        {
            WriteIndented = true,
            Converters = { new JsonStringEnumConverter() }
        };

        protected JsonStorage(string path)
        {
            _path = path;
            List = ReadJson();
        }

        public T Create(T element)
        {
            if (element != null)
                List.Add(element);
            SaveChanges(List);
            return element;
        }

        public T Get(int id)
        {
            var result = List.Where(element => element.Id == id).FirstOrDefault();
            return result;
        }

        public void Delete(int id)
        {
            T ToDelete = Get(id);

            if (List.Contains(ToDelete))
            {
                List.Remove(ToDelete);
            }

            SaveChanges(List);
        }

        public List<T> GetAll()
        {
            return List;
        }

        public T Update (T element)
        {
            var toUpdate = Get(element.Id);

            toUpdate.Id = element.Id;
            UpdateData(element, toUpdate);

            SaveChanges(List);
            return element;
        }


        protected abstract void UpdateData(T element, T toUpdate); 

        private List<T> ReadJson()
        {
            var List = new List<T>();
            var json = ReadFile();

            if (!string.IsNullOrEmpty(json))
            {
                List = JsonSerializer.Deserialize<List<T>>(json, options);
            }

            return List;
        }

        public string ReadFile()
        {
            if (File.Exists(_path))
            {
                using (var reader = new StreamReader(_path))
                {
                    return reader.ReadToEnd();
                }
            }
            else
            {
                return null;
            }
        }

        protected void SaveChanges(List<T> List)
        {
            string json = JsonSerializer.Serialize(List, options);

            using (var writer = new StreamWriter(_path))
            {
                writer.Write(json);
            }
        }

    }
}
