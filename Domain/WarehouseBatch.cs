using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;


namespace Domain;
public class WarehouseBatch
{
    protected WarehouseBatch()
    {
        WarehouseBatches = new List<WarehouseBatch>();
    }
    public WarehouseBatch(int location)
    {
        Location = location;
    }

    public int Id { get; private set; }

    public int Location { get; private set; }

    public virtual Location? LocationNavigation { get; set; }

    public virtual ICollection<WarehouseBatchContent> WarehouseBatchContents { get; set; } = new List<WarehouseBatchContent>();

    public virtual ICollection<WarehouseBatch> WarehouseBatches { get; protected set; }

    public void AddNewWarehouseBatchLocation(WarehouseBatch batchLocation)
    {
        WarehouseBatches.Add(batchLocation);
    }
}