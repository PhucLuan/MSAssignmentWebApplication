using Business.Interface;
using DataAccessor.Model;
using Microsoft.EntityFrameworkCore;

namespace Business.Service
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _baseRepository;

        public ProductService(IRepository<Product> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public async Task<Product> AddAsync(Product product)
        {
            var item = await _baseRepository.AddAsync(product);
            return item;
        }

        public async Task<IEnumerable<Product>> GetAllAsync(long? shopid, string? productname)
        {
            var queryResult = _baseRepository.Entities.AsQueryable();//.OrderByDescending(x => x.ProductId);

            if (shopid != null)
            {
                queryResult = queryResult.Where(x => x.ShopId == shopid);
            }

            if (!String.IsNullOrEmpty(productname))
            {
                queryResult = queryResult.Where(x => x.Name!.Contains(productname));
            }
            return await queryResult.OrderByDescending(x => x.ProductId).ToListAsync();
        }
    }
}
