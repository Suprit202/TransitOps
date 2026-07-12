using System;
using System.Collections.Generic;

namespace TransitOpsRepository.Models;

public partial class MaintenanceLog
{
    public int Id { get; set; }

    public int VehicleId { get; set; }

    public string ServiceType { get; set; } = null!;

    public decimal Cost { get; set; }

    public DateOnly ServiceDate { get; set; }

    public int StatusId { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual MaintenanceStatus Status { get; set; } = null!;

    public virtual Vehicle Vehicle { get; set; } = null!;
}
