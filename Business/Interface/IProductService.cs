using DataAccessor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllAsync(long? shopid, string? productname);
        Task<Product> AddAsync(Product product);
    }
}
