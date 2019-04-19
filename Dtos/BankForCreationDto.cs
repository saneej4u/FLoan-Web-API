using System;
namespace FLoan.System.Web.API.Dtos
{
    public class BankForCreationDto
    {
        public BankForCreationDto()
        {
        }

        public string AccountHolderName { get; set; }
        public string Sortcode { get; set; }
        public string AccountNumber { get; set; }
        public DateTime DateTimeCreated { get; set; }

        public int CustomerId { get; set; }

    }
}
