using AfiCustomerApi.Data.Context;
using AfiCustomerApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
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
            try
            {
                _context.AfiCustomer.Add(customer);
                 _context.SaveChanges();
            }
            catch(Exception ex)
            {
                return -1;
            }
            var Id = customer.AfiCustomerID;
            return Id;
        }
    }

    public interface IAfiCustomerRepository
    {
        Task<int> CreateAfiCustomer(AfiCustomer customer);
    }
}
