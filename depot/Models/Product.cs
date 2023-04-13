using System;
using System.Collections.Generic;

namespace depot.Models;

public partial class Product
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Weight { get; set; }

    public virtual ICollection<ManufactoringLot> ManufactoringLots { get; set; } = new List<ManufactoringLot>();
}
