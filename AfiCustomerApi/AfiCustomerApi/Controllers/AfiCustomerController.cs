using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AfiCustomerApi.Data.Models;
using AfiCustomerApi.Services;
using AfiCustomerApi.Services.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;

namespace AfiCustomerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AfiCustomerController : ControllerBase
    {
        
        private readonly ILogger<AfiCustomerController> _logger;
        private readonly IAfiCustomerService _afiCustomerService;
        private readonly IAfiCustomerValidationService _afiCustomerValidationService;
        public AfiCustomerController(IAfiCustomerService afiCustomerService,
                                    IAfiCustomerValidationService afiCustomerValidationService,
                                    ILogger<AfiCustomerController> logger)
        {
            _afiCustomerService = afiCustomerService;
            _afiCustomerValidationService = afiCustomerValidationService;
            _logger = logger;
        }
       

        [HttpPost]
        [Route("RegisterCustomer")]
        public async Task<int> RegisterCustomer([FromBody] AfiCustomer customer)
        {
           if(await _afiCustomerValidationService.ValidateCustomerEntity(customer))
            {
                return await _afiCustomerService.RegisterAfiCustomer(customer);
            }
           else
            {
                return await Task.FromResult(-1);
            }
        }
    }
}
