using AfiCustomerApi.Data.Context;
using AfiCustomerApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AfiCustomerApi.Data.Repository
{
    class AfiCustomerRepository : IAfiCustomerRepository
    {
        private readonly AfiCustomerDbContext _context;
        public AfiCustomerRepository(AfiCustomerDbContext context)
        {
            _context = context;
        }
        public void CreateAfiCustomer(AfiCustomer customer)
        {
            _context.AfiCustomers.Add(customer);
            _context.SaveChanges();
        }
    }

    internal interface IAfiCustomerRepository
    {
        void CreateAfiCustomer(AfiCustomer customer);
    }
}
