using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public CustomerController(ICustomerRepository repo, IMapper mapper)
        {
            this._customerRepo = repo;
            this._mapper = mapper;
        }


        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            var customersFromRepo = await this._customerRepo.GetAll();

            var customerDtos = new List<CustomerDto>();

            foreach (Customer customer in customersFromRepo)
            {

                var customerDto = _mapper.Map<CustomerDto>(customer);

                customerDtos.Add(customerDto);
            }

            return Ok(customerDtos);

        }


        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            var customer = await this._customerRepo.GetSingle(Id);

            if (customer == null)
            {
                return NotFound();
            }

            var model = _mapper.Map<CustomerDto>(customer);

            return Ok(model);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CustomerForCreationDto customerForCreationDto)
        {
            if (await this._customerRepo.IsCustomerExist(customerForCreationDto.Email))
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

            // var customer = _mapper.Map<Customer>(customerForCreationDto);

            Customer model = await _customerRepo.Create(customer);

            return Ok(customerForCreationDto);
        }


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
