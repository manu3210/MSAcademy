using CarRentalsWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarRentalsWebAPI.IntegrationTests
{
    public static class Utilities
    {
        public static void InitializeDbForTests(CarRentalsContext db)
        {
            if (db.Brands.Any())
                db.Brands.RemoveRange(db.Brands);
            if (db.Cars.Any())
                db.Cars.RemoveRange(db.Cars);
            if (db.Customers.Any())
                db.Customers.RemoveRange(db.Customers);
            if (db.Rentals.Any())
                db.Rentals.RemoveRange(db.Rentals);

            db.Rentals.AddRange(SetRentalList());

            db.SaveChanges();
        }
        private static List<Rental> SetRentalList()
        {
            return new List<Rental> {
                    new Rental {
                        Id = 1,
                        Beginning = DateTime.Now,
                        Car = new Car {
                            Id = 1,
                            Brand = new Brand { Id = 1, BrandName = "Ford" },
                            Color = "Grey",
                            Doors = 4,
                            IsRented = false,
                            Model = "Fiesta",
                            Transmition = CarRentals.Enum.Transmition.Manual},
                        Customer = new Customer {
                            Id = 1,
                            Adress = "Adress1",
                            City= "City1",
                            Dni = "13236546",
                            FirstName = "Name1",
                            LastModification = System.DateTime.Now,
                            LastName = "LastName1",
                            Phone = "321354",
                            Province = "Province1",
                            ZipCode = 2200},
                        End = DateTime.Now.AddDays(2),
                        Price = 5000 },

                    new Rental {
                        Id = 2,
                        Beginning = DateTime.Now,
                        Car = new Car {
                            Id = 2,
                            Brand = new Brand { Id = 2, BrandName = "Honda" },
                            Color = "Black",
                            Doors = 4,
                            IsRented = false,
                            Model = "Civic",
                            Transmition = CarRentals.Enum.Transmition.Automatic},
                        Customer = new Customer {
                            Id = 2,
                            Adress = "Adress2",
                            City= "City2",
                            Dni = "13298746",
                            FirstName = "Name2",
                            LastModification = System.DateTime.Now,
                            LastName = "LastName2",
                            Phone = "987654",
                            Province = "Province2",
                            ZipCode = 4400},
                        End = DateTime.Now.AddDays(3),
                        Price = 9000 },

                    new Rental {
                        Id = 3,
                        Beginning = DateTime.Now,
                        Car = new Car {
                            Id = 3,
                            Brand = new Brand { Id = 3, BrandName = "Peugeot" },
                            Color = "Red",
                            Doors = 4,
                            IsRented = false,
                            Model = "Focus",
                            Transmition = CarRentals.Enum.Transmition.Automatic},
                        Customer = new Customer {
                            Id = 3,
                            Adress = "Adress3",
                            City= "City3",
                            Dni = "136548746",
                            FirstName = "Name3",
                            LastModification = System.DateTime.Now,
                            LastName = "LastName3",
                            Phone = "988754",
                            Province = "Province3",
                            ZipCode = 6600},
                        End = DateTime.Now.AddDays(3),
                        Price = 9000 }};
        }
    }

}