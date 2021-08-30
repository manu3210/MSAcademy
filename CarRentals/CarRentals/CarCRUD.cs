
using CarRentals.Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentals
{
    public class CarCRUD
    {
        const string PATH = @"D:\Usuarios\Manu\Escritorio\Academy\MSAcademy\CarRentals\Cars.json";

        private List<Car> CarList;


        public CarCRUD()
        {
            ReadJson();
        }


        public void Create(Car car)
        {
            CarList.Add(car);
            SaveChanges();
        }


        public Car Get(int id)
        {
            Car Result = null;

            foreach (Car car in CarList)
            {
                if (id == car.Id)
                {
                    Result = car;
                    break;
                }
            }

            if(Result == null)
            {
                throw new CarNotFoundException("The car was not found");
            }

            return Result;
        }


        public Car Update(Car car)
        {

            for (var i = 0; i < CarList.Count; i++)
            {
                if (car.Id == CarList[i].Id)
                {
                    CarList[i] = car;
                }
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


        public void ReadJson()
        {
            CarList = new List<Car>();

            try
            {
                var json = System.IO.File.ReadAllText(PATH);

                if (!string.IsNullOrEmpty(json))
                {
                    CarList = JsonConvert.DeserializeObject<List<Car>>(json);
                }
            }
            catch
            {

            }
        }

        public void SaveChanges()
        {
            var json = JsonConvert.SerializeObject(CarList);

            System.IO.File.WriteAllText(PATH, json);
        }

        public string ReadFile()
        {
            return System.IO.File.ReadAllText(PATH);
        }


    }
}
