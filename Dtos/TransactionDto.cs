using System;
namespace FLoan.System.Web.API.Dtos
{
    public class TransactionDto
    {
        public int TransactionId { get; set; }
        public decimal CurrentBalance { get; set; }
        public decimal AmountPaid { get; set; }
        public DateTime DateTimeCreated { get; set; }

        public int AgreementId { get; set; }

    }
}
