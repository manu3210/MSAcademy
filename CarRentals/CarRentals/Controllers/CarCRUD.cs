using CarRentals.Interfaces;
using Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CarRentals
{
    public class CarCRUD : IDataProcessing
    {
        private readonly string _path;
        private List<Car> CarList;

        JsonSerializerOptions options = new()
        {
            WriteIndented = true,
            Converters = { new JsonStringEnumConverter() }
        };

        public CarCRUD(ProgramOptions configuration)
        {
            _path = configuration.JsonFile;
            ReadJson();
        }

        public void Create(Car car)
        {
            if (car != null)
                CarList.Add(car);
            SaveChanges();
        }

        public Car Get(int id)
        {
            Car Result = CarList.Where(car => car.Id == id).FirstOrDefault();
            return Result;
        }

        public Car Update(Car car)
        {
            Car toUpdate = Get(car.Id);

            toUpdate.Doors = car.Doors;
            toUpdate.Brand = car.Brand;
            toUpdate.Color = car.Color;
            toUpdate.Model = car.Model;
            toUpdate.Transmition = car.Transmition;

            SaveChanges();
            return car;
        }

        public void Delete(int id)
        {
            Car ToDelete = Get(id);

            if (CarList.Contains(ToDelete))
            {
                CarList.Remove(ToDelete);
            }

            SaveChanges();
        }

        private void ReadJson()
        {
            CarList = new List<Car>();
            var json = ReadFile();

            if (!string.IsNullOrEmpty(json))
            {
                CarList = JsonSerializer.Deserialize<List<Car>>(json, options);
            }

        }

        private void SaveChanges()
        {
            string json = JsonSerializer.Serialize(CarList, options);

            using (var writer = new StreamWriter(_path))
            {
                writer.Write(json);
            }
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
    }
}
