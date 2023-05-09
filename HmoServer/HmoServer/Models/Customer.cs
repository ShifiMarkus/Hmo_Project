using System;
using System.Collections.Generic;

namespace HmoServer.Models;

public partial class Customer
{
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? City { get; set; }

    public string? Street { get; set; }

    public int? HouseNumber { get; set; }

    public long CustomerId { get; set; }

    public string? PhoneNumber { get; set; }

    public string? CellPhone { get; set; }

    public DateTime? BirthDate { get; set; }

    public virtual ICollection<CoronaDetail> CoronaDetails { get; set; } = new List<CoronaDetail>();
}
