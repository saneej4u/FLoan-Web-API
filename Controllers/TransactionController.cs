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
    [Route("api/transaction")]
    public class TransactionController : Controller
    {

        private readonly ITransactionRepository _transactionRepo;
        private readonly IAgreementRepository _agreementRepo;
        private readonly IMapper _mapper;

        public TransactionController(ITransactionRepository repo, IAgreementRepository agrRepo, IMapper mapper)
        {
            this._transactionRepo = repo;
            this._agreementRepo = agrRepo;
            this._mapper = mapper;
        }


        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody]TransactionForCreationDto transactionForCreationDto)
        {
            var agrFromRepo = await this._agreementRepo.GetSingle(transactionForCreationDto.AgreementId);

            if (agrFromRepo == null)
            {
                return BadRequest();
            }



            var tr = new Transaction
            {
                AgreementId = transactionForCreationDto.AgreementId,
                AmountPaid = transactionForCreationDto.AmountPaid

            };

            var result = await _transactionRepo.Create(tr);

            var incomeDto = _mapper.Map<TransactionDto>(tr);

            return Ok(incomeDto);
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
