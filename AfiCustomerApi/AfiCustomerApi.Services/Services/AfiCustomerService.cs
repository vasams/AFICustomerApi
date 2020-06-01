using AfiCustomerApi.Data.Models;
using System;

namespace AfiCustomerApi.Services
{
    public class AfiCustomerService : IAfiCustomerService
    {
        public int RegisterAfiCustomer(AfiCustomer customer)
        {
            throw new NotImplementedException();
        }
    }

    public interface IAfiCustomerService
    {
        //some result
        int RegisterAfiCustomer(AfiCustomer customer);
    }
}
