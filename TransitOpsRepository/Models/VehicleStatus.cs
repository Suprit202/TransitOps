using System;
using System.Collections.Generic;

namespace TransitOpsRepository.Models;

public partial class VehicleStatus
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
}
