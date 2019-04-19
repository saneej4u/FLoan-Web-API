using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FLoan.System.Web.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FLoan.System.Web.API.Data
{
    public class AddressRepository : IAddressRepository
    {
        private readonly DataContext _context;

        public AddressRepository(DataContext context)
        {
            this._context = context;
        }


        public async Task<Address> Create(Address address)
        {
            await this._context.Addresses.AddAsync(address);
            await this._context.SaveChangesAsync();

            return address;
        }

        public async Task<List<Address>> GetAll()
        {
            return await this._context.Addresses.ToListAsync();
        }

        public async Task<Address> GetSingle(int addressId)
        {
            return await this._context.Addresses.FirstOrDefaultAsync(x => x.AddressId == addressId);
        }
    }
}
