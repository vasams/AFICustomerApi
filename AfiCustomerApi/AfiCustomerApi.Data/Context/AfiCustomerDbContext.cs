using AfiCustomerApi.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AfiCustomerApi.Data.Context
{
    public class AfiCustomerDbContext : DbContext
    {
        public AfiCustomerDbContext(DbContextOptions<AfiCustomerDbContext> options) : base(options)
        {

        }
        public DbSet<AfiCustomer> AfiCustomers;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 
        }

    }
}
