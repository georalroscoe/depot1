using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Domain;
public class WarehouseBatchContent
{
    public WarehouseBatchContent(int warehouseBatch, int manufactoringLot, int quantity)
    {
        WarehouseBatch = warehouseBatch;
        ManufactoringLot= manufactoringLot;
        Quantity= quantity;

    }

    public int Id { get; set; }

    public int WarehouseBatch { get; set; }

    public int ManufactoringLot { get; set; }

    public int Quantity { get; set; }

    public virtual ManufactoringLot? ManufactoringLotNavigation { get; set; }

    public virtual WarehouseBatch? WarehouseBatchNavigation { get; set; }

    public void MoveFromBatch(WarehouseBatchContent extractionBatch, int location, int quantity, int noRows)
    {
        int preQuantity = extractionBatch.Quantity;
        if (preQuantity >= quantity)
        {
            extractionBatch.Quantity = extractionBatch.Quantity - quantity;
        }
        else
        {
            Console.WriteLine("Quantity too low");
        }

        Location newBatchLocation = new Location(location);
        WarehouseBatchContent newBatch = new WarehouseBatchContent(newBatchLocation.Id, extractionBatch.ManufactoringLot, quantity);
        
        /* call the add method but doesn't seem to be working in here */

        if (extractionBatch.Quantity == 0)
        {
            Console.WriteLine("warehouse batch row should be deleted");
            if(noRows == 1)
            {
                Console.WriteLine("batch location should be deleted");
            }
        }

        

        if (preQuantity != (extractionBatch.Quantity + newBatch.Quantity )) {
            Console.WriteLine("consistency error");

        }




        /* create new warehousebatchcontent
         * create new warehousebatch
         * delete row from wbatchcontent if quant is 0
         * delete row from wbatch if that was only row
         * 
         * 
         * validate the quantities
         */

        




    }
    /*public void AddNewWarehouseBatchContent(WarehouseBatchContent batchContent)
    {
        WarehouseBatchContent.Add(batchContent);
    }*/
}
