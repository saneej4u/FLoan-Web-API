using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FLoan.System.Web.API.Models
{
    public class Customer
    {
        public Customer()
        {
            this.DateTimeCreated = DateTime.Now;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Telephone { get; set; }
        public DateTime DateTimeCreated { get; set; }

        public ICollection<Address> Addresses { get; set; }
        public ICollection<Bank> Banks { get; set; }
        public ICollection<Income> Incomes { get; set; }
        public ICollection<Agreement> Agreements { get; set; }
    }
}
