using HmoServer.Models;
using Microsoft.EntityFrameworkCore;

namespace HmoServer.Services
{
    public class COronaDetailsService
    {
        static HmoContext _context  = new HmoContext();
        

        public static async Task<bool> AddNewCoronaDetail(CoronaDetail coronaDetailsDto)
        {
            //CoronaDetail newCoronaDetail = coronaDetailsDto.ToCoronaDetail();
            _context.CoronaDetails.Add(coronaDetailsDto);
            var res = await _context.SaveChangesAsync() >= 0;
            if (res)
            {
                return true;
            }
            return false;
            // _dbContext.SaveChanges();
            //return new CoronaDetailsDto(newCoronaDetail);

        }
    }
}
