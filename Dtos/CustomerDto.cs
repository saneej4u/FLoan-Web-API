﻿using System;
using System.Collections.Generic;
using FLoan.System.Web.API.Models;

namespace FLoan.System.Web.API.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Telephone { get; set; }
        public List<AddressDto> Addresses { get; set; }
        public List<BankDto> Banks { get; set; }
        public List<IncomeDto> Incomes { get; set; }
        public List<AgreementDto> Agreements { get; set; }

    }
}
