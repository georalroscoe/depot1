﻿using System;
using System.Collections.Generic;

namespace depot.Models;

public partial class LocationType
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? WeightCapacity { get; set; }

    public virtual ICollection<Location> Locations { get; set; } = new List<Location>();
}
