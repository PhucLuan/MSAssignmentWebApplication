using Business.Interface;
using Contract.DTOs;
using DataAccessor.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IRepository<Shop> _shopRepository;
        private readonly IRepository<Customer> _customerRepository;
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Purchase> _purchaseRepository;
        public PurchaseService(IRepository<Shop> shopRepository, IRepository<Customer> customerRepository, IRepository<Product> productRepository, IRepository<Purchase> purchaseRepository)
        {
            _shopRepository = shopRepository;
            _customerRepository = customerRepository;
            _productRepository = productRepository;
            _purchaseRepository = purchaseRepository;
        }
        public enum LowerLimit
        {
            shopCount = 3,
            customerCount = 30,
            productCount = 3000,
        }

        public async Task<IEnumerable<PurchaseDTO>> GetPurchasesData(string? productName)
        {
            var shopCount = await _shopRepository.Entities.AsNoTracking().CountAsync();
            if (shopCount < (int)LowerLimit.shopCount)
            {
                throw new ArgumentException("Insufficient Data");
            }

            var customerCount = await _customerRepository.Entities.AsNoTracking().CountAsync();
            if (customerCount < (int)LowerLimit.customerCount)
            {
                throw new ArgumentException("Insufficient Data");
            }

            var productCount = await _productRepository.Entities.AsNoTracking().CountAsync();
            if (productCount < (int)LowerLimit.productCount)
            {
                throw new ArgumentException("Insufficient Data");
            }

            var query = from c in _customerRepository.Entities
                        join pu in _purchaseRepository.Entities on c.CustomerId equals pu.CustomerId
                        join p in _productRepository.Entities on pu.ProductId equals p.ProductId
                        join s in _shopRepository.Entities on p.ShopId equals s.ShopId
                        where string.IsNullOrEmpty(productName) || p.Name!.Contains(productName)
                        orderby c.Email ascending, s.Location descending, p.Price descending
                        select new PurchaseDTO
                        {
                            Customer = c.FullName + " - " + c.Email,
                            Shop = s.Name + " - " + s.Location,
                            Product = p.Name + " - " + p.Price.ToString()
                        };

            var results = await query.ToListAsync();
            return results;
        }
    }
}
