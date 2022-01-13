using APICustomer.API.Enums;
using APICustomer.API.ErorrMessages;
using APICustomer.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICustomer.API.Services
{
    public interface IProductService
    {
        Task<ProductMessages> AddPrroduct(Product model);
    }
    public class ProductService : IProductService
    {
        private readonly APICustomerContext _db;

        public ProductService(APICustomerContext db)
        {
            _db = db;
        }

        public async Task<ProductMessages> AddPrroduct(Product model)
        {
            var productExits = _db.Products.Any(x => x.Serial == model.Serial && x.Model == model.Model);
            if (productExits)
            {
                return new ProductMessages
                {
                    Code = (int)ProductError.SerialDuplicate,
                    Message = "Serial bị trùng"
                };
            }
            _db.Products.Add(model);
            await _db.SaveChangesAsync();
            return new ProductMessages
            {
                Code = (int)ProductError.Success,
                Message = "Success"
            };
        }
    }
}
