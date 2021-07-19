using Customers.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customers.Server.Services
{
    public interface ICustomerService
    {
        FileStreamResult CreateCustomerClient(Customer customer);
        string CreateCustomerServer(Customer customer, string path);
    }
}
