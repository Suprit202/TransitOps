using System;
using System.Collections.Generic;

namespace TransitOpsRepository.Models;

public partial class TripExpense
{
    public int Id { get; set; }

    public int TripId { get; set; }

    public decimal? TollCost { get; set; }

    public decimal? OtherCost { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Trip Trip { get; set; } = null!;
}
