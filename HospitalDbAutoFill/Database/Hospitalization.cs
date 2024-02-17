﻿using System;
using System.Collections.Generic;

namespace HospitalDbAutoFill.Database;

public partial class Hospitalization
{
    public long HospitalizationId { get; set; }

    public long? PatientId { get; set; }

    public string? HospitalizationDate { get; set; }

    public string? HospitalizationType { get; set; }

    public long? ProcedureId { get; set; }

    public string? HospitalizationResults { get; set; }

    public string? HospitalizationRecommendations { get; set; }

    public virtual Patient? Patient { get; set; }

    public virtual MedicalProcedure? Procedure { get; set; }
}
