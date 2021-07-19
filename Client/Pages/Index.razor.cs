using Customers.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Net.Http.Json;
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
            using (var response = await Http.PostAsJsonAsync<Customer>("/api/Customers/CreateCustomer", customer))
            {
                var data = await response.Content.ReadFromJsonAsync<Customer>();
                var serializedObject = JsonConvert.SerializeObject(data, new JsonSerializerSettings());
                byte[] bytes = Encoding.UTF8.GetBytes(serializedObject);
                await jSRuntime.InvokeAsync<object>(
                "saveAsFile",
                $"{customer.FristName}_{customer.LastName}" + ".json",
                Convert.ToBase64String(bytes));
            }
        }
    }
}
