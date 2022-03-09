using CarRentalsWebAPI.DTO;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace CarRentalsWebAPI.IntegrationTests.Controllers
{
    public class RentalControllerTests : IClassFixture<TestingAppFactory<Program>>
    {
        private readonly TestingAppFactory<Program> _factory;
        private readonly HttpClient _client;

        public RentalControllerTests(TestingAppFactory<Program> factory)
        {
            _factory = factory;
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetRental_ReturnsTheCompleteListOfRentals()
        {
            // Act

            var statusCode = await _client.GetAsync("api/Rentals/");
            var result = await _client.GetFromJsonAsync<List<RentalDto>>("api/Rentals/");

            // Assert

            statusCode.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, statusCode.StatusCode);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetRental_WhenTheRentalWasFound_ReturnsOkAndTheRental()
        {
            // Act

            var statusCode = await _client.GetAsync("api/Rentals/1");
            var result = await _client.GetFromJsonAsync<RentalDto>("api/Rentals/1");

            // Assert

            statusCode.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, statusCode.StatusCode);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetRental_WhenTheRentalWasNotFound_ReturnsNotFound()
        {
            // Act

            var statusCode = await _client.GetAsync("api/Rentals/100");

            // Assert

            Assert.Equal(HttpStatusCode.NotFound, statusCode.StatusCode);
        }

        [Fact]
        public async Task PutRental_WhenTheRentalWasSuccesfullyUpdated_ReturnsOk()
        {
            // Arrange

            var rental = new RentalDto
            {
                Beginning = DateTime.Now,
                Car = await _client.GetFromJsonAsync<CarDto>("api/Cars/3"),
                Customer = await _client.GetFromJsonAsync<CustomerDto>("api/Customers/3"),
                End = DateTime.Now.AddDays(3),
                Price = 9000
            };

            // Act

            var result = await _client.PutAsJsonAsync("api/Rentals/2", rental);

            // Assert

            result.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }

        [Fact]
        public async Task PutRental_WhenTheRentalToUpdateIsNull_ReturnsNotFound()
        {
            // Arrange

            RentalDto rental = null;

            // Act

            var result = await _client.PutAsJsonAsync("api/Rentals/2", rental);

            // Assert

            Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);
        }

        [Fact]
        public async Task PostRental_WhenRentalWasSuccesfullyAddedToTheDB_ReturnsOk()
        {
            // Arrange

            var rental = new RentalDto
            {
                Beginning = DateTime.Now,
                Car = new CarDto
                {
                    Id = 4,
                    Brand = new BrandDto { Id = 4, BrandName = "Ford" },
                    Color = "Grey",
                    Doors = 4,
                    IsRented = false,
                    Model = "Fiesta",
                    Transmition = CarRentals.Enum.Transmition.Manual
                },
                Customer = new CustomerDto
                {
                    Id = 4,
                    Adress = "Adress1",
                    City = "City1",
                    Dni = "13236546",
                    FirstName = "Name1",
                    LastModification = System.DateTime.Now,
                    LastName = "LastName1",
                    Phone = "321354",
                    Province = "Province1",
                    ZipCode = 2200
                },
                End = DateTime.Now.AddDays(2),
                Price = 5000
            };


            // Act
            var result = await _client.PostAsJsonAsync<RentalDto>("api/Rentals", rental);

            // Assert

            result.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }

        [Fact]
        public async Task PostRental_WhenTheRentalToAddIsNull_ReturnsBadRequest()
        {
            // Arrange
            RentalDto rental = null;

            // Act

            var result = await _client.PostAsJsonAsync("api/Rentals/", rental);

            // Assert

            Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);
        }

        [Fact]
        public async Task DeleteRental_ReturnsNoContent()
        {
            // Act

            var result = await _client.DeleteAsync("api/Rentals/3");

            // Assert

            Assert.Equal(HttpStatusCode.NoContent, result.StatusCode);
        }
    }
}
