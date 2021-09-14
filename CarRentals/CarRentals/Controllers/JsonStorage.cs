﻿using CarRentals.Interfaces;
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

        public void Create(T element)
        {
            if (element != null)
                List.Add(element);
            SaveChanges(List);
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

        public abstract T Update(T element); // To override in child classes

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
