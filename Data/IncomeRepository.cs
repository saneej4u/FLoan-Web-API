using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FLoan.System.Web.API.Models;

namespace FLoan.System.Web.API.Data
{
    public class IncomeRepository :IIncomeRepository
    {
        public IncomeRepository()
        {
        }

        public Task<Income> Create(Income income)
        {
            throw new NotImplementedException();
        }

        public Task<List<Income>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Income> GetSingle(int incomeId)
        {
            throw new NotImplementedException();
        }
    }
}
