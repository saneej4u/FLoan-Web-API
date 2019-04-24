using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FLoan.System.Web.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FLoan.System.Web.API.Data
{
    public class BankRepository :IBankRepository
    {

        private readonly DataContext _context;

        public BankRepository(DataContext context)
        {
            this._context = context;
        }



        public async Task<Bank> Create(Bank bank)
        {
            await this._context.Banks.AddAsync(bank);
            await this._context.SaveChangesAsync();

            return bank;
        }

        public async Task<List<Bank>> GetAll()
        {
            return await this._context.Banks.ToListAsync();
        }

        public async Task<Bank> GetSingle(int bankId)
        {
            return await this._context.Banks.FirstOrDefaultAsync(x => x.BankId == bankId);
        }
    }
}
