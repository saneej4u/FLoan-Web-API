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
            await this._context.Agreements.AddAsync(agreement);
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
    }
}
