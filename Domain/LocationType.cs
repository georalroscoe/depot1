using System;
using System.Collections.Generic;

namespace Domain;
public class LocationType
{
    public LocationType(int id, string name, int weightCapacity)
    {
        
        Name = name;
        WeightCapacity = weightCapacity;


    }
    public int Id { get; set; }

    public string Name { get; set; }

    public int WeightCapacity { get; set; }

    public virtual ICollection<Location> Locations { get; set; } = new List<Location>();
}
