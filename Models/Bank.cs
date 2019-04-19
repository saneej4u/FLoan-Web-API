using System;
namespace FLoan.System.Web.API.Models
{
    public class Bank
    {
        public Bank()
        {

            this.DateTimeCreated = DateTime.Now;
        }
        public int BankId { get; set; }
        public string AccountHolderName { get; set; }
        public string Sortcode { get; set; }
        public string AccountNumber { get; set; }
        public DateTime DateTimeCreated { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
