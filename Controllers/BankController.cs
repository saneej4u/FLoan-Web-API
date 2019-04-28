using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FLoan.System.Web.API.Data;
using FLoan.System.Web.API.Dtos;
using FLoan.System.Web.API.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FLoan.System.Web.API.Controllers
{
    [Route("api/banks")]
    public class BankController : Controller
    {

        private readonly IBankRepository _bankRepo;
        private readonly ICustomerRepository _customerRepo;
        private readonly IMapper _mapper;

        public BankController(IBankRepository repo, ICustomerRepository customerRepo, IMapper mapper)
        {
            this._bankRepo = repo;
            this._customerRepo = customerRepo;
            this._mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<List<BankDto>>> Get()
        {
            var banks = await this._bankRepo.GetAll();

            var bankDto = _mapper.Map<List<BankDto>>(banks);

            return Ok(bankDto);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Bank>> Get(int id)
        {
            var bank = await this._bankRepo.GetSingle(id);

            if (bank == null)
            {
                return NotFound();
            }

            var bankDto = _mapper.Map<BankDto>(bank);

            return Ok(bankDto);
        }


        [HttpPost]
        public async Task<ActionResult<BankDto>> Post([FromBody]BankForCreationDto bankForCreationDto)
        {
            if (await this._customerRepo.GetSingle(bankForCreationDto.CustomerId) == null)
            {
                return BadRequest();
            }

            var bank = new Bank
            {
                AccountNumber = bankForCreationDto.AccountNumber,
                AccountHolderName = bankForCreationDto.AccountHolderName,
                Sortcode = bankForCreationDto.Sortcode,
                CustomerId = bankForCreationDto.CustomerId

            };

            var bankForRep = await _bankRepo.Create(bank);

            var bankDto = _mapper.Map<BankDto>(bank);

            return Ok(bankDto);
        }


        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
