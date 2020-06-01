using AfiCustomerApi.Data.Models;
using System;
using System.Threading.Tasks;

namespace AfiCustomerApi.Services
{
    public class AfiCustomerService : IAfiCustomerService
    {
        public async Task<int> RegisterAfiCustomer(AfiCustomer customer)
        {
            return await Task.FromResult(10);
        }
    }

    public interface IAfiCustomerService
    {
        //some result
        Task<int> RegisterAfiCustomer(AfiCustomer customer);
    }
}
