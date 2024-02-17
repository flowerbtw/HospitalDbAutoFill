using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalDbAutoFill.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabaseSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    DoctorId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Login = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.DoctorId);
                });

            migrationBuilder.CreateTable(
                name: "Insurance",
                columns: table => new
                {
                    InsuranceNumber = table.Column<string>(type: "TEXT", nullable: false),
                    InsuranceExpiringDate = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insurance", x => x.InsuranceNumber);
                });

            migrationBuilder.CreateTable(
                name: "MedicalCards",
                columns: table => new
                {
                    MedicalCardNumber = table.Column<string>(type: "TEXT", nullable: false),
                    MedicalCardDateOfIssue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalCards", x => x.MedicalCardNumber);
                });

            migrationBuilder.CreateTable(
                name: "MedicalProceduresTypes",
                columns: table => new
                {
                    ProcedureTypeId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProcedureType = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalProceduresTypes", x => x.ProcedureTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    PatientId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    Patronymic = table.Column<string>(type: "TEXT", nullable: true),
                    Photo = table.Column<string>(type: "TEXT", nullable: true),
                    Passport = table.Column<string>(type: "TEXT", nullable: true),
                    Birthdate = table.Column<string>(type: "TEXT", nullable: true),
                    Gender = table.Column<string>(type: "TEXT", nullable: true),
                    Country = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    Street = table.Column<string>(type: "TEXT", nullable: true),
                    House = table.Column<long>(type: "INTEGER", nullable: true),
                    Apartment = table.Column<long>(type: "INTEGER", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    MedicalCardNumber = table.Column<string>(type: "TEXT", nullable: true),
                    LastAppointment = table.Column<string>(type: "TEXT", nullable: true),
                    NextAppointment = table.Column<string>(type: "TEXT", nullable: true),
                    InsuranceNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Diagnosis = table.Column<string>(type: "TEXT", nullable: true),
                    MedicalHistory = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientId);
                    table.ForeignKey(
                        name: "FK_Patients_Insurance_InsuranceNumber",
                        column: x => x.InsuranceNumber,
                        principalTable: "Insurance",
                        principalColumn: "InsuranceNumber");
                    table.ForeignKey(
                        name: "FK_Patients_MedicalCards_MedicalCardNumber",
                        column: x => x.MedicalCardNumber,
                        principalTable: "MedicalCards",
                        principalColumn: "MedicalCardNumber");
                });

            migrationBuilder.CreateTable(
                name: "MedicalProceduresNames",
                columns: table => new
                {
                    ProcedureNameId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProcedureName = table.Column<string>(type: "TEXT", nullable: true),
                    ProcedureTypeId = table.Column<long>(type: "INTEGER", nullable: true),
                    Price = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalProceduresNames", x => x.ProcedureNameId);
                    table.ForeignKey(
                        name: "FK_MedicalProceduresNames_MedicalProceduresTypes_ProcedureTypeId",
                        column: x => x.ProcedureTypeId,
                        principalTable: "MedicalProceduresTypes",
                        principalColumn: "ProcedureTypeId");
                });

            migrationBuilder.CreateTable(
                name: "MedicalProcedures",
                columns: table => new
                {
                    ProcedureId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PatientId = table.Column<long>(type: "INTEGER", nullable: true),
                    ProcedureDate = table.Column<string>(type: "TEXT", nullable: true),
                    DoctorId = table.Column<long>(type: "INTEGER", nullable: true),
                    ProcedureNameId = table.Column<long>(type: "INTEGER", nullable: true),
                    ProcedureResults = table.Column<string>(type: "TEXT", nullable: true),
                    ProcedureRecommendations = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalProcedures", x => x.ProcedureId);
                    table.ForeignKey(
                        name: "FK_MedicalProcedures_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "DoctorId");
                    table.ForeignKey(
                        name: "FK_MedicalProcedures_MedicalProceduresNames_ProcedureNameId",
                        column: x => x.ProcedureNameId,
                        principalTable: "MedicalProceduresNames",
                        principalColumn: "ProcedureNameId");
                    table.ForeignKey(
                        name: "FK_MedicalProcedures_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId");
                });

            migrationBuilder.CreateTable(
                name: "Hospitalizations",
                columns: table => new
                {
                    HospitalizationId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PatientId = table.Column<long>(type: "INTEGER", nullable: true),
                    HospitalizationDate = table.Column<string>(type: "TEXT", nullable: true),
                    DoctorId = table.Column<long>(type: "INTEGER", nullable: true),
                    HospitalizationType = table.Column<string>(type: "TEXT", nullable: true),
                    ProcedureId = table.Column<long>(type: "INTEGER", nullable: true),
                    HospitalizationResults = table.Column<string>(type: "TEXT", nullable: true),
                    HospitalizationRecommendations = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospitalizations", x => x.HospitalizationId);
                    table.ForeignKey(
                        name: "FK_Hospitalizations_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "DoctorId");
                    table.ForeignKey(
                        name: "FK_Hospitalizations_MedicalProcedures_ProcedureId",
                        column: x => x.ProcedureId,
                        principalTable: "MedicalProcedures",
                        principalColumn: "ProcedureId");
                    table.ForeignKey(
                        name: "FK_Hospitalizations_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_Login",
                table: "Doctors",
                column: "Login",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hospitalizations_DoctorId",
                table: "Hospitalizations",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Hospitalizations_PatientId",
                table: "Hospitalizations",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Hospitalizations_ProcedureId",
                table: "Hospitalizations",
                column: "ProcedureId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalProcedures_DoctorId",
                table: "MedicalProcedures",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalProcedures_PatientId",
                table: "MedicalProcedures",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalProcedures_ProcedureNameId",
                table: "MedicalProcedures",
                column: "ProcedureNameId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalProceduresNames_ProcedureName",
                table: "MedicalProceduresNames",
                column: "ProcedureName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MedicalProceduresNames_ProcedureTypeId",
                table: "MedicalProceduresNames",
                column: "ProcedureTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_Email",
                table: "Patients",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_InsuranceNumber",
                table: "Patients",
                column: "InsuranceNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_MedicalCardNumber",
                table: "Patients",
                column: "MedicalCardNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_Passport",
                table: "Patients",
                column: "Passport",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_PhoneNumber",
                table: "Patients",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_Photo",
                table: "Patients",
                column: "Photo",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hospitalizations");

            migrationBuilder.DropTable(
                name: "MedicalProcedures");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "MedicalProceduresNames");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "MedicalProceduresTypes");

            migrationBuilder.DropTable(
                name: "Insurance");

            migrationBuilder.DropTable(
                name: "MedicalCards");
        }
    }
}
