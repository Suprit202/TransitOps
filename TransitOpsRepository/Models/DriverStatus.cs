using System;
using System.Collections.Generic;

namespace TransitOpsRepository.Models;

public partial class DriverStatus
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Driver> Drivers { get; set; } = new List<Driver>();
}
