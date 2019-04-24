using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FLoan.System.Web.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FLoan.System.Web.API.Data
{
    public class IncomeRepository :IIncomeRepository
    {

        private readonly DataContext _context;

        public IncomeRepository(DataContext context)
        {
            this._context = context;
        }


        public async Task<Income> Create(Income income)
        {
            await this._context.Incomes.AddAsync(income);
            await this._context.SaveChangesAsync();

            return income;
        }

        public async Task<List<Income>> GetAll()
        {
            return await this._context.Incomes.ToListAsync();
        }

        public async Task<Income> GetSingle(int incomeId)
        {
            return await this._context.Incomes.FirstOrDefaultAsync(x => x.IncomeId == incomeId);
        }
    }
}
