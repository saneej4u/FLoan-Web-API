using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FLoan.System.Web.API.Models;

namespace FLoan.System.Web.API.Data
{
    public interface ITransactionRepository
    {
        Task<Transaction> GetSingle(int transactionId);

        Task<List<Transaction>> GetAll();

        Task<Transaction> Create(Transaction transaction);
    }
}
