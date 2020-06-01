using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        [HttpGet]
        public async Task<int> Get()
        {
          return await Task.Run( () =>
              {
                return 1;
            });
        }
    }
}
