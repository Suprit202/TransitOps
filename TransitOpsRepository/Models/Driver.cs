using System;
using System.Collections.Generic;

namespace TransitOpsRepository.Models;

public partial class Driver
{
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    public string LicenseNumber { get; set; } = null!;

    public string LicenseCategory { get; set; } = null!;

    public DateOnly LicenseExpiryDate { get; set; }

    public string ContactNumber { get; set; } = null!;

    public decimal SafetyScore { get; set; }

    public int StatusId { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual DriverStatus Status { get; set; } = null!;

    public virtual ICollection<Trip> Trips { get; set; } = new List<Trip>();
}
