using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AfiCustomerApi.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AfiCustomerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AfiCustomerController : ControllerBase
    {
        
        private readonly ILogger<AfiCustomerController> _logger;

        public AfiCustomerController(ILogger<AfiCustomerController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<int> RegisterCustomer([FromBody] AfiCustomer customer)
        {
            return await Task.Run(() =>
            {
                return 1;
            });
        }
    }
}
