using System;
namespace FLoan.System.Web.API.Dtos
{
    public class AgreementForCreationDto
    {
        public int CustomerId { get; set; }
        public decimal LoanAmount { get; set; }
        public int LoanTerm { get; set; }

    }
}
