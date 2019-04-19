using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FLoan.System.Web.API.Models;

namespace FLoan.System.Web.API.Data
{
    public interface IIncomeRepository
    {
        Task<Income> GetSingle(int incomeId);

        Task<List<Income>> GetAll();

        Task<Income> Create(Income income);

    }
}
