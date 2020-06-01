using AfiCustomerApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AfiCustomerApi.Services.Services
{
    public class AfiCustomerValidationService : IAfiCustomerValidationService
    {
        public async Task<bool> ValidateCustomerEntity(AfiCustomer afiCustomer)
        {
            return await Task.FromResult(true);
        }
    }

    public interface IAfiCustomerValidationService
    {
        Task<bool> ValidateCustomerEntity(AfiCustomer afiCustomer);
       
    }
}
