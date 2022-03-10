using CarRentalsWebAPI.DTO;
using CarRentalsWebAPI.Interfaces;
using CarRentalsWebAPI.Mediator.Querys;
using CarRentalsWebAPI.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRentalsWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Customer
        /// <summary>
        /// Gets the complete list of customer objects
        /// </summary>
        /// <response code="200">Returns a customer list</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CustomerDto>))]
        public async Task<IActionResult> GetCustomers()
        {
            return Ok(await _mediator.Send(new GetAllCustomers()));
        }

        // GET: api/Customer/5
        /// <summary>
        /// Get a specific customer.
        /// </summary>
        /// <param name="id">customer id which we want to get</param>
        /// <response code="200">Returns a specific customer</response>
        /// <response code="404">the customer id specified was not found</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomerDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCustomer(int id)
        {
            var customer = await _mediator.Send(new GetCustomerById(id));

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        // PUT: api/Customer/5
        /// <summary>
        /// Updates a customer specified by the id parameter
        /// </summary>
        /// <param name="id">Id of the customer to update</param>
        /// <param name="customer">customer object with updated fields</param>
        /// <response code="200">customer was succesfully updated. It returns the updated customer</response>
        /// <response code="404">customer to update was not found</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomerDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutCustomer(int id, CustomerDto customer)
        {
            if (customer == null)
            {
                return BadRequest();
            }

            var toUpdate = await _mediator.Send(new UpdateCustomer(id, customer));

            if (toUpdate == null)
            {
                return NotFound();
            }

            return Ok(toUpdate);
        }

        // POST: api/Customer
        /// <summary>
        /// Add a new customer to the storage
        /// </summary>
        /// <param name="customerDto">customer that will be added</param>
        /// <response code="200">customer was succesfully added. It returns the added customer</response>
        /// <response code="400">customer to add was null</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomerDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostCustomer(CustomerDto customerDto)
        {
            if (customerDto == null)
                return BadRequest();

            var customerAdded = await _mediator.Send(new CreateCustomer(customerDto));

            if (customerAdded == null)
            {
                return BadRequest();
            }

            return Ok(customerAdded);
        }

        // DELETE: api/Customer/5
        /// <summary>
        /// Delete a customer from the storage
        /// </summary>
        /// <param name="id">Id of the customer we want to delete</param>
        /// <response code="204">customer was succesfully deleted</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            await _mediator.Send(new DeleteCustomer(id));

            return NoContent();
        }
    }
}
