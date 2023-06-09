using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessor.Model
{
    public partial class Customer
    {
        public long CustomerId { get; set; }

        public string? FullName { get; set; }

        public DateTime? Dob { get; set; }

        public string? Email { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
    }

}
