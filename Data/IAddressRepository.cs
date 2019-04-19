using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FLoan.System.Web.API.Models;

namespace FLoan.System.Web.API.Data
{
    public interface IAddressRepository
    {
        Task<Address> GetSingle(int addressId);

        Task<List<Address>> GetAll();

        Task<Address> Create(Address address);

    }
}
