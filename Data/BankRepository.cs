using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FLoan.System.Web.API.Models;

namespace FLoan.System.Web.API.Data
{
    public class BankRepository :IBankRepository
    {
        public BankRepository()
        {
        }

        public Task<Address> Create(Bank bank)
        {
            throw new NotImplementedException();
        }

        public Task<List<Bank>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Bank> GetSingle(int bankId)
        {
            throw new NotImplementedException();
        }
    }
}
