using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FLoan.System.Web.API.Models
{
    public class Agreement
    {
        public Agreement()
        {
            this.DateTimeCreated = DateTime.Now;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        public decimal TotalRepayable { get; set; }
        public decimal MonthlyRepayment { get; set; }
        public decimal InterestPayable { get; set; }
        public decimal AdminFeePayable { get; set; }
        public decimal LeftToPay { get; set; }

        public List<Transaction> Transactions { get; set; }
        public bool IsLoanActivated { get; set; }


        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
