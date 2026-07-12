using System;
using System.Collections.Generic;

namespace TransitOpsRepository.Models;

public partial class FuelLog
{
    public int Id { get; set; }

    public int VehicleId { get; set; }

    public DateOnly LogDate { get; set; }

    public decimal Liters { get; set; }

    public decimal Cost { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Vehicle Vehicle { get; set; } = null!;
}
