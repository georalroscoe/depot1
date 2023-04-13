using System;
using System.Collections.Generic;

namespace depot.Models;

public partial class Location
{
    public int Id { get; set; }

    public int? LocationType { get; set; }

    public virtual LocationType? LocationTypeNavigation { get; set; }

    public virtual ICollection<WarehouseBatch> WarehouseBatches { get; set; } = new List<WarehouseBatch>();
}
