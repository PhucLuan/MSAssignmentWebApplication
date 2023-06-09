using Business.Interface;
using DataAccessor.Model;
using Microsoft.AspNetCore.Mvc;

namespace MSAssignmentWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopsController : ControllerBase
    {
        private readonly IShopService _shopService;
        public ShopsController(IShopService shopService)
        {
            _shopService = shopService;
        }

        // GET: api/Shops
        [HttpGet]
        public async Task<IEnumerable<Shop>> GetShops()
        {
            var result = await _shopService.GetAllAsync();
            return result;
        }

        // GET: api/GetShopName
        //[Route("GetShopName")]
        [HttpGet("GetShopName/{id}")]
        public async Task<ActionResult<string>> GetShopName(long id)
        {
            var shopName = await _shopService.GetShopName(id);

            if (String.IsNullOrEmpty(shopName))
            {
                return NotFound();
            }

            return shopName;
        }


        // POST: api/Shops
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Shop>> PostShop(Shop shop)
        {
            var result = await _shopService.AddAsync(shop);
            return result;
        }
    }
}
