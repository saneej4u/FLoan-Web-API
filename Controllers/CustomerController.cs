using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FLoan.System.Web.API.Data;
using FLoan.System.Web.API.DTO;
using FLoan.System.Web.API.Dtos;
using FLoan.System.Web.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FLoan.System.Web.API.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepo;

        public CustomerController(ICustomerRepository repo)
        {
            this._customerRepo = repo;
        }

        // GET api/values
        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            var customers =  await this._customerRepo.GetAll();

            var customerDtos = new List<CustomerForDisplayDto>();

            foreach(var customer in customers)
            {

                var customerDto = new CustomerForDisplayDto()
                {
                    CustomerId = customer.Id,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    DateOfBirth = customer.DateOfBirth,
                    Email = customer.Email,
                    Mobile = customer.Mobile,
                    Telephone = customer.Telephone,
                    Title = customer.Title,
                    DateTimeCreated = customer.DateTimeCreated,
                    Addresses= customer.Addresses,
                    Agreements= customer.Agreements,
                    Banks= customer.Banks,
                    Incomes = customer.Incomes
                    
                    

                };

                customerDtos.Add(customerDto);
            }

            return Ok(customerDtos);

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int Id)
        {
            var customer = await this._customerRepo.GetSingle(Id);

            if(customer==null)
            {
                return NotFound();
            }

            var model = new CustomerForDisplayDto()
            {
                CustomerId = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                DateOfBirth = customer.DateOfBirth,
                Email = customer.Email,
                Mobile = customer.Mobile,
                Telephone = customer.Telephone,
                Title = customer.Title,
                DateTimeCreated = customer.DateTimeCreated

            };

            return Ok(customer);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CustomerForCreationDto customerForCreationDto)
        {
            if(await this._customerRepo.IsCustomerExist(customerForCreationDto.Email))
            {
                return BadRequest();
            }

            var customer = new Customer
            {
                FirstName = customerForCreationDto.FirstName,
                LastName = customerForCreationDto.LastName,
                DateOfBirth = customerForCreationDto.DateOfBirth,
                Email = customerForCreationDto.Email,
                Mobile = customerForCreationDto.Mobile,
                Telephone = customerForCreationDto.Telephone,
                Title = customerForCreationDto.Title


            };

           await _customerRepo.Create(customer);

            return Ok(customerForCreationDto);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
