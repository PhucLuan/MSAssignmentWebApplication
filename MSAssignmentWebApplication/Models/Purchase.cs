using System;
using System.Collections.Generic;

namespace MSAssignmentWebApplication.Models;

public partial class Purchase
{
    public long PurchaseId { get; set; }

    public long CustomerId { get; set; }

    public long ProductId { get; set; }

    public DateTime? PurchaseDate { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
