using AfiCustomerApi.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AfiCustomerApi.Data
{
    public static class ConfigureDataBaseExtensions
    {
        public static void ConfigureDataBaseApi(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AfiCustomerDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("AfiCustomerDbString"));
            });
        }
    }
}
