using HmoServer.Models;
using HmoServer.Models.Interfaces;
using HmoServer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HmoServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoronaDetailsController : ControllerBase
    {
        private readonly HmoContext _context;
        private readonly ICoronaDetailsValidation _validation;
        public CoronaDetailsController(HmoContext context, ICoronaDetailsValidation validation)
        {
            _context = context;
            _validation = validation;
        }

        [HttpGet]
        [Route("GetCoronaDetails")]
        public async Task<IActionResult> GetCoronaDetails()
        {
            try
            {
                List<CoronaDetail> listCoronaDetails = _context.CoronaDetails.ToList();

                if (listCoronaDetails != null)
                {
                    return Ok(listCoronaDetails);
                }
                else
                {
                    return Ok("There are no Corona Details in the DB");
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("AddCoronaDetails")]
        public async Task<bool> CreateCoronaDetails([FromBody] CoronaDetail coronaDetails)
        {
            _validation.Validate(coronaDetails);
           var res =  COronaDetailsService.AddNewCoronaDetail(coronaDetails);
            throw new NotImplementedException();
            return true;
        }

        //[HttpPost]
        //[Route("AddCustomer")]
        //public async Task<bool> CreateCustomer([FromBody] Customer data)
        //{
        //    Customer customer = new Customer();
        //    //customer.PhoneNumber = data.PhoneNumber;
        //    //customer.LastName = data.LastName;
        //    //customer.FirstName = data.FirstName;
        //    //customer.CustomerId = data.CustomerId;
        //    _context.Customers.Add(customer);
        //    var res = await _context.SaveChangesAsync() >= 0;
        //    if (res)
        //    {
        //        return true;
        //    }
        //    return false;
        //}
    }
}
