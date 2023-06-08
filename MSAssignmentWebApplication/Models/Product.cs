using System;
using System.Collections.Generic;

namespace MSAssignmentWebApplication.Models;

public partial class Product
{
    public long ProductId { get; set; }

    public string? Name { get; set; }

    public double? Price { get; set; }

    public long? ShopId { get; set; }

    public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();

    public virtual Shop? Shop { get; set; }
}
