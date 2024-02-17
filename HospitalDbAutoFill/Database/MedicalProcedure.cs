using System;
using System.Collections.Generic;

namespace HospitalDbAutoFill.Database;

public partial class MedicalProcedure
{
    public long ProcedureId { get; set; }

    public long? PatientId { get; set; }

    public string? ProcedureDate { get; set; }

    public long? DoctorId { get; set; }

    public long? ProcedureNameId { get; set; }

    public string? ProcedureResults { get; set; }

    public string? ProcedureRecommendations { get; set; }

    public virtual Doctor? Doctor { get; set; }

    public virtual ICollection<Hospitalization> Hospitalizations { get; set; } = new List<Hospitalization>();

    public virtual Patient? Patient { get; set; }

    public virtual MedicalProceduresName? ProcedureName { get; set; }
}
