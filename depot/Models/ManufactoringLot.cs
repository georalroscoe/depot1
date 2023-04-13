using System;
using System.Collections.Generic;

namespace depot.Models;

public partial class ManufactoringLot
{
    public int Id { get; set; }

    public int? ProductId { get; set; }

    public virtual Product? Product { get; set; }

    public virtual ICollection<WarehouseBatchContent> WarehouseBatchContents { get; set; } = new List<WarehouseBatchContent>();
}
