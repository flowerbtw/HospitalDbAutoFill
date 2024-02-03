using System;
using System.Collections.Generic;

namespace HospitalDbAutoFill.Database;

public partial class Insurance
{
    public string Insurance1 { get; set; } = null!;

    public string? InsuranceExpiringDate { get; set; }

    public virtual Patient? Patient { get; set; }
}
