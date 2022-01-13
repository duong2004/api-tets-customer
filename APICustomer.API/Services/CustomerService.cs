using APICustomer.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static APICustomer.API.ModelViews.CustomerModelViews;

namespace APICustomer.API.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetCustomers();
        Task<Customer> AddCustomer(Customer model);
        Task<Customer> GetCustomerById(int id);
    }
    public class CustomerService : ICustomerService
    {
        private readonly APICustomerContext _db;


        public CustomerService(APICustomerContext db)
        {
            _db = db;
        }

        public async Task<Customer> AddCustomer(Customer model)
        {
            _db.Customers.Add(model);
            await _db.SaveChangesAsync();
            return model;
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            var customer = await _db.Customers.FindAsync(id);
            return customer;
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            var customers = await _db.Customers.OrderByDescending(x => x.CreatedDate).ToListAsync();
            return customers;
        }
    }
}
