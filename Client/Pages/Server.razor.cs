using Customers.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Customers.Client.Pages
{
    public partial class Server : ComponentBase
    {
        public Customer customer = new Customer();
        public async Task HandleValidSubmit()
        {
            // Request Api to get json file in order to download it 
            using (var response = await Http.PostAsJsonAsync("/api/Customers/CreateCustomerServer", customer))
            {
                // read response as byte 
                var data = await response.Content.ReadAsStringAsync();
                // Download file use's "site.js" on wwwroot excute saveAsFile and pass file to download it 

                await jSRuntime.InvokeAsync<object>(
                 "downloadFromUrl",
                 data, 
                 $"{customer.FristName}_{customer.LastName}" + ".json");
            }
          
        }
    }
}
