using AfiCustomerApi.Data.Context;
using AfiCustomerApi.Data.Models;
using System;
using System.Threading.Tasks;

namespace AfiCustomerApi.Data.Repository
{
    class AfiCustomerRepository : IAfiCustomerRepository
    {
        private readonly AfiCustomerDbContext _context;
        public AfiCustomerRepository(AfiCustomerDbContext context)
        {
            _context = context;
        }
        public async Task<int> CreateAfiCustomer(AfiCustomer customer)
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    _context.AfiCustomer.Add(customer);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    //if error return -2
                    return -2;
                }
                var Id = customer.AfiCustomerID;
                return Id;
            });
            return result;     
        }
    }

    public interface IAfiCustomerRepository
    {
        Task<int> CreateAfiCustomer(AfiCustomer customer);
    }
}
