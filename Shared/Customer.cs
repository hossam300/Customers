using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Customers.Shared
{
    public class Customer
    {
        [Required]
        [JsonProperty(PropertyName = "firstName")]
        public string FristName { get; set; }
        [Required]
        [JsonProperty(PropertyName = "last_name")]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        [JsonProperty(PropertyName = "emailAddress")]
        public string EmailAddress { get; set; }
        [JsonProperty(PropertyName = "subscribed")]
        public bool Subscribed { get; set; }
        [JsonProperty(PropertyName = "dob")]
        public DateTime Dob { get; set; }
    }
}
