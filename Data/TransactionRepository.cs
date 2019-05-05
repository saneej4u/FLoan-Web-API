using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FLoan.System.Web.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FLoan.System.Web.API.Data
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly DataContext _context;

        public TransactionRepository(DataContext context)
        {
            this._context = context;
        }


        public async Task<Transaction> Create(Transaction transaction)
        {

            var transactionFromRepo = await GetAll();
            decimal currentBalance = 0M;

            if (transactionFromRepo != null)
            {
                var tr = transactionFromRepo.Where(x => x.AgreementId == transaction.AgreementId).OrderByDescending(x => x.DateTimeCreated).FirstOrDefault();

                if (transaction != null)
                {
                    currentBalance = transaction.CurrentBalance;
                }
            }

            transaction.CurrentBalance = currentBalance + transaction.AmountPaid;


            await this._context.Transactions.AddAsync(transaction);
            await this._context.SaveChangesAsync();

            return transaction;
        }

        public async Task<List<Transaction>> GetAll()
        {
            return await this._context.Transactions.ToListAsync();
        }

        public async Task<Transaction> GetSingle(int transactionId)
        {
            return await this._context.Transactions.FirstOrDefaultAsync(x => x.TransactionId == transactionId);
        }
    }
}
