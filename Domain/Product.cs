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
    public int Id { get; set; }

    public string Name { get; set; }

    public int Weight { get; set; }

    public virtual ICollection<ManufactoringLot> ManufactoringLots { get; set; } = new List<ManufactoringLot>();
}
