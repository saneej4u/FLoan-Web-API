using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FLoan.System.Web.API.Models;

namespace FLoan.System.Web.API.Data
{
    public class AddressRepository : IAddressRepository
    {
        public AddressRepository() 
        {
        }

        public Task<Address> Create(Address address)
        {
            throw new NotImplementedException();
        }

        public Task<List<Address>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Address> GetSingle(int addressId)
        {
            throw new NotImplementedException();
        }
    }
}
