using System;
using System.Collections.Generic;

namespace Domain;
public class OrderProduct
{
    public OrderProduct(int productId, int orderId, int quantity)
    {
        ProductId = productId;
        OrderId = orderId;
        Quantity = quantity;
         

    }
    public int OrderProductId { get; private set; }

    public int ProductId { get; private set; }

    public int OrderId { get; private set; }
    public int Quantity { get; private set; }

    public virtual Product? Product { get; set; }
    public virtual CustomerOrder? CustomerOrder { get; set; }

    
   
}
