using CarRentalsWebAPI.DTO;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace CarRentalsWebAPI.IntegrationTests
{
    public class BrandControllerTests : IClassFixture<TestingAppFactory<Program>>
    {
        private readonly TestingAppFactory<Program> _factory;
        private readonly HttpClient _client;

        public BrandControllerTests(TestingAppFactory<Program> factory)
        {
            _factory = factory;
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetBrands_ReturnsTheCompleteListOfBrands()
        {
            // Act

           //var statusCode = await _client.GetAsync("api/Brands/");
            var result = await _client.GetFromJsonAsync<List<BrandDto>>("api/Brands/");

            // Assert

            //statusCode.EnsureSuccessStatusCode();
           // Assert.Equal(HttpStatusCode.OK, statusCode.StatusCode);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetBrand_WhenTheBrandWasFound_ReturnsOkAndTheBrand()
        {
            // Act

            var statusCode = await _client.GetAsync("api/Brands/1");
            var result = await _client.GetFromJsonAsync<BrandDto>("api/Brands/1");

            // Assert

            statusCode.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, statusCode.StatusCode);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetBrand_WhenTheBrandWasNotFound_ReturnsNotFound()
        {
            // Act

            var statusCode = await _client.GetAsync("api/Brands/100");

            // Assert

            Assert.Equal(HttpStatusCode.NotFound, statusCode.StatusCode);
        }

        [Fact]
        public async Task PutBrand_WhenTheBrandWasSuccesfullyUpdated_ReturnsOk()
        {
            // Act

            var result = await _client.PutAsJsonAsync("api/Brands/2", new BrandDto { BrandName = "Fiat" });

            // Assert

            result.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }

        [Fact]
        public async Task PutBrand_WhenTheBrandArgIsNull_ReturnsBadRequest()
        {
            // Arrange

            BrandDto brandDto = null;

            // Act

            var result = await _client.PutAsJsonAsync("api/Brands/1", brandDto);

            // Assert

            Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);
        }

        [Fact]
        public async Task PutBrand_WhenTheBrandToUpdateIsNotFound_ReturnsNotFound()
        {
            // Act

            var result = await _client.PutAsJsonAsync("api/Brands/100", new BrandDto {Id = 100, BrandName = "brand"});

            // Assert

            Assert.Equal(HttpStatusCode.NotFound, result.StatusCode);
        }

        [Fact]
        public async Task PostBrand_WhenBrandWasSuccesfullyAddedToTheDB_ReturnsOk()
        {
            // Act

            var result = await _client.PostAsJsonAsync<BrandDto>("api/Brands", new BrandDto {Id = 4, BrandName = "Renault"});

            // Assert

            result.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);

        }

        [Fact]
        public async Task PostBrand_WhenTheBrandToAddIsNull_ReturnsBadRequest()
        {
            // Arrange
            BrandDto brand = null;

            // Act

            var result = await _client.PostAsJsonAsync("api/Brands/", brand);

            // Assert

            Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);
        }

        [Fact]
        public async Task DeleteBrand_ReturnsNoContent()
        {
            // Act

            var result = await _client.DeleteAsync("api/Brands/3");

            // Assert

            Assert.Equal(HttpStatusCode.NoContent, result.StatusCode);
        }

    }
}

