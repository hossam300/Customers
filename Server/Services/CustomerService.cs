using Customers.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customers.Server.Services
{
    public class CustomerService : ICustomerService
    {
        public JsonResult CreateCustomer(Customer customer)
        {
            return new JsonResult(customer);
        }
    }
}
