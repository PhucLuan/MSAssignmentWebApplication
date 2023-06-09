using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MSAssignmentWebApplication.Models;
using System.ComponentModel.DataAnnotations;

namespace MSAssignmentWebApplication.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly EcomStepMediaContext _context;
        public PurchaseController(EcomStepMediaContext context)
        {
            _context = context;
        }
        [Route("GetPurchasesData")]
        [HttpGet]
        public async Task<ActionResult> GetPurchasesData(string? productName)
        {
            var shopCount = await _context.Shops.AsNoTracking().CountAsync();
            if (shopCount < 3)
            {
                return BadRequest("Insufficient Data");
            }

            var customerCount = await _context.Customers.AsNoTracking().CountAsync();
            if (customerCount < 30)
            {
                return BadRequest("Insufficient Data");
            }

            var productCount = await _context.Products.AsNoTracking().CountAsync();
            if (productCount < 3000)
            {
                return BadRequest("Insufficient Data");
            }

            var query = from c in _context.Customers
                        join pu in _context.Purchases on c.CustomerId equals pu.CustomerId
                        join p in _context.Products on pu.ProductId equals p.ProductId
                        join s in _context.Shops on p.ShopId equals s.ShopId
                        where string.IsNullOrEmpty(productName) || p.Name!.Contains(productName)
                        orderby c.Email ascending, s.Location descending, p.Price descending
                        select new
                        {
                            Customer = c.FullName + " - " + c.Email,
                            Shop = s.Name + " - " + s.Location,
                            Product = p.Name + " - " + p.Price.ToString()
                        };

            var results = await query.ToListAsync();

            return Ok(results);
        }
    }
}
