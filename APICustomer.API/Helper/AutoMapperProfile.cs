using APICustomer.API.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static APICustomer.API.ModelViews.CustomerModelViews;

namespace APICustomer.API.Helper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AddCustomerModelView, Customer>();
            CreateMap<Customer, CustomerModelView>();
            CreateMap<CustomerModelView, Customer>();
        }
    }
}
