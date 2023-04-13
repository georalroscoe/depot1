using System;
using System.Collections.Generic;

namespace depot.Models;

public partial class WarehouseBatch
{
    public int Id { get; set; }

    public int? Location { get; set; }

    public virtual Location? LocationNavigation { get; set; }

    public virtual ICollection<WarehouseBatchContent> WarehouseBatchContents { get; set; } = new List<WarehouseBatchContent>();
}
