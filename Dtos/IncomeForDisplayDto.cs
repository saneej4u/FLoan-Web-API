using System;
using FLoan.System.Web.API.Models;

namespace FLoan.System.Web.API.Dtos
{
    public class IncomeForDisplayDto
    {
        public IncomeForDisplayDto()
        {
        }

        public int IncomeId { get; set; }
        public decimal MonthlySalary { get; set; }
        public decimal OtherIncome { get; set; }

        public decimal MonthlyMortgageOrRent { get; set; }
        public decimal CreditBills { get; set; }
        public decimal HouseholdExpense { get; set; }

        public bool GiveMeLoan { get; set; }
        public DateTime DateTimeCreated { get; set; }

        public Customer Customer { get; set; }
    }
}
