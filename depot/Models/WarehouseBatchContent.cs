using System;
using System.Collections.Generic;

namespace depot.Models;

public partial class WarehouseBatchContent
{
    public int Id { get; set; }

    public int? WarehouseBatch { get; set; }

    public int? ManufactoringLot { get; set; }

    public int? Quantity { get; set; }

    public virtual ManufactoringLot? ManufactoringLotNavigation { get; set; }

    public virtual WarehouseBatch? WarehouseBatchNavigation { get; set; }
}
