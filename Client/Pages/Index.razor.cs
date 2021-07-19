using Customers.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Runtime.InteropServices.ComTypes;
using System.Text.Json.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Customers.Client.Pages
{
    public partial class Index : ComponentBase
    {
        public Customer customer = new Customer();


        public async Task HandleValidSubmit()
        {
            var serializedCustomer = await Http.PostAsJsonAsync<Customer>("/api/Customers/CreateCustomer", customer);
            var serializedObject = JsonConvert.SerializeObject(customer, new JsonSerializerSettings());
            byte[] bytes = Encoding.UTF8.GetBytes(serializedObject);
            await jSRuntime.InvokeAsync<object>(
            "saveAsFile",
            Guid.NewGuid().ToString()+".json",
            Convert.ToBase64String(bytes));
        }
    }
}
