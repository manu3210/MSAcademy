using CarRentalsWebAPI.DTO;
using CarRentalsWebAPI.Models;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;
using System.Collections.Generic;

namespace CarRentalsWebAPI.IntegrationTests.Controllers
{
    public class CarControllerTests : IClassFixture<TestingAppFactory<Program>>
    {
        private readonly TestingAppFactory<Program> _factory;
        private readonly HttpClient _client;

        public CarControllerTests(TestingAppFactory<Program> factory)
        {
            _factory = factory;
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetCars_ReturnsOk()
        {
            // Act

            var status = await _client.GetAsync("api/Cars");
            var result = await _client.GetFromJsonAsync<List<CarDto>>("api/Cars");

            // Assert

            status.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, status.StatusCode);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetCar_WhenTheCarWasFound_ReturnsOk()
        {
            // Act

            var status = await _client.GetAsync("api/Cars/1");
            var result = await _client.GetFromJsonAsync<CarDto>("api/Cars/1");

            // Assert

            status.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, status.StatusCode);
            Assert.NotNull(result);
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
            // Arrange

            var car = new CarDto
            {
                Brand = await _client.GetFromJsonAsync<BrandDto>("api/Brands/1"),
                Color = "Blue",
                Model = "Onix",
                Doors = 4,
                IsRented = false,
                Transmition = CarRentals.Enum.Transmition.Manual
            };

            // Act

            var result = await _client.PutAsJsonAsync("api/Cars/2", car);

            // Assert

            result.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }

        [Fact]
        public async Task PutCar_WhenTheCarToUpdateIsNull_ReturnsNotFound()
        {
            // Arrange

            Car car = null; 

            // Act

            var result = await _client.PutAsJsonAsync("api/Cars/100", car);

            // Assert

            Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);
        }

        [Fact]
        public async Task PostCar_WhenCarWasSuccesfullyAddedToTheDB_ReturnsOk()
        {
            // Arrange

            var car = new CarDto
            {
                Brand = new BrandDto { Id = 5, BrandName = "Chevrolet" },
                Color = "Blue",
                Model = "Onix",
                Doors = 4,
                IsRented = false,
                Transmition = CarRentals.Enum.Transmition.Manual
            };

            // Act

            var result = await _client.PostAsJsonAsync("api/Cars", car);

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

            var result = await _client.DeleteAsync("api/Cars/3");

            // Assert

            Assert.Equal(HttpStatusCode.NoContent, result.StatusCode);
        }

    }
}
