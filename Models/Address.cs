using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FLoan.System.Web.API.Models
{
    public class Address
    {
        public Address()
        {
            this.DateTimeCreated = DateTime.Now;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AddressId { get; set; }
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
