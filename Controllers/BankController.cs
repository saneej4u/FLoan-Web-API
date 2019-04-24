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
    [Route("api/[controller]")]
    public class BankController : Controller
    {

        private readonly IBankRepository _bankRepo;
        private readonly ICustomerRepository _customerRepo;

        public BankController(IBankRepository repo, ICustomerRepository customerRepo)
        {
            this._bankRepo = repo;
            this._customerRepo = customerRepo;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var banks = await this._bankRepo.GetAll();

            var bankDto = new List<BankForDisplayDto>();


            foreach (var bank in banks)
            {
                var bDto = new BankForDisplayDto()
                {
                    BankId = bank.BankId,
                     AccountHolderName = bank.AccountHolderName,
                     AccountNumber = bank.AccountNumber,
                     Customer = bank.Customer,
                     DateTimeCreated = bank.DateTimeCreated,
                     Sortcode= bank.Sortcode


                };

                bankDto.Add(bDto);
            }

            return Ok(bankDto);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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
