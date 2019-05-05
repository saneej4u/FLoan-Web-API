using System;
namespace FLoan.System.Web.API.Dtos
{
    public class TransactionForCreationDto
    {
        public decimal AmountPaid { get; set; }
        public int AgreementId { get; set; }
    }
}
