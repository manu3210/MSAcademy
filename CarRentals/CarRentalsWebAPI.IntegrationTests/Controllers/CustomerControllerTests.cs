using CarRentalsWebAPI.DTO;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace CarRentalsWebAPI.IntegrationTests.Controllers
{
    public class CustomerControllerTests : IClassFixture<TestingAppFactory<Program>>
    {
        private readonly TestingAppFactory<Program> _factory;
        private readonly HttpClient _client;

        public CustomerControllerTests(TestingAppFactory<Program> factory)
        {
            _factory = factory;
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetCustomer_ReturnsTheCompleteListOfCustomers()
        {
            // Act

            var statusCode = await _client.GetAsync("api/Customers/");
            var result = await _client.GetFromJsonAsync<List<CustomerDto>>("api/Customers/");

            // Assert

            statusCode.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, statusCode.StatusCode);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetCustomer_WhenTheCustomerWasFound_ReturnsOkAndTheCustomers()
        {
            // Act

            var statusCode = await _client.GetAsync("api/Customers/1");
            var result = await _client.GetFromJsonAsync<CustomerDto>("api/Customers/1");

            // Assert

            statusCode.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, statusCode.StatusCode);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetCustomer_WhenTheCustomerWasNotFound_ReturnsNotFound()
        {
            // Act

            var statusCode = await _client.GetAsync("api/Customers/100");

            // Assert

            Assert.Equal(HttpStatusCode.NotFound, statusCode.StatusCode);
        }

        [Fact]
        public async Task PutCustomer_WhenTheCustomerWasSuccesfullyUpdated_ReturnsOk()
        {
            // Arrange

            var customer = new CustomerDto
            {
                Adress = "Adress4",
                City = "City4",
                Dni = "13236546",
                FirstName = "Name1",
                LastModification = System.DateTime.Now,
                LastName = "LastName4",
                Phone = "321354",
                Province = "Province1",
                ZipCode = 2222
            };
            // Act

            var result = await _client.PutAsJsonAsync("api/Customers/2", customer);

            // Assert

            result.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }

        [Fact]
        public async Task PutCustomer_WhenTheCustomerToUpdateIsNull_ReturnsNotFound()
        {
            // Arrange

            CustomerDto customer = null;

            // Act

            var result = await _client.PutAsJsonAsync("api/Customers/2", customer);

            // Assert

            Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);
        }

        [Fact]
        public async Task PostCustomer_WhenCustomerWasSuccesfullyAddedToTheDB_ReturnsOk()
        {
            // Arrange

            var customer = new CustomerDto
            {
                Id = 5,
                Adress = "Adress5",
                City = "City5",
                Dni = "13852046",
                FirstName = "Name5",
                LastModification = System.DateTime.Now,
                LastName = "LastName5",
                Phone = "321354",
                Province = "Province5",
                ZipCode = 2200
            };

            // Act

            var result = await _client.PostAsJsonAsync<CustomerDto>("api/Customers", customer);

            // Assert

            result.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);

        }

        [Fact]
        public async Task PostCustomer_WhenTheCustomerToAddIsNull_ReturnsBadRequest()
        {
            // Arrange
            CustomerDto Customer = null;

            // Act

            var result = await _client.PostAsJsonAsync("api/Customers/", Customer);

            // Assert

            Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);
        }

        [Fact]
        public async Task DeleteCustomers_ReturnsNoContent()
        {
            // Act

            var result = await _client.DeleteAsync("api/Customers/3");

            // Assert

            Assert.Equal(HttpStatusCode.NoContent, result.StatusCode);
        }
    }
}
