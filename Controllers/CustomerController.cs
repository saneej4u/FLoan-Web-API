using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FLoan.System.Web.API.Data;
using FLoan.System.Web.API.DTO;
using FLoan.System.Web.API.Dtos;
using FLoan.System.Web.API.Models;
using Microsoft.AspNetCore.Http;
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
        public async Task<ActionResult<List<CustomerDto>>> Get()
        {
            var customersFromRepo = await this._customerRepo.GetAll();

            var customerDtos = _mapper.Map<List<CustomerDto>>(customersFromRepo);

            return Ok(customerDtos);

        }


        [HttpGet("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CustomerDto>> GetById(int Id)
        {
            var customerFromRepo = await this._customerRepo.GetSingle(Id);

            if (customerFromRepo == null)
            {
                return NotFound();
            }

            var model = _mapper.Map<CustomerDto>(customerFromRepo);

            return Ok(model);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CustomerDto>> Post([FromBody] CustomerForCreationDto customerForCreationDto)
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


            Customer model = await _customerRepo.Create(customer);

            var customerDto = _mapper.Map<CustomerDto>(model);

            return CreatedAtAction(nameof(GetById), new { id = customerDto.Id }, customerDto);

        }


        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
