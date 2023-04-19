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
}
