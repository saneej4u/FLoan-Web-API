using System;
namespace FLoan.System.Web.API.Dtos
{
    public class MakePaymentDto
    {
        public decimal AmountPaid { get; set; }
        public int CustomerId { get; set; }
    }
}
