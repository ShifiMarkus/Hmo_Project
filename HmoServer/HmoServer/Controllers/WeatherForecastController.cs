using Microsoft.AspNetCore.Mvc;
using HmoServer.Models;
namespace HmoServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly HmoContext _context;
        public WeatherForecastController(HmoContext context)
        {
            _context = context;
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

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
    }
}