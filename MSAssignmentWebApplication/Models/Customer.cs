using System;
using System.Collections.Generic;

namespace MSAssignmentWebApplication.Models;

public partial class Customer
{
    public long CustomerId { get; set; }

    public string? FullName { get; set; }

    public DateTime? Dob { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
}
