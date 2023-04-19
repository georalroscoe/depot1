using System;
using System.Collections.Generic;

namespace Domain;
public class ManufactoringLot
{
    public ManufactoringLot(int productId)
    {
        ProductId = productId;

    }
    public int ManufactoringLotId { get; private set; }

    public int ProductId { get; private set; }

    public virtual Product? Product { get; set; }

    public virtual ICollection<WarehouseBatchContent> WarehouseBatchContents { get; set; } = new List<WarehouseBatchContent>();
}
