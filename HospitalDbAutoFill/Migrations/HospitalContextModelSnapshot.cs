﻿// <auto-generated />
using System;
using HospitalDbAutoFill.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HospitalDbAutoFill.Migrations
{
    [DbContext(typeof(HospitalContext))]
    partial class HospitalContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.15");

            modelBuilder.Entity("HospitalDbAutoFill.Database.Doctor", b =>
                {
                    b.Property<long>("DoctorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("DoctorId");

                    b.HasIndex(new[] { "Login" }, "IX_Doctors_Login")
                        .IsUnique();

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("HospitalDbAutoFill.Database.Hospitalization", b =>
                {
                    b.Property<long>("HospitalizationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long?>("DoctorId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("HospitalizationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("HospitalizationRecommendations")
                        .HasColumnType("TEXT");

                    b.Property<string>("HospitalizationResults")
                        .HasColumnType("TEXT");

                    b.Property<string>("HospitalizationType")
                        .HasColumnType("TEXT");

                    b.Property<long?>("PatientId")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("ProcedureId")
                        .HasColumnType("INTEGER");

                    b.HasKey("HospitalizationId");

                    b.HasIndex(new[] { "DoctorId" }, "IX_Hospitalizations_DoctorId");

                    b.HasIndex(new[] { "PatientId" }, "IX_Hospitalizations_PatientId");

                    b.HasIndex(new[] { "ProcedureId" }, "IX_Hospitalizations_ProcedureId");

                    b.ToTable("Hospitalizations");
                });

            modelBuilder.Entity("HospitalDbAutoFill.Database.Insurance", b =>
                {
                    b.Property<string>("InsuranceNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("InsuranceExpiringDate")
                        .HasColumnType("TEXT");

                    b.HasKey("InsuranceNumber");

                    b.ToTable("Insurance", (string)null);
                });

            modelBuilder.Entity("HospitalDbAutoFill.Database.MedicalCard", b =>
                {
                    b.Property<string>("MedicalCardNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("MedicalCardDateOfIssue")
                        .HasColumnType("TEXT");

                    b.HasKey("MedicalCardNumber");

                    b.ToTable("MedicalCards");
                });

            modelBuilder.Entity("HospitalDbAutoFill.Database.MedicalProcedure", b =>
                {
                    b.Property<long>("ProcedureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long?>("DoctorId")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("PatientId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ProcedureDate")
                        .HasColumnType("TEXT");

                    b.Property<long?>("ProcedureNameId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ProcedureRecommendations")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProcedureResults")
                        .HasColumnType("TEXT");

                    b.HasKey("ProcedureId");

                    b.HasIndex(new[] { "DoctorId" }, "IX_MedicalProcedures_DoctorId");

                    b.HasIndex(new[] { "PatientId" }, "IX_MedicalProcedures_PatientId");

                    b.HasIndex(new[] { "ProcedureNameId" }, "IX_MedicalProcedures_ProcedureNameId");

                    b.ToTable("MedicalProcedures");
                });

            modelBuilder.Entity("HospitalDbAutoFill.Database.MedicalProceduresName", b =>
                {
                    b.Property<long>("ProcedureNameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long?>("Price")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ProcedureName")
                        .HasColumnType("TEXT");

                    b.Property<long?>("ProcedureTypeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ProcedureNameId");

                    b.HasIndex(new[] { "ProcedureName" }, "IX_MedicalProceduresNames_ProcedureName")
                        .IsUnique();

                    b.HasIndex(new[] { "ProcedureTypeId" }, "IX_MedicalProceduresNames_ProcedureTypeId");

                    b.ToTable("MedicalProceduresNames");
                });

            modelBuilder.Entity("HospitalDbAutoFill.Database.MedicalProceduresType", b =>
                {
                    b.Property<long>("ProcedureTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ProcedureType")
                        .HasColumnType("TEXT");

                    b.HasKey("ProcedureTypeId");

                    b.ToTable("MedicalProceduresTypes");
                });

            modelBuilder.Entity("HospitalDbAutoFill.Database.Patient", b =>
                {
                    b.Property<long>("PatientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long?>("Apartment")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Birthdate")
                        .HasColumnType("TEXT");

                    b.Property<string>("City")
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .HasColumnType("TEXT");

                    b.Property<string>("Diagnosis")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Gender")
                        .HasColumnType("TEXT");

                    b.Property<long?>("House")
                        .HasColumnType("INTEGER");

                    b.Property<string>("InsuranceNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastAppointment")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("MedicalCardNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("MedicalHistory")
                        .HasColumnType("TEXT");

                    b.Property<string>("NextAppointment")
                        .HasColumnType("TEXT");

                    b.Property<string>("Passport")
                        .HasColumnType("TEXT");

                    b.Property<string>("Patronymic")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("Photo")
                        .HasColumnType("TEXT");

                    b.Property<string>("Street")
                        .HasColumnType("TEXT");

                    b.HasKey("PatientId");

                    b.HasIndex(new[] { "Email" }, "IX_Patients_Email")
                        .IsUnique();

                    b.HasIndex(new[] { "InsuranceNumber" }, "IX_Patients_InsuranceNumber")
                        .IsUnique();

                    b.HasIndex(new[] { "MedicalCardNumber" }, "IX_Patients_MedicalCardNumber")
                        .IsUnique();

                    b.HasIndex(new[] { "Passport" }, "IX_Patients_Passport")
                        .IsUnique();

                    b.HasIndex(new[] { "PhoneNumber" }, "IX_Patients_PhoneNumber")
                        .IsUnique();

                    b.HasIndex(new[] { "Photo" }, "IX_Patients_Photo")
                        .IsUnique();

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("HospitalDbAutoFill.Database.Hospitalization", b =>
                {
                    b.HasOne("HospitalDbAutoFill.Database.Doctor", "Doctor")
                        .WithMany("Hospitalizations")
                        .HasForeignKey("DoctorId");

                    b.HasOne("HospitalDbAutoFill.Database.Patient", "Patient")
                        .WithMany("Hospitalizations")
                        .HasForeignKey("PatientId");

                    b.HasOne("HospitalDbAutoFill.Database.MedicalProcedure", "Procedure")
                        .WithMany("Hospitalizations")
                        .HasForeignKey("ProcedureId");

                    b.Navigation("Doctor");

                    b.Navigation("Patient");

                    b.Navigation("Procedure");
                });

            modelBuilder.Entity("HospitalDbAutoFill.Database.MedicalProcedure", b =>
                {
                    b.HasOne("HospitalDbAutoFill.Database.Doctor", "Doctor")
                        .WithMany("MedicalProcedures")
                        .HasForeignKey("DoctorId");

                    b.HasOne("HospitalDbAutoFill.Database.Patient", "Patient")
                        .WithMany("MedicalProcedures")
                        .HasForeignKey("PatientId");

                    b.HasOne("HospitalDbAutoFill.Database.MedicalProceduresName", "ProcedureName")
                        .WithMany("MedicalProcedures")
                        .HasForeignKey("ProcedureNameId");

                    b.Navigation("Doctor");

                    b.Navigation("Patient");

                    b.Navigation("ProcedureName");
                });

            modelBuilder.Entity("HospitalDbAutoFill.Database.MedicalProceduresName", b =>
                {
                    b.HasOne("HospitalDbAutoFill.Database.MedicalProceduresType", "ProcedureType")
                        .WithMany("MedicalProceduresNames")
                        .HasForeignKey("ProcedureTypeId");

                    b.Navigation("ProcedureType");
                });

            modelBuilder.Entity("HospitalDbAutoFill.Database.Patient", b =>
                {
                    b.HasOne("HospitalDbAutoFill.Database.Insurance", "InsuranceNumberNavigation")
                        .WithOne("Patient")
                        .HasForeignKey("HospitalDbAutoFill.Database.Patient", "InsuranceNumber");

                    b.HasOne("HospitalDbAutoFill.Database.MedicalCard", "MedicalCardNumberNavigation")
                        .WithOne("Patient")
                        .HasForeignKey("HospitalDbAutoFill.Database.Patient", "MedicalCardNumber");

                    b.Navigation("InsuranceNumberNavigation");

                    b.Navigation("MedicalCardNumberNavigation");
                });

            modelBuilder.Entity("HospitalDbAutoFill.Database.Doctor", b =>
                {
                    b.Navigation("Hospitalizations");

                    b.Navigation("MedicalProcedures");
                });

            modelBuilder.Entity("HospitalDbAutoFill.Database.Insurance", b =>
                {
                    b.Navigation("Patient");
                });

            modelBuilder.Entity("HospitalDbAutoFill.Database.MedicalCard", b =>
                {
                    b.Navigation("Patient");
                });

            modelBuilder.Entity("HospitalDbAutoFill.Database.MedicalProcedure", b =>
                {
                    b.Navigation("Hospitalizations");
                });

            modelBuilder.Entity("HospitalDbAutoFill.Database.MedicalProceduresName", b =>
                {
                    b.Navigation("MedicalProcedures");
                });

            modelBuilder.Entity("HospitalDbAutoFill.Database.MedicalProceduresType", b =>
                {
                    b.Navigation("MedicalProceduresNames");
                });

            modelBuilder.Entity("HospitalDbAutoFill.Database.Patient", b =>
                {
                    b.Navigation("Hospitalizations");

                    b.Navigation("MedicalProcedures");
                });
#pragma warning restore 612, 618
        }
    }
}
