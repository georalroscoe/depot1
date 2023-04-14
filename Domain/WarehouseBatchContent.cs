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
        WarehouseBatchContents = new List<WarehouseBatchContent>();
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

    public virtual ICollection<WarehouseBatchContent> WarehouseBatchContents { get; protected set; }
    public virtual ICollection<WarehouseBatch> WarehouseBatches { get; protected set; }

    public void MoveFromBatch(int location, int quantityMoving, int numberOfRows)
    {/*might have to pass this through to get the current instance*/
        int preQuantity = Quantity;

        if (preQuantity >= quantityMoving)
        {
            Quantity = Quantity - quantityMoving;
        }
        else
        {
            throw new Exception("Quantity too low!");
        }

        WarehouseBatch newBatchLocation = new WarehouseBatch(location);
        WarehouseBatchContent newBatch = new WarehouseBatchContent(newBatchLocation.Id, ManufactoringLot, quantityMoving);
        /*var or entity name?*/

        WarehouseBatches.Add(newBatchLocation);
        WarehouseBatchContents.Add(newBatch);
        /* also defined methods for these but unsure about what to put before the dot and in the brackets*/

        if (Quantity == 0)
        {
            Console.WriteLine("warehouse batch row should be deleted");
            /* find out how to delete for both of these*/
            if(numberOfRows == 1)
            {
                Console.WriteLine("batch location should be deleted");
            }
        }

        

        if (preQuantity != (Quantity + newBatch.Quantity )) {
            
            throw new Exception("consistency error");
        }

        return;

        /* create new warehousebatchcontent
         * create new warehousebatch
         * delete row from wbatchcontent if quant is 0
         * delete row from wbatch if that was only row
         * 
         * 
         * validate the quantities
         */


    }
    public void AddNewWarehouseBatchContent(WarehouseBatchContent batchContent)
    {
        WarehouseBatchContents.Add(batchContent);
    }
}
