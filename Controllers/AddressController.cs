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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FLoan.System.Web.API.Controllers
{
    [Route("api/address")]
    public class AddressController : Controller
    {

        private readonly IAddressRepository _addressRepo;
        private readonly ICustomerRepository _customerRepo;
        private readonly IMapper _mapper;

        public AddressController(IAddressRepository repo, ICustomerRepository customerRepo, IMapper mapper)
        {
            this._addressRepo = repo;
            this._customerRepo = customerRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var addresses = await this._addressRepo.GetAll();

            var addressesDto = _mapper.Map<List<AddressDto>>(addresses);

            return Ok(addressesDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int Id)
        {
            var address = await this._addressRepo.GetSingle(Id);

            if (address == null)
            {
                return NotFound();
            }

            var addressDto = _mapper.Map<AddressDto>(address);

            return Ok(addressDto);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddressForCreationDto addressForCreationDto)
        {
            if (await this._customerRepo.GetSingle(addressForCreationDto.CustomerId) == null)
            {
                return BadRequest();
            }

            var address = new Address
            {
                AddressLine1 = addressForCreationDto.AddressLine1,
                AddressLine2 = addressForCreationDto.AddressLine2,
                Street = addressForCreationDto.Street,
                Town = addressForCreationDto.Town,
                Postcode = addressForCreationDto.Postcode,
                CustomerId = addressForCreationDto.CustomerId

            };

            await _addressRepo.Create(address);

            return Ok(addressForCreationDto);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
