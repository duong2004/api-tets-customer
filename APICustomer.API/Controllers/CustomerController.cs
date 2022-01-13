using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APICustomer.API.Models;
using APICustomer.API.Services;
using AutoMapper;
using static APICustomer.API.ModelViews.CustomerModelViews;
using APICustomer.API.ErorrMessages;

namespace APICustomer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var customers = await _customerService.GetCustomers();
                List<CustomerModelView> list = _mapper.Map<List<CustomerModelView>>(customers);
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(new CustomerMessage
                {
                    IsSuccess = false,
                    Message = ex.Message.ToString()
                });
            }

        }
        [HttpGet]
        [Route("GetCustomerById/{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            try
            {
                var customer = await _customerService.GetCustomerById(id);
                if (customer == null)
                {
                    return BadRequest(new CustomerReponse
                    {
                        IsSuccess = false,
                        Message = "Khách hàng không tồn tại."
                    });
                }
                CustomerModelView model = _mapper.Map<CustomerModelView>(customer);
                return Ok(new CustomerReponse
                {
                    IsSuccess = true,
                    Customer = model
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new CustomerReponse
                {
                    IsSuccess = false,
                    Message = ex.Message.ToString()
                });
            }
        }
        [HttpPost]
        [Route("AddCustomer")]
        public async Task<IActionResult> AddCustomer(AddCustomerModelView model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Customer customer = _mapper.Map<Customer>(model);
                    customer.CreatedDate = DateTime.Now;
                    var result = await _customerService.AddCustomer(customer);
                    return Ok(new CustomerReponse { 
                        IsSuccess = true,
                        Customer = _mapper.Map<CustomerModelView>(result)
                    });
                }
                return BadRequest(new CustomerMessage { 
                    IsSuccess = false,
                    Message = ModelState.ErrorCount.ToString()
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new CustomerMessage
                {
                    IsSuccess = false,
                    Message = ex.Message.ToString()
                });
            }
        }
    }
}
