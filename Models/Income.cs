using System;
namespace FLoan.System.Web.API.Models
{
    public class Income
    {
        public Income()
        {
            this.DateTimeCreated = DateTime.Now;
        }

        public int IncomeId { get; set; }
        public decimal MonthlySalary { get; set; }
        public decimal OtherIncome { get; set; }

        public decimal MonthlyMortgageOrRent { get; set; }
        public decimal CreditBills { get; set; }
        public decimal HouseholdExpense { get; set; }

        public bool GiveMeLoan { get; set; }
        public DateTime DateTimeCreated { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
