using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;


namespace Domain;
public class WarehouseBatch
{
    
    public WarehouseBatch(int locationId)
    {
        LocationId = locationId;
    }

    public int WarehouseBatchId { get; private set; }

    public int LocationId { get; private set; }

    public virtual Location? LocationNavigation { get; set; }

    public virtual ICollection<WarehouseBatchContent> WarehouseBatchContents { get; set; } = new List<WarehouseBatchContent>();

    public void MoveFromBatch(int NewBatchId, int QuantityMoving, int ManufactoringLot)
    {/*might have to pass this through to get the current instance*/
       /*var egg = WarehouseBatchContents.Where(x => x.ManufactoringLotId == ManufactoringLot);
        if (egg == null) {
            throw new Exception("fff");

        }*/
       
        

    }

}