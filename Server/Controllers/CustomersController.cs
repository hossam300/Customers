using Customers.Server.Services;
using Customers.Shared;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Customers.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ILogger<CustomersController> _logger;
        private readonly ICustomerService _customerService;
        private readonly IWebHostEnvironment _environment;
        public CustomersController(ILogger<CustomersController> logger, ICustomerService customerService, IWebHostEnvironment Environment)
        {
            _logger = logger;
            _customerService = customerService;
            _environment = Environment;
        }
        [HttpPost("CreateCustomerClient")]
        public FileStreamResult CreateCustomerClient([FromBody] Customer customer)
        {
            return _customerService.CreateCustomerClient(customer);
        }
        [HttpPost("CreateCustomerServer")]
        public string CreateCustomerServer([FromBody] Customer customer)
        {
            return _customerService.CreateCustomerServer(customer,$"{_environment.WebRootPath}\\JsonFiles\\");
        }
    }
}
