using AfiCustomerApi.Data.Models;
using AfiCustomerApi.Data.Repository;
using System;
using System.Threading.Tasks;

namespace AfiCustomerApi.Services
{
    public class AfiCustomerService : IAfiCustomerService
    {
        IAfiCustomerRepository _customerRepository;
        public AfiCustomerService(IAfiCustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<int> RegisterAfiCustomer(AfiCustomer customer)
        {
            return await _customerRepository.CreateAfiCustomer(customer);
        }
    }

    public interface IAfiCustomerService
    {
        //some result
        Task<int> RegisterAfiCustomer(AfiCustomer customer);
    }
}
