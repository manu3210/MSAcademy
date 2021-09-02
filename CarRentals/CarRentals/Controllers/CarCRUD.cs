using CarRentals.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Configuration;

namespace CarRentals
{
    public class CarCRUD : IDataProcessing
    {
        string PATH = ConfigurationManager.AppSettings["JsonFile"].ToString();

        JsonSerializerOptions options = new()
        {
            WriteIndented = true,
            Converters = { new JsonStringEnumConverter() }
        };

        private List<Car> CarList;

        public CarCRUD()
        {
            ReadJson();
        }

        public void Create(Car car)
        {
            if(car != null)
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
            Car getCar = Get(car.Id);

            if (getCar != null)
            {
                CarList[CarList.IndexOf(getCar)] = car;
            }

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

            using(var writer = new StreamWriter(PATH))
            {
                writer.Write(json);
            }
        }

        public string ReadFile()
        {
            if(File.Exists(PATH))
            {
                using (var reader  = new StreamReader(PATH))
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
