using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HospitalDbAutoFill.Database;

public partial class HospitalContext : DbContext
{
    public HospitalContext()
    {
    }

    public HospitalContext(DbContextOptions<HospitalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<Hospitalization> Hospitalizations { get; set; }

    public virtual DbSet<Insurance> Insurances { get; set; }

    public virtual DbSet<MedicalCard> MedicalCards { get; set; }

    public virtual DbSet<MedicalProcedure> MedicalProcedures { get; set; }

    public virtual DbSet<MedicalProceduresName> MedicalProceduresNames { get; set; }

    public virtual DbSet<MedicalProceduresType> MedicalProceduresTypes { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = E:\\Development\\Microsoft Visual Studio\\WordSkills 2024\\HospitalDbAutoFill\\HospitalDbAutoFill\\bin\\Debug\\net7.0\\Hospital.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasIndex(e => e.Login, "IX_Doctors_Login").IsUnique();
        });

        modelBuilder.Entity<Hospitalization>(entity =>
        {
            entity.HasIndex(e => e.DoctorId, "IX_Hospitalizations_DoctorId");

            entity.HasIndex(e => e.PatientId, "IX_Hospitalizations_PatientId");

            entity.HasIndex(e => e.ProcedureId, "IX_Hospitalizations_ProcedureId");

            entity.HasOne(d => d.Doctor).WithMany(p => p.Hospitalizations).HasForeignKey(d => d.DoctorId);

            entity.HasOne(d => d.Patient).WithMany(p => p.Hospitalizations).HasForeignKey(d => d.PatientId);

            entity.HasOne(d => d.Procedure).WithMany(p => p.Hospitalizations).HasForeignKey(d => d.ProcedureId);
        });

        modelBuilder.Entity<Insurance>(entity =>
        {
            entity.HasKey(e => e.InsuranceNumber);

            entity.ToTable("Insurance");
        });

        modelBuilder.Entity<MedicalCard>(entity =>
        {
            entity.HasKey(e => e.MedicalCardNumber);
        });

        modelBuilder.Entity<MedicalProcedure>(entity =>
        {
            entity.HasKey(e => e.ProcedureId);

            entity.HasIndex(e => e.DoctorId, "IX_MedicalProcedures_DoctorId");

            entity.HasIndex(e => e.PatientId, "IX_MedicalProcedures_PatientId");

            entity.HasIndex(e => e.ProcedureNameId, "IX_MedicalProcedures_ProcedureNameId");

            entity.HasOne(d => d.Doctor).WithMany(p => p.MedicalProcedures).HasForeignKey(d => d.DoctorId);

            entity.HasOne(d => d.Patient).WithMany(p => p.MedicalProcedures).HasForeignKey(d => d.PatientId);

            entity.HasOne(d => d.ProcedureName).WithMany(p => p.MedicalProcedures).HasForeignKey(d => d.ProcedureNameId);
        });

        modelBuilder.Entity<MedicalProceduresName>(entity =>
        {
            entity.HasKey(e => e.ProcedureNameId);

            entity.HasIndex(e => e.ProcedureName, "IX_MedicalProceduresNames_ProcedureName").IsUnique();

            entity.HasIndex(e => e.ProcedureTypeId, "IX_MedicalProceduresNames_ProcedureTypeId");

            entity.HasOne(d => d.ProcedureType).WithMany(p => p.MedicalProceduresNames).HasForeignKey(d => d.ProcedureTypeId);
        });

        modelBuilder.Entity<MedicalProceduresType>(entity =>
        {
            entity.HasKey(e => e.ProcedureTypeId);
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasIndex(e => e.Email, "IX_Patients_Email").IsUnique();

            entity.HasIndex(e => e.InsuranceNumber, "IX_Patients_InsuranceNumber").IsUnique();

            entity.HasIndex(e => e.MedicalCardNumber, "IX_Patients_MedicalCardNumber").IsUnique();

            entity.HasIndex(e => e.Passport, "IX_Patients_Passport").IsUnique();

            entity.HasIndex(e => e.PhoneNumber, "IX_Patients_PhoneNumber").IsUnique();

            entity.HasIndex(e => e.Photo, "IX_Patients_Photo").IsUnique();

            entity.HasOne(d => d.InsuranceNumberNavigation).WithOne(p => p.Patient).HasForeignKey<Patient>(d => d.InsuranceNumber);

            entity.HasOne(d => d.MedicalCardNumberNavigation).WithOne(p => p.Patient).HasForeignKey<Patient>(d => d.MedicalCardNumber);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
