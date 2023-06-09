using Contract.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface IPurchaseService
    {
        Task<IEnumerable<PurchaseDTO>> GetPurchasesData(string? productName);
    }
}
