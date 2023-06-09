using DataAccessor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface IShopService
    {
        Task<IEnumerable<Shop>> GetAllAsync();
        Task<Shop> AddAsync(Shop shop);
        Task<string> GetShopName(long id);
    }
}
