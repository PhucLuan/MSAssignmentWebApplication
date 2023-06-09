using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    /// <summary>
    /// The Repository interface.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public interface IRepository<T> : IDisposable
        where T : class
    {
        IQueryable<T> Entities { get; }
        Task<T> AddAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync();
    }
}
