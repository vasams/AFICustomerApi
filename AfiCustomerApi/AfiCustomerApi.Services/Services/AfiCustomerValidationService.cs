using AfiCustomerApi.Data.Models;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AfiCustomerApi.Services.Services
{
    public class AfiCustomerValidationService : IAfiCustomerValidationService
    {
        public async Task<bool> ValidateCustomerEntity(AfiCustomer afiCustomer)
        {
            //Policy holder’s first name and surname are both required and should be between 3 and 50 chars.
            var result = await Task.Run(() =>
            {
                if (string.IsNullOrEmpty(afiCustomer.SurName?.Trim()))
                    return false;
                if (string.IsNullOrEmpty(afiCustomer.FirstName?.Trim()))
                    return false;
                if (afiCustomer.FirstName?.Trim().Length < 3 && afiCustomer.FirstName?.Trim().Length > 50)
                    return false;
                if (afiCustomer.SurName?.Trim().Length < 3 && afiCustomer.SurName?.Trim().Length > 50)
                    return false;

                //Policy Reference number is required and should match the following format XX-999999.
                //Where XX are any capitalised alpha character followed by a hyphen and 6 numbers.

                if (string.IsNullOrEmpty(afiCustomer.PolicyReferenceNumber?.Trim()))
                    return false;
                if (afiCustomer.PolicyReferenceNumber?.Trim().Length < 9)
                    return false;
                if (afiCustomer.Dob == null && string.IsNullOrEmpty(afiCustomer.Email?.Trim()))
                    return false;
                if (!(afiCustomer.Dob == null) && !string.IsNullOrEmpty(afiCustomer.Email?.Trim()))
                    return false;

                Regex policyExpression = new Regex(@"^[A-Z]{2}-[0-9]{6}");
                if (!policyExpression.IsMatch(afiCustomer.PolicyReferenceNumber?.Trim()))
                    return false;

                //If supplied the policy holders email address should contain a string of at least 
                //4 alpha numeric chars followed by an ‘@’ sign and then another string of at least 
                //2 alpha numeric chars.The email address should end in either ‘.com’ or ‘.co.uk’.

                Regex emailExpression = new Regex(@"^[A-Za-z][A-Za-z0-9]{3,}@[A-Za-z0-9]{2,}.(com|co.uk)$");
                if (!string.IsNullOrEmpty(afiCustomer.Email?.Trim()))
                {
                    if (!emailExpression.IsMatch(afiCustomer.Email.Trim()))
                        return false;
                }

                if(afiCustomer.Dob.HasValue)
                {
                    int age = DateTime.Now.Year - afiCustomer.Dob.Value.Year;
                    if (afiCustomer.Dob.Value > DateTime.Now.AddYears(-age))
                        age--;
                    if (age < 18)
                        return false;
                }
                return true;
            });
            return result;
        }
    }

    public interface IAfiCustomerValidationService
    {
        Task<bool> ValidateCustomerEntity(AfiCustomer afiCustomer);
       
    }
}
