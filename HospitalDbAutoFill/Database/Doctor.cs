﻿using System;
using System.Collections.Generic;

namespace HospitalDbAutoFill.Database;

public partial class Doctor
{
    public long DoctorId { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Hospitalization> Hospitalizations { get; set; } = new List<Hospitalization>();

    public virtual ICollection<MedicalProcedure> MedicalProcedures { get; set; } = new List<MedicalProcedure>();
}
