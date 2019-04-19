using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FLoan.System.Web.API.Data;
using FLoan.System.Web.API.Dtos;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FLoan.System.Web.API.Controllers
{
    [Route("api/address")]
    public class AddressController : Controller
    {

        private readonly IAddressRepository _addressRepo;

        public AddressController(IAddressRepository repo)
        {
            this._addressRepo = repo;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var addresses = await this._addressRepo.GetAll();

            var addressesDto = new List<AddressForDisplayDto>();

            foreach (var address in addresses)
            {

                var addressDto = new AddressForDisplayDto()
                {
                    AddressId = address.AddressId,
                    AddressLine1 = address.AddressLine1,
                    AddressLine2 = address.AddressLine2,
                    Postcode = address.Postcode,
                    Street = address.Street,
                    Customer= address.Customer

                };

                addressesDto.Add(addressDto);
            }

            return Ok(addressesDto);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int Id)
        {
            var address = await this._addressRepo.GetSingle(Id);

            if (address == null)
            {
                return NotFound();
            }

            var model = new AddressForDisplayDto()
            {
                AddressId = address.AddressId,
                AddressLine1 = address.AddressLine1,
                AddressLine2 = address.AddressLine2,
                Street = address.Street,
                Town = address.Town,
                Postcode = address.Postcode,
                Customer = address.Customer,
                DateTimeCreated = address.DateTimeCreated

            };

            return Ok(address);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
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
