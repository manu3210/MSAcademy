using CarRentalsWebAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Xunit;
/*
namespace CarRentalsWebAPI.IntegrationTests.Controllers
{
    public class CarControllerTests : IClassFixture<TestingAppFactory<Program>>
    {
        private readonly TestingAppFactory<Program> _factory;
        private readonly HttpClient _client;
        private readonly CarDto _car;

        public CarControllerTests(TestingAppFactory<Program> factory)
        {
            _factory = factory;
            _client = factory.CreateClient();

            _car = new CarDto
            {
                Brand = new BrandDto { Id = 4, BrandName = "Chevrolet" },
                Color = "Blue",
                Model = "Onix",
                Doors = 4,
                IsRented = false,
                Transmition = CarRentals.Enum.Transmition.Manual
            };
        }

        [Fact]
        public async Task GetCars_ReturnsOk()
        {
            // Act

            var result = await _client.GetAsync("api/Cars/");

            // Assert

            result.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }

        [Fact]
        public async Task GetCar_WhenTheCarWasFound_ReturnsOk()
        {
            // Act

            var result = await _client.GetAsync("api/Cars/1");

            // Assert

            result.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }

        [Fact]
        public async Task GetCar_WhenTheCarWasNotFound_ReturnsNotFound()
        {
            // Act

            var statusCode = await _client.GetAsync("api/Cars/100");

            // Assert

            Assert.Equal(HttpStatusCode.NotFound, statusCode.StatusCode);
        }

        [Fact]
        public async Task PutCar_WhenTheCarWasSuccesfullyUpdated_ReturnsOk()
        {
            // Act

            var result = await _client.PutAsJsonAsync("api/Cars/20", _car);

            // Assert

            result.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }

        [Fact]
        public async Task PutCar_WhenTheCarToUpdateIsNull_ReturnsNotFound()
        {
            // Act

            var result = await _client.PutAsJsonAsync("api/Cars/100", _car);

            // Assert

            Assert.Equal(HttpStatusCode.NotFound, result.StatusCode);
        }

        [Fact]
        public async Task PostCar_WhenCarWasSuccesfullyAddedToTheDB_ReturnsOk()
        {
            // Act

            var result = await _client.PostAsJsonAsync("api/Cars", _car);

            // Assert

            result.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);

        }

        [Fact]
        public async Task PostCar_WhenTheCarToAddIsNull_ReturnsBadRequest()
        {
            // Arrange
            CarDto car = null;

            // Act

            var result = await _client.PostAsJsonAsync("api/Cars/", car);

            // Assert

            Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);
        }

        [Fact]
        public async Task DeleteCar_ReturnsNoContent()
        {
            // Act

            var result = await _client.DeleteAsync("api/Cars/30");

            // Assert

            Assert.Equal(HttpStatusCode.NoContent, result.StatusCode);
        }
    
    }
}
*/