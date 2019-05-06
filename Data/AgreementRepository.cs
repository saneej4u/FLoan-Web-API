using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FLoan.System.Web.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FLoan.System.Web.API.Data
{
    public class AgreementRepository : IAgreementRepository
    {

        private readonly DataContext _context;

        public AgreementRepository(DataContext context)
        {
            this._context = context;
        }

        public async Task<Agreement> Create(Agreement agreement)
        {
            var agreementAfterCalculation = CalculateRepayment(agreement);

            await this._context.Agreements.AddAsync(agreementAfterCalculation);
            await this._context.SaveChangesAsync();

            return agreementAfterCalculation;
        }

        public async Task<Agreement> Update(Agreement agreement)
        {
            this._context.Agreements.Update(agreement);
            await this._context.SaveChangesAsync();

            return agreement;
        }

        public async Task<List<Agreement>> GetAll()
        {
            return await this._context.Agreements.ToListAsync(); ;
        }

        public async Task<Agreement> GetSingle(int agreementId)
        {
            return await this._context.Agreements.FirstOrDefaultAsync(x => x.AgreementId == agreementId);
        }

        public Task<bool> IsAgreementExist(int agreementId)
        {
            throw new NotImplementedException();
        }

        private Agreement CalculateRepayment(Agreement agreement)
        {
            decimal loanTerm = agreement.LoanTerm;
            var loanAMount = agreement.LoanTerm;

            decimal adminFee = (loanAMount * 5) / 100;

            decimal totalLmount = (loanAMount + adminFee);

            decimal totalToRepay = Math.Round(Convert.ToDecimal(((loanTerm * loanAMount) / 100) + totalLmount), 2);
            decimal monthlyRepayment = Math.Round(totalToRepay / Convert.ToInt16(loanTerm), 2);

            decimal interest = totalToRepay - Convert.ToDecimal(loanAMount);

            agreement.TotalRepayable = totalToRepay;
            agreement.MonthlyRepayment = monthlyRepayment;
            agreement.InterestPayable = interest; ;
            agreement.AdminFeePayable = adminFee; ;

            return agreement;

        }
    }
}
