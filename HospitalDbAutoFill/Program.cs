using HospitalDbAutoFill.Database;

static void InsertRandomPatient(HospitalContext dbContext)
{
    // Define an array of possible patient names
    string[] names = { "John Doe", "Jane Smith", "Mike Johnson", "Emma Watson", "Noah Smith" };

    // Select a random name from the array
    string randomName = names[new Random().Next(names.Length)];

    // Create a new patient with the random name and a random diagnosis
    Patient patient = new Patient { Name = randomName, Diagnosis = GenerateRandomDiagnosis() };

    // Insert the new patient into the database
    dbContext.Patients.Add(patient);
    dbContext.SaveChanges();

    Console.WriteLine($"Inserted new patient {patient.Name} with diagnosis {patient.Diagnosis}");
}

static string GenerateRandomDiagnosis()
{
    // Generate a random diagnosis
    string[] diagnoses = { "Broken leg", "Flu", "Headache", "Stomachache", "Cold" };
    return diagnoses[new Random().Next(diagnoses.Length)];
}

static void Main(string[] args)
{
    using (HospitalContext dbContext = new HospitalContext())
    {
        InsertRandomPatient(dbContext);
    }

    Console.WriteLine("Press any key to exit...");
    Console.ReadKey();
}