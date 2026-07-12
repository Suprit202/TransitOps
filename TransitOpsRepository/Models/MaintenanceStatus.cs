using System;
using System.Collections.Generic;

namespace TransitOpsRepository.Models;

public partial class MaintenanceStatus
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<MaintenanceLog> MaintenanceLogs { get; set; } = new List<MaintenanceLog>();
}
