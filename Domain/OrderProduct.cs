using System;
using System.Collections.Generic;

namespace Domain;
public class OrderProduct
{

    private OrderProduct()
    {
        OrderProductLocations = new List<OrderProductLocations>();
    }
    public OrderProduct(int productId, int orderId, int quantity) : this()
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

    public ICollection<OrderProductLocations> OrderProductLocations { get; private set; }
    
   
}

public class OrderProductLocations
{
    public OrderProductLocations(WarehouseBatch warehouseBatch, int quantity)
    {
        WarehouseBatch = warehouseBatch;
        Quantity = quantity;
    }

    public WarehouseBatch WarehouseBatch { get; private set; }
    
    public int Quantity { get; private set; }
    

}
