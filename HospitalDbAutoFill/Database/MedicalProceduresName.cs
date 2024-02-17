using System;
using System.Collections.Generic;

namespace HospitalDbAutoFill.Database;

public partial class MedicalProceduresName
{
    public long ProcedureNameId { get; set; }

    public string? ProcedureName { get; set; }

    public long? ProcedureTypeId { get; set; }

    public long? Price { get; set; }

    public virtual ICollection<MedicalProcedure> MedicalProcedures { get; set; } = new List<MedicalProcedure>();

    public virtual MedicalProceduresType? ProcedureType { get; set; }
}
