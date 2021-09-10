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
        private List<Car> _carList;
        public ManageJson<Car> JsonFile { get; }


        JsonSerializerOptions options = new()
        {
            WriteIndented = true,
            Converters = { new JsonStringEnumConverter() }
        };

        public CarCRUD(ProgramOptions configuration)
        {
            JsonFile = new ManageJson<Car>(configuration.JsonFile);
            _carList = JsonFile.ReadJson();
        }

        public void Create(Car car)
        {
            if (car != null)
                _carList.Add(car);
            JsonFile.SaveChanges(_carList);
        }

        public Car Get(int id)
        {
            Car Result = _carList.Where(car => car.Id == id).FirstOrDefault();
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

            JsonFile.SaveChanges(_carList);
            return car;
        }

        public void Delete(int id)
        {
            Car ToDelete = Get(id);

            if (_carList.Contains(ToDelete))
            {
                _carList.Remove(ToDelete);
            }

            JsonFile.SaveChanges(_carList);
        }

        
    }
}
