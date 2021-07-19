﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Customers.Shared
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        public string FristName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        public bool Subscribed { get; set; }
        public DateTime dob { get; set; }
    }
}