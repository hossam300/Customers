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
            // Request Api to get json file in order to download it 
            using (var response = await Http.PostAsJsonAsync("/api/Customers/CreateCustomerClient", customer))
            {
                // read response as byte 
                var data = await response.Content.ReadAsByteArrayAsync();
                // Download file use's "site.js" on wwwroot excute saveAsFile and pass file to download it 
                await jSRuntime.InvokeAsync<object>(
                "saveAsFile",
                $"{customer.FristName}_{customer.LastName}" + ".json",
                Convert.ToBase64String(data));
            }
        }
    }
}
