using HmoServer.Models;
using HmoServer.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HmoServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly HmoContext _context;
        private readonly ICustomerValidation _customerValidation;

        public CustomerController(HmoContext context,
            ICustomerValidation customerValidation)
        {
            _context = context;
            _customerValidation = customerValidation;
        }
        [HttpGet]
        [Route("GetCustomers")]
        public async Task<IActionResult> GetCustomers()
        {
            try
            {
                List<Customer> listCustomers = _context.Customers.ToList();

                if (listCustomers != null)
                {
                    return Ok(listCustomers);
                }
                else
                {
                    return Ok("There are no Customers in the DB");
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("AddCustomer")]
        public async Task<bool> CreateCustomer([FromBody] Customer customer)
        {
            _customerValidation.Validate(customer);
            
            _context.Customers.Add(customer);
            var res = await _context.SaveChangesAsync() >= 0;
            if (res)
            {
                return true;
            }
            return false;
        }
    }
}
