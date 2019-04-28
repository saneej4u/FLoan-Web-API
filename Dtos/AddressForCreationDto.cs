﻿using System;
using FLoan.System.Web.API.Models;

namespace FLoan.System.Web.API.Dtos
{
    public class AddressForCreationDto
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Street { get; set; }
        public string Town { get; set; }
        public string Postcode { get; set; }
        public DateTime DateTimeCreated { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
