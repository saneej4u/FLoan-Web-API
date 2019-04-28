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
    [Route("api/agreements")]
    public class AgreementController : Controller
    {

        private readonly IAgreementRepository _agreementRepo;
        private readonly ICustomerRepository _customerRepo;
        private readonly IMapper _mapper;

        public AgreementController(IAgreementRepository repo, ICustomerRepository customerRepo, IMapper mapper)
        {
            this._agreementRepo = repo;
            this._customerRepo = customerRepo;
            this._mapper = mapper;
        }


        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]AgreementForCreationDto agreementForCreationDto)
        {
            if (await this._customerRepo.GetSingle(agreementForCreationDto.CustomerId) == null)
            {
                return BadRequest();
            }

            var agreement = new Agreement
            {
                IsLoanActivated = agreementForCreationDto.IsLoanActivated,
                LoanAdvance = agreementForCreationDto.LoanAdvance,
                LoanAmount = agreementForCreationDto.LoanAmount,
                LoanBalance = agreementForCreationDto.LoanBalance,
                LoanStartDate = agreementForCreationDto.LoanStartDate,
                LoanTerm = agreementForCreationDto.LoanTerm,
                NextPaymentDate = agreementForCreationDto.NextPaymentDate,
                PinNumber = agreementForCreationDto.PinNumber,
                Status = agreementForCreationDto.Status,
                CustomerId = agreementForCreationDto.CustomerId

            };

            var agreementFromRep = await _agreementRepo.Create(agreement);

            var agreementDto = _mapper.Map<AgreementForCreationDto>(agreement);

            return Ok(agreementDto);
        }

        [HttpPost("{Id}/apply")]
        public async Task<IActionResult> ApplyAgreement(int Id, [FromBody]ActivateAgreementDto activateAgreementDto)
        {
            var agreementFromRepo = await this._agreementRepo.GetSingle(Id);

            if (agreementFromRepo == null)
            {
                return BadRequest();
            }

            if (await this._customerRepo.GetSingle(activateAgreementDto.CustomerId) == null)
            {
                return BadRequest();
            }

            agreementFromRepo.Status = 2;
            agreementFromRepo.IsLoanActivated = false;

            await _agreementRepo.Update(agreementFromRepo);

            var agreementDto = _mapper.Map<AgreementForCreationDto>(agreementFromRepo);

            return Ok(agreementDto);
        }

        [HttpPost("{Id}/activate")]
        public async Task<IActionResult> ActivateAgreement(int Id, [FromBody]ActivateAgreementDto activateAgreementDto)
        {
            var agreementFromRepo = await this._agreementRepo.GetSingle(Id);

            if (agreementFromRepo == null)
            {
                return BadRequest();
            }

            if (await this._customerRepo.GetSingle(activateAgreementDto.CustomerId) == null)
            {
                return BadRequest();
            }

            agreementFromRepo.Status = 3;
            agreementFromRepo.IsLoanActivated = true;

            await _agreementRepo.Update(agreementFromRepo);

            var agreementDto = _mapper.Map<AgreementForCreationDto>(agreementFromRepo);

            return Ok(agreementDto);
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
