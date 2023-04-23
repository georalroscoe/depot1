using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using Domain;

namespace Domain;
public class WarehouseBatchContent
{
   
    public WarehouseBatchContent(int warehouseBatchId, int manufactoringLotId, int quantity) 
    {
        WarehouseBatchId = warehouseBatchId;
        ManufactoringLotId= manufactoringLotId;
        Quantity= quantity;
       

    }
    
    public int WarehouseBatchContentId { get; private set; }

    public int WarehouseBatchId { get; private set; }

    public int ManufactoringLotId { get; private set; }

    public int Quantity { get; set; }

    public virtual ManufactoringLot? ManufactoringLotNavigation { get; set; }

    public virtual WarehouseBatch? WarehouseBatchNavigation { get; set; }

}
