using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;


namespace Domain;
public class WarehouseBatch
{
    protected WarehouseBatch() { 
    WarehouseBatchContents = new List<WarehouseBatchContent>();
        
    }

    public WarehouseBatch(int locationId)
    {
        LocationId = locationId;
    }

    public int WarehouseBatchId { get; private set; }

    public int LocationId { get; private set; }

    public virtual Location? LocationNavigation { get; set; }

    public virtual ICollection<WarehouseBatchContent> WarehouseBatchContents { get; set; } = new List<WarehouseBatchContent>();

    public void MoveFromBatch(WarehouseBatch NewBatchId, int QuantityMoving, int ManufactoringLot, int LocationType)
    {
        
       

        int preQuantity = WarehouseBatchContents.FirstOrDefault(x => x.ManufactoringLotId == ManufactoringLot).Quantity;
        var Give = WarehouseBatchContents.FirstOrDefault(x=> x.ManufactoringLotId == ManufactoringLot);
        if (Give.Quantity < QuantityMoving)
        {
            throw new Exception("Quantity too low!");
        }
        Give.Quantity = Give.Quantity - QuantityMoving;

        var Get = NewBatchId.WarehouseBatchContents.FirstOrDefault(x => x.ManufactoringLotId == ManufactoringLot);
        if (Get != null)
        {
            throw new Exception("fff");
            Get.Quantity = Get.Quantity + QuantityMoving;
            
        }
        var newWarehouseBatchContent = new WarehouseBatchContent(NewBatchId.WarehouseBatchId, ManufactoringLot, QuantityMoving);
        NewBatchId.WarehouseBatchContents.Add(newWarehouseBatchContent);

     

        /*if (Give.Quantity +   != preQuantity)
        {

            throw new Exception("consistency error");
        }*/
        


        if (Give == null) {
            throw new Exception("sheeet");

        }
       
        /* take quant away from warehousebatchcontent for that manulot
         * add quant to newbatchid
         */

    }
   
}