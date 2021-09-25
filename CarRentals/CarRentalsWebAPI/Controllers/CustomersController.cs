using CarRentalsWebAPI.DTO;
using CarRentalsWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalsWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly CarRentalsContext _context;

        public CustomersController(CarRentalsContext context)
        {
            _context = context;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetCustomers()
        {
            return await _context.Customers.Select(x => new CustomerDto(x)).ToListAsync();
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDto>> GetCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return new CustomerDto(customer);
        }

        // PUT: api/Customers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, CustomerDto customer)
        {
            var customerModel = await _context.Customers.FindAsync(id);

            if (customerModel == null)
            {
                return null;
            }

            customerModel.Id = customer.Id;
            customerModel.Dni = customer.Dni;
            customerModel.FirstName = customer.FirstName;
            customerModel.LastName = customer.LastName;
            customerModel.Phone = customer.Phone;
            customerModel.Adress = customer.Adress;
            customerModel.City = customer.City;
            customerModel.Province = customer.Province;
            customerModel.LastModification = customer.LastModification;
            customerModel.ZipCode = customer.ZipCode;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Customers
        [HttpPost]
        public async Task<ActionResult<CustomerDto>> PostCustomer(CustomerDto customer)
        {
            _context.Customers.Add(CustomerDto.DtoToEntity(customer));
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomer", new { id = customer.Id }, customer);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }
    }
}
