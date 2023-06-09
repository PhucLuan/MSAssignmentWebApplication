using Business.Interface;
using DataAccessor.Model;
using Microsoft.AspNetCore.Mvc;

namespace MSAssignmentWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<IEnumerable<Product>> GetProducts(long? shopid, string? productname)
        {
            var queryResult = await _productService.GetAllAsync(shopid, productname);

            return queryResult;
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            var result = await _productService.AddAsync(product);
            return result;
        }
    }
}
