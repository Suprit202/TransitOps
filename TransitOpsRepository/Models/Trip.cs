using System;
using System.Collections.Generic;

namespace TransitOpsRepository.Models;

public partial class Trip
{
    public int Id { get; set; }

    public string TripCode { get; set; } = null!;

    public int? VehicleId { get; set; }

    public int? DriverId { get; set; }

    public string Source { get; set; } = null!;

    public string Destination { get; set; } = null!;

    public decimal CargoWeight { get; set; }

    public decimal PlannedDistance { get; set; }

    public int StatusId { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Driver? Driver { get; set; }

    public virtual TripStatus Status { get; set; } = null!;

    public virtual ICollection<TripExpense> TripExpenses { get; set; } = new List<TripExpense>();

    public virtual Vehicle? Vehicle { get; set; }
}
