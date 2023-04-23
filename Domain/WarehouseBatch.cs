using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;


namespace Domain;
public class WarehouseBatch
{
    /*protected WarehouseBatch() { 
    WarehouseBatchContents = new List<WarehouseBatchContent>();
        
    }*/

    public WarehouseBatch()
    {
    }

    public int WarehouseBatchId { get; private set; }

    public int LocationId { get; private set; }

    public virtual Location? LocationNavigation { get; set; }

    public virtual ICollection<WarehouseBatchContent> WarehouseBatchContents { get; set; } = new List<WarehouseBatchContent>();

    public void MoveFromBatch(WarehouseBatch newBatch, int quantityMoving, int ManufactoringLot)
    {
    
       
        var GivingBatch = WarehouseBatchContents.FirstOrDefault(x=> x.ManufactoringLotId == ManufactoringLot);
        if (GivingBatch == null)
        {
            throw new Exception("Giving batch is null");
        }
        if (GivingBatch.Quantity < quantityMoving)
        {
            throw new Exception("Quantity too low!");
        }
        GivingBatch.Quantity = GivingBatch.Quantity - quantityMoving;

        var GettingBatch = newBatch.WarehouseBatchContents.FirstOrDefault(x => x.ManufactoringLotId == ManufactoringLot);
        if (GettingBatch != null)
        {
            GettingBatch.Quantity = GettingBatch.Quantity + quantityMoving;
            /*if (GettingBatch.Quantity + QuantityMoving != preQuantity)
            {
                throw new Exception("Consistnecy error");

            }*/
        }
        else
        {
            var newWarehouseBatchContent = new WarehouseBatchContent(newBatch.WarehouseBatchId, ManufactoringLot, quantityMoving);
            newBatch.AddContents(newWarehouseBatchContent);
            /*if (newWarehouseBatchContent.Quantity + QuantityMoving != preQuantity)
            {
                throw new Exception("Consistnecy error");

            }*/
        }

        
    }
    public void AddContents(WarehouseBatchContent warehouseBatchContent)
    {
        WarehouseBatchContents.Add(warehouseBatchContent);
    }
}