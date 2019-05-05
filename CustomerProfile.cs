using System;
using AutoMapper;
using FLoan.System.Web.API.Dtos;
using FLoan.System.Web.API.Models;

namespace FLoan.System.Web.API
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Agreement, AgreementDto>().ReverseMap();
        }
    }
}
