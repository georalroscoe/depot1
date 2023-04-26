using System;
using System.Collections.Generic;


namespace Domain;
public class Product
{
    public Product(string name, int weight)
    {
        Name = name;
        Weight = weight;

    }
    public int ProductId { get; private set; }

    public string Name { get; private set; }

    public int Weight { get; private set; }

    public virtual ICollection<ManufactoringLot> ManufactoringLots { get; set; } = new List<ManufactoringLot>();

    public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();

    public void productFinder(int quantity, int orderId)
    {

        foreach (var batch in ManufactoringLots.SelectMany(x => x.WarehouseBatchContents).OrderBy(x => x.Quantity))
        {
           
                if (quantity == 0)
                {
                    break;
                }



            if (quantity < batch.Quantity)
            {
                var orderProductLocations = new OrderProductLocations(batch.WarehouseBatchNavigation, quantity);
                
                OrderProducts.Where(x=> x.ProductId == ProductId && x.OrderId == orderId).FirstOrDefault().OrderProductLocations.Add(orderProductLocations);
                quantity = 0;
                


            }
            else
            {
                var orderProductLocations = new OrderProductLocations(batch.WarehouseBatchNavigation, batch.Quantity);
                OrderProducts.Where(x => x.ProductId == ProductId && x.OrderId == orderId).FirstOrDefault().OrderProductLocations.Add(orderProductLocations);
               
                quantity -= batch.Quantity;




            }
        }
    }
}
