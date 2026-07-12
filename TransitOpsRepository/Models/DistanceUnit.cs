using System;
using System.Collections.Generic;

namespace TransitOpsRepository.Models;

public partial class DistanceUnit
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<AppSetting> AppSettings { get; set; } = new List<AppSetting>();
}
