using System;
using System.Collections.Generic;

namespace HospitalDbAutoFill.Database;

public partial class MedicalProceduresType
{
    public long ProcedureTypeId { get; set; }

    public string? ProcedureType { get; set; }

    public virtual ICollection<MedicalProceduresName> MedicalProceduresNames { get; set; } = new List<MedicalProceduresName>();
}
