using System;
using System.Collections.Generic;

namespace FLoan.System.Web.API.Models
{
    public class Agreement
    {
        public Agreement()
        {
            this.DateTimeCreated = DateTime.Now;
        }

        public int AgreementId { get; set; }

        public decimal LoanAmount { get; set; }
        public int LoanTerm { get; set; }
        public decimal LoanAdvance { get; set; }
        public decimal LoanBalance { get; set; }
        public DateTime LoanStartDate { get; set; }
        public DateTime NextPaymentDate { get; set; }
        public int Status { get; set; }
        public int PinNumber { get; set; }
        public DateTime DateTimeCreated { get; set; }


        public List<Transaction> Transactions { get; set; }
        public bool IsLoanActivated { get; set; }


        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
