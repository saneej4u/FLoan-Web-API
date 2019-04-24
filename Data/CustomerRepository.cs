using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FLoan.System.Web.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FLoan.System.Web.API.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _context;

        public CustomerRepository( DataContext context)
        {
            this._context = context;
        }

        public async Task<List<Customer>> GetAll()
        {
          return  await this._context.Customers.Include(x=>x.Addresses) .ToListAsync();
        }

        public async Task<Customer> GetSingle(int customerId)
        {
           return  await this._context.Customers.FirstOrDefaultAsync(x => x.Id == customerId);
        }

        public async Task<Customer> GetCustomerByEmail(string email)
        {
            return await this._context.Customers.FirstOrDefaultAsync(x => x.Email.Equals(email));
        }

        public async Task<Customer> Create(Customer customer)
        {
            await this._context.Customers.AddAsync(customer);
            await this._context.SaveChangesAsync();

            return customer;
        }

        public async Task<bool> IsCustomerExist(string email)
        {

            var customer = await GetCustomerByEmail(email);

            return customer !=null ? true : false;
        }
    }
}
