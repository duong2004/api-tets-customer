using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APICustomer.API.Models;
using Microsoft.EntityFrameworkCore;

namespace APICustomer.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetCustomers();
    }
    public class CustomerService : ICustomerService
    {
        private readonly APICustomerContext _db;

        public CustomerService(APICustomerContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            var customers = await _db.Customers.ToListAsync();
            return customers;
        }
    }
}
