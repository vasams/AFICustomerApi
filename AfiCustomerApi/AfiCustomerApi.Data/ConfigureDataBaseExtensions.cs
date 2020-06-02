using AfiCustomerApi.Data.Context;
using AfiCustomerApi.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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

            services.AddTransient<IAfiCustomerRepository, AfiCustomerRepository>();
        }
    }
}
