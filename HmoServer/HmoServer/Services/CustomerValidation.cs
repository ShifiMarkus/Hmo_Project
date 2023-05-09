using HmoServer.Models;
using HmoServer.Models.Interfaces;
using System.Text.RegularExpressions;

namespace HmoServer.Services
{
    public class CustomerValidation : ICustomerValidation
    {
        public void Validate(Customer customer)
        {
            if (customer.CustomerId == 0)
                throw new Exception("Customer id must have a value");
            if (customer.PhoneNumber != "" && !Regex.IsMatch(customer.PhoneNumber, @"^(\+[0-9]{9})$"))
                throw new Exception("Customer Phone Number nust caontian just digits");
            if (customer.CellPhone != "" && !Regex.IsMatch(customer.CellPhone, @"^(\+[0-9]{9})$"))
                throw new Exception("Customer Cell Number nust caontian just digits");
            if (!Regex.Match(customer.City, @"(?:[A-Z][a-z.-]+[ ]?)+").Success)
            {
                throw new Exception("Invalid City");
            }
            if (!Regex.Match(customer.Street, @"\d+[ ](?:[A-Za-z0-9.-]+[ ]?)+(?:Avenue|Lane|Road|Boulevard|Drive|Street|Ave|Dr|Rd|Blvd|Ln|St)\.?").Success)
            {
                throw new Exception("Invalid street");
            }
            DateTime today = DateTime.Now;
            int? age = today.Year - customer.BirthDate?.Year;
            if (today.Month < customer.BirthDate?.Month || (today.Month == customer.BirthDate?.Month && today.Day < customer.BirthDate?.Day)) { age--; }
            if (age < 0 || age > 150)
            {
                throw new Exception("Invalid Birth Date");
            }

        }
    }
}
