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
    public int Id { get; private set; }

    public string Name { get; private set; }

    public int WeightCapacity { get; private set; }

    public virtual ICollection<Location> Locations { get; set; } = new List<Location>();
}
