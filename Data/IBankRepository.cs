using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FLoan.System.Web.API.Models;

namespace FLoan.System.Web.API.Data
{
    public interface IBankRepository
    {

        Task<Bank> GetSingle(int bankId);

        Task<List<Bank>> GetAll();

        Task<Bank> Create(Bank bank);

    }
}
