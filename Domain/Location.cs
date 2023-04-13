using System;
using System.Collections.Generic;


namespace Domain;
public class Location
{
    public Location(int locationType)
    {

        LocationType = locationType;

    }
    public int Id { get; private set; }

    public int LocationType { get; private set; }

    public virtual LocationType? LocationTypeNavigation { get; set; }

    public virtual ICollection<WarehouseBatch> WarehouseBatches { get; set; } = new List<WarehouseBatch>();

    
}
