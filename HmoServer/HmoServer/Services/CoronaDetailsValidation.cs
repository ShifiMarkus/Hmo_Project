using HmoServer.Models;
using HmoServer.Models.Interfaces;

namespace HmoServer.Services
{
    public class CoronaDetailsValidation : ICoronaDetailsValidation
    {
        public void Validate(CoronaDetail coronaDetail)
        {
       if(coronaDetail.FirstVaccitionDate > DateTime.Now || coronaDetail.SecondVaccitionDate > DateTime.Now || coronaDetail.ThirdVaccitionDate > DateTime.Now || coronaDetail.ForthVaccitionDate > DateTime.Now )
            {
                throw new Exception("vaccination date must be earlier or equal to today");
            }
       if(coronaDetail.SecondVaccitionDate < coronaDetail.FirstVaccitionDate)
            {
                //this check should be also for the third and fourth vaccination date
                throw new Exception("second vaccination date must be after te first one");
            }
       if(coronaDetail.FirstVaccitionDate == null && coronaDetail.SecondVaccitionDate != null)
            {
                //this check should be also for the third and fourth vaccination date
                throw new Exception("yot canwt do second vaccination in front of the first one");
            }

       //check if customer_id exist in customers table
       //check if id is not exist yet(it's should be null
    }
    }
    
}
