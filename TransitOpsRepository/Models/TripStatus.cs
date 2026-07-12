using System;
using System.Collections.Generic;

namespace TransitOpsRepository.Models;

public partial class TripStatus
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Trip> Trips { get; set; } = new List<Trip>();
}
