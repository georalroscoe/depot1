using System;
using System.Collections.Generic;

namespace Domain;
public class CustomerOrder
{
    public CustomerOrder(int customerId)
    {
        CustomerId = customerId;

    }
    public int CustomerId { get; private set; }

   
    public int OrderId { get; private set; }
    

   

    public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();

    public void GetLocations()
    {
        foreach (var product in OrderProducts)
        {
            
            
            var manufactoringLots = product.Product.ManufactoringLots.ToList();
            
            

                foreach (var m in manufactoringLots)
                {
                    if (product.Quantity == 0)
                    {
                        break;
                    }

                    var batches = m.WarehouseBatchContents.ToList().OrderBy(x => x.Quantity);
                    
                    foreach (var b in batches)
                    {

                        if (product.Quantity == 0)
                        {
                            break;
                        }
                            if (product.Quantity < b.Quantity)
                            {
                                var orderProductLocations = new OrderProductLocations(b.WarehouseBatchNavigation, product.Quantity);
                                product.TakeAwayQuantity(product.Quantity);
                                

                            }
                            else
                            {
                                var orderProductLocations = new OrderProductLocations(b.WarehouseBatchNavigation, b.Quantity);
                                product.TakeAwayQuantity(b.Quantity);
                                
                            }
                        
                    }
                   
                }
            
            

        }
     
    }
}
