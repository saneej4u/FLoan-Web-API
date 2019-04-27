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
    [Route("api/[controller]")]
    public class IncomeController : Controller
    {

        private readonly IIncomeRepository _incomeRepo;
        private readonly ICustomerRepository _customerRepo;
        private readonly IMapper _mapper;

        public IncomeController(IIncomeRepository repo, ICustomerRepository customerRepo, IMapper mapper)
        {
            this._incomeRepo = repo;
            this._customerRepo = customerRepo;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var income = await this._incomeRepo.GetAll();

            var incomeDto = _mapper.Map<List<IncomeDto>>(income);

            return Ok(incomeDto);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var income = await this._incomeRepo.GetSingle(id);

            if (income == null)
            {
                return NotFound();
            }

            var incomeDto = _mapper.Map<IncomeDto>(income);

            return Ok(incomeDto);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody]IncomeForCreationDto incomeForCreationDto)
        {
            if (await this._customerRepo.GetSingle(incomeForCreationDto.CustomerId) == null)
            {
                return BadRequest();
            }

            var income = new Income
            {
                CreditBills = incomeForCreationDto.CreditBills,
                GiveMeLoan = incomeForCreationDto.GiveMeLoan,
                HouseholdExpense = incomeForCreationDto.HouseholdExpense,
                MonthlyMortgageOrRent = incomeForCreationDto.MonthlyMortgageOrRent,
                CustomerId = incomeForCreationDto.CustomerId,
                MonthlySalary = incomeForCreationDto.MonthlySalary,
                OtherIncome = incomeForCreationDto.OtherIncome

            };

            var result = await _incomeRepo.Create(income);

            var incomeDto = _mapper.Map<IncomeDto>(income);

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
