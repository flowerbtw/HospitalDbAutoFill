using System;
using System.Collections.Generic;

namespace HospitalDbAutoFill.Database;

public partial class MedicalCard
{
    public string MedicalCardNumber { get; set; } = null!;

    public string? MedicalCardDateOfIssue { get; set; }
}
