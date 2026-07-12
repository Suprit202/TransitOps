using System;
using System.Collections.Generic;

namespace TransitOpsRepository.Models;

public partial class AppSetting
{
    public int Id { get; set; }

    public string DepotName { get; set; } = null!;

    public int CurrencyId { get; set; }

    public int DistanceUnitId { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Currency Currency { get; set; } = null!;

    public virtual DistanceUnit DistanceUnit { get; set; } = null!;
}
