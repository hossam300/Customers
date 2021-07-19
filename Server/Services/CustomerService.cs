using Customers.Shared;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customers.Server.Services
{
    public class CustomerService : ICustomerService
    {

        public FileStreamResult CreateCustomerClient(Customer customer)
        {
            var serializedObject = JsonConvert.SerializeObject(customer, new JsonSerializerSettings());
            var buffer = Encoding.UTF8.GetBytes(serializedObject);
            var stream = new MemoryStream(buffer);
            var result = new FileStreamResult(stream, "application/octet-stream");
            result.FileDownloadName = $"{customer.FristName}_{customer.LastName}";
            return result;
        }

        public string CreateCustomerServer(Customer customer, string path)
        {
            var serializedObject = JsonConvert.SerializeObject(customer, new JsonSerializerSettings());
            var fullPath = path + $"{customer.FristName}_{customer.LastName}.json";
            var jsonPath = "\\JsonFiles\\" + $"{customer.FristName}_{customer.LastName}.json";
            if (File.Exists(fullPath))
                File.Delete(fullPath);

            using (var stream = new StreamWriter(fullPath, true))
            {
                stream.WriteLine(serializedObject);
                stream.Close();
            }
            return jsonPath;
        }
    }
}
