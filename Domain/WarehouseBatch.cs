using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;


namespace Domain;
public class WarehouseBatch
{
    
    public WarehouseBatch(int location)
    {
        Location = location;
    }

    public int Id { get; private set; }

    public int Location { get; private set; }

    public virtual Location? LocationNavigation { get; set; }

    public virtual ICollection<WarehouseBatchContent> WarehouseBatchContents { get; set; } = new List<WarehouseBatchContent>();

    public void MoveFromBatch(int NewBatchId, int QuantityMoving, int ManufactoringLot)
    {/*might have to pass this through to get the current instance*/
        int preQuantity = this.QuantityMoving;
        this.

        if (preQuantity >= quantityMoving)
        {
            this.Quantity -= quantityMoving;
        }
        else
        {
            throw new Exception("Quantity too low!");
        }

        WarehouseBatch newBatchLocation = new(location);
        WarehouseBatchContent newBatch = new(newBatchLocation.Id, this.ManufactoringLot, quantityMoving);
        /*var or entity name?*/

        WarehouseBatches.Add(newBatchLocation);
        /*WarehouseBatchContents.Add(newBatch);*/
        /* also defined methods for these but unsure about what to put before the dot and in the brackets*/

        if (this.Quantity == 0)
        {
            Console.WriteLine("warehouse batch row should be deleted");
            /* find out how to delete for both of these*/
            if (numberOfRows == 1)
            {
                Console.WriteLine("batch location should be deleted");
            }
        }



        if (preQuantity != (this.Quantity + newBatch.Quantity))
        {

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

}