using System;
using System.Collections.Generic;

namespace HospitalDbAutoFill.Database;

public partial class MedicalCard
{
    public string MedicalCard1 { get; set; } = null!;

    public string? MedicalCardDateOfIssue { get; set; }

    public virtual Patient? Patient { get; set; }
}
