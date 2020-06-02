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
                                    IAfiCustomerValidationService afiCustomerValidationService)
        {
            _afiCustomerService = afiCustomerService;
            _afiCustomerValidationService = afiCustomerValidationService;
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
                //Invalid Condition returns -1
                return await Task.FromResult(-1);
            }
        }
    }
}
