using CarRentals.Models;
using CarRentalsWebAPI.DTO;
using CarRentalsWebAPI.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CarRentalsWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: api/Customer
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CustomerDto>))]
        public IActionResult GetCustomers()
        {
            var list = new List<CustomerDto>();

            foreach (Customer item in _customerService.GetAll())
            {
                list.Add(new CustomerDto(item));
            }

            return Ok(list);
        }

        // GET: api/Customer/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomerDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetCustomer(int id)
        {
            var customer = _customerService.Get(id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(new CustomerDto(customer));
        }

        // PUT: api/Customer/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomerDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult PutCustomer(int id, CustomerDto customer)
        {
            var toUpdate = _customerService.Update(id, CustomerDto.DtoToEntity(customer));

            if (toUpdate == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        // POST: api/Customer
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomerDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult PostCustomer(CustomerDto customerDto)
        {
            var customer = CustomerDto.DtoToEntity(customerDto);
            var customerAdded = _customerService.Create(customer);

            if (customerAdded == null)
            {
                return BadRequest();
            }

            return Ok(new CustomerDto(customerAdded));
        }

        // DELETE: api/Customer/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult DeleteCustomer(int id)
        {
            _customerService.Delete(id);

            return NoContent();
        }
    }
}
