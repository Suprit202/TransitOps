using System;
using System.Collections.Generic;

namespace TransitOpsRepository.Models;

public partial class Vehicle
{
    public int Id { get; set; }

    public string RegistrationNumber { get; set; } = null!;

    public string ModelName { get; set; } = null!;

    public int VehicleTypeId { get; set; }

    public decimal CapacityKg { get; set; }

    public decimal Odometer { get; set; }

    public decimal AcquisitionCost { get; set; }

    public int StatusId { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<FuelLog> FuelLogs { get; set; } = new List<FuelLog>();

    public virtual ICollection<MaintenanceLog> MaintenanceLogs { get; set; } = new List<MaintenanceLog>();

    public virtual VehicleStatus Status { get; set; } = null!;

    public virtual ICollection<Trip> Trips { get; set; } = new List<Trip>();
}
