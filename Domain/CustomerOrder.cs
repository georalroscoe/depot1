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
        foreach (var productOrder in OrderProducts.ToList())
        {

            productOrder.Product.productFinder(productOrder.Quantity, productOrder.OrderId);

        }
     
    }
}
