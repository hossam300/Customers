using Customers.Server.Services;
using Customers.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Customers.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ILogger<CustomersController> _logger;
        private readonly ICustomerService _customerService;
        public CustomersController(ILogger<CustomersController> logger, ICustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;
        }
        [HttpPost("CreateCustomer")]
        public JsonResult CreateCustomer([FromBody] Customer customer)
        {
            return _customerService.CreateCustomer(customer);
        }

    }
}
