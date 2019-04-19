using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FLoan.System.Web.API.Models;

namespace FLoan.System.Web.API.Data
{
    public interface ICustomerRepository
    {
        Task<Customer> GetSingle(int customerId);

        Task<Customer> GetCustomerByEmail(string email);
        Task<List<Customer>> GetAll();

        Task<Customer> Create(Customer customer);

        Task<bool> IsCustomerExist(string email);
    }

}
