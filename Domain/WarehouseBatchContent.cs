using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using Domain;

namespace Domain;
public class WarehouseBatchContent
{
    protected WarehouseBatchContent()
    {
     
        WarehouseBatches = new List<WarehouseBatch>();
    }
    public WarehouseBatchContent(int warehouseBatch, int manufactoringLot, int quantity)
    {
        WarehouseBatch = warehouseBatch;
        ManufactoringLot= manufactoringLot;
        Quantity= quantity;

    }

    public int Id { get; private set; }

    public int WarehouseBatch { get; private set; }

    public int ManufactoringLot { get; private set; }

    public int Quantity { get; private set; }

    public virtual ManufactoringLot? ManufactoringLotNavigation { get; set; }

    public virtual WarehouseBatch? WarehouseBatchNavigation { get; set; }

    
    public virtual ICollection<WarehouseBatch> WarehouseBatches { get; protected set; }

   
    
}
