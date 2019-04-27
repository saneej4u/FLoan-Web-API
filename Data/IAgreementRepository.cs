using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FLoan.System.Web.API.Models;

namespace FLoan.System.Web.API.Data
{
    public interface IAgreementRepository
    {
        Task<Agreement> GetSingle(int agreementId);

        Task<List<Agreement>> GetAll();

        Task<Agreement> Create(Agreement agreement);

        Task<bool> IsAgreementExist(int agreementId);

        Task<Agreement> Update(Agreement agreement);
    }

}
