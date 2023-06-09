using Business.Interface;
using DataAccessor.Model;
using Microsoft.EntityFrameworkCore;

namespace Business.Service
{
    public class ShopService : IShopService
    {
        private readonly IRepository<Shop> _baseRepository;

        public ShopService(IRepository<Shop> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public async Task<Shop> AddAsync(Shop shop)
        {
            var item = await _baseRepository.AddAsync(shop);
            return item;
        }

        public async Task<IEnumerable<Shop>> GetAllAsync()
        {
            var shops = await _baseRepository.Entities.OrderByDescending(x => x.ShopId).AsNoTracking().ToListAsync();
            return shops;
        }

        public async Task<string> GetShopName(long id)
        {
            var shop = await _baseRepository.Entities.FirstOrDefaultAsync(x => x.ShopId == id);
            return shop.Name;
        }
    }
}
