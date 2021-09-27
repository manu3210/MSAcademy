using CarRentals.Models;
using CarRentalsWebAPI.DTO;
using CarRentalsWebAPI.Interfaces;
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
        public ActionResult<List<CustomerDto>> GetCustomers()
        {
            List<CustomerDto> list = new List<CustomerDto>();

            foreach (Customer item in _customerService.GetAll())
            {
                list.Add(new CustomerDto(item));
            }

            return Ok(list);
        }

        // GET: api/Customer/5
        [HttpGet("{id}")]
        public ActionResult<CustomerDto> GetCustomer(int id)
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
        public IActionResult PutCustomer(int id, CustomerDto customer)
        {
            var toUpdate = _customerService.Update(id, CustomerDto.DtoToEntity(customer));

            if (toUpdate == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Customer
        [HttpPost]
        public ActionResult<CustomerDto> PostCustomer(CustomerDto customerDto)
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
        public IActionResult DeleteCustomer(int id)
        {
            _customerService.Delete(id);

            return NoContent();
        }
    }
}
