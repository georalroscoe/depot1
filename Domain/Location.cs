using System;
using System.Collections.Generic;


namespace Domain;
public class Location
{
 
    public Location(int locationTypeId)
    {

        LocationTypeId = locationTypeId;

    }
    public int LocationId { get; private set; }

    public int LocationTypeId { get; private set; }

    public virtual LocationType? LocationTypeNavigation { get; set; }

    public virtual ICollection<WarehouseBatch> WarehouseBatches { get; set; } = new List<WarehouseBatch>();

    public WarehouseBatch AddNewBatch()
    {
        WarehouseBatch newBatch = new WarehouseBatch();
        WarehouseBatches.Add(newBatch);
        return newBatch;
        
    }
}
