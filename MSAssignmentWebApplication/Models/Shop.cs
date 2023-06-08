using System;
using System.Collections.Generic;

namespace MSAssignmentWebApplication.Models;

public partial class Shop
{
    public long ShopId { get; set; }

    public string? Name { get; set; }

    public string? Location { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
