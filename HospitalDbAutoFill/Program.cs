using HospitalDbAutoFill.Database;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Runtime.ExceptionServices;

class Program
{
    static string GenerateRandomNumber(int length, Random random, string[] digits)
    {
        return string.Join(string.Empty, Enumerable.Repeat(digits, length).Select(a => a[random.Next(a.Length)]));
    }

    static DateTime GenerateRandomDate(int startYear, int endYear, int endMonth, int endDay, Random random)
    {
        return new DateTime(random.Next(startYear, endYear + 1), random.Next(1, endMonth + 1), random.Next(1, endDay + 1));
    }

    static void InsertRandomPatient(HospitalContext dbContext, Random random, string[] digits)
    {
        string randomMedicalCardNumber = GenerateRandomNumber(7, random, digits);
        DateTime randomMedicalcardDateOfIssue = GenerateRandomDate(2025, 2036, 12, 29, random);
        string formattedMedicalCardDateOfIssue = randomMedicalcardDateOfIssue.ToString("dd.MM.yyyy");

        MedicalCard medicalCard = new MedicalCard
        {
            MedicalCardNumber = randomMedicalCardNumber,
            MedicalCardDateOfIssue = formattedMedicalCardDateOfIssue,
        };
        dbContext.MedicalCards.Add(medicalCard);
        dbContext.SaveChanges();
        Console.WriteLine($"Inserted new medical card");

        string randomInsuranceNumber = GenerateRandomNumber(16, random, digits);
        DateTime randomInsuranceExpiringDate = GenerateRandomDate(2025, 2036, 12, 29, random);
        string formattedInsuranceExpiringDate = randomInsuranceExpiringDate.ToString("dd.MM.yyyy");

        Insurance insurance = new Insurance
        {
            InsuranceNumber = randomInsuranceNumber,
            InsuranceExpiringDate = formattedInsuranceExpiringDate,
        };
        dbContext.Insurances.Add(insurance);
        dbContext.SaveChanges();
        Console.WriteLine($"Inserted new insurance");

        string[] maleFirstNames = { "Artem", "Anton", "Georgy", "Alexey", "Nikita", "Igor", "Mikhail", "Egor", "Vitaly", "Lev", "Yaroslav", "Henry", "Danil", "Daniil", "Alexander" };
        string[] femaleFirstNames = { "Anna", "Maria", "Ekaterina", "Sofia", "Elizaveta", "Polina", "Daria", "Anastasia", "Victoria", "Aleksandra", "Valeria", "Alina", "Ksenia", "Tatiana" };

        string[] maleLastNames = { "Ivanov", "Petrov", "Sidorov", "Fedorov", "Nikolaev", "Kuznetsov", "Semyonov", "Kuznetsov", "Popov", "Gordeev", "Kuznetsov", "Sokolov", "Semyonov", "Kuznetsov" };
        string[] femaleLastNames = { "Ivanova", "Petrova", "Sidorova", "Fedorova", "Nikolaeva", "Kuznetsova", "Semyonova", "Kuznetsova", "Popova", "Gordeeva", "Kuznetsova", "Sokolova", "Semyonova", "Kuznetsova" };

        string[] malePatronymics = { "Sergeevich", "Vasilievich", "Igorevich", "Alekseevich", "Nikitich", "Mikhailovich", "Egorovich", "Vitalievich", "Levovich", "Yaroslavovich", "Henrievich", "Danilovich", "Daniilovich", "Aleksandrovich" };
        string[] femalePatronymics = { "Sergeevna", "Vasilievna", "Igorevna", "Alekseevna", "Nikitichna", "Mikhailovna", "Egorovna", "Vitalievna", "Levovna", "Yaroslavovna", "Henrievna", "Danilovna", "Daniilovna", "Aleksandrovna" };

        string[] genders = { "Male", "Female" };
        string[] cities = { "Moscow", "Saint Petersburg", "Novosibirsk", "Yekaterinburg", "Nizhny Novgorod", "Samara", "Kazan", "Chelyabinsk", "Omsk", "Rostov-on-Don", "Ufa", "Volgograd", "Krasnoyarsk", "Saratov" };
        string[] streets = { "Lenina", "Mira", "Sovetskaya", "Komsomolskaya", "Oktiabrskaya", "Prospekt Mira", "Prospekt Lenina", "Karla Marksa", "Engelsa", "Frunze", "Gorkogo", "Dzerzhinskogo", "Kirova", "Kalinina" };
        string[] diagnosises = { "Broken leg", "Flu", "Headache", "Stomachache", "Cold" };
        string[] medicalHistories = { "No medical history", "Allergies", "Asthma", "Diabetes", "Hypertension" };

        string randomGender = genders[random.Next(genders.Length)];

        string randomFirstName;
        string randomLastName;
        string randomPatronymic;
        if (randomGender == "Male")
        {
            randomFirstName = maleFirstNames[random.Next(maleFirstNames.Length)];
            randomLastName = maleLastNames[random.Next(maleLastNames.Length)];
            randomPatronymic = malePatronymics[random.Next(malePatronymics.Length)];
        }
        else
        {
            randomFirstName = femaleFirstNames[random.Next(femaleFirstNames.Length)];
            randomLastName = femaleLastNames[random.Next(femaleLastNames.Length)];
            randomPatronymic = femalePatronymics[random.Next(femalePatronymics.Length)];
        }

        string randomPassport = GenerateRandomNumber(10, random, digits);

        DateTime randomBirthdate = GenerateRandomDate(1950, 2007, 12, 29, random);
        string formattedBirthdate = randomBirthdate.ToString("dd.MM.yyyy");

        string randomCity = cities[random.Next(cities.Length)];
        string randomStreet = streets[random.Next(streets.Length)];
        int randomHouse = random.Next(1, 100);
        int randomApartment = random.Next(1, 100);

        string randomPhoneNumber = "+" + "7" + GenerateRandomNumber(9, random, digits);

        string randomEmailDomain = random.Next(2) == 0 ? "gmail.com" : (random.Next(2) == 0 ? "yandex.com" : "mail.ru");
        int randomEmailLength = random.Next(5, 15);
        string randomEmailLocalPart = new string(Enumerable.Repeat('a', randomEmailLength).Select(c => (char)random.Next(97, 123)).ToArray());
        string randomEmail = randomEmailLocalPart + randomEmailDomain;

        DateTime randomLastAppointment = GenerateRandomDate(2023, 2023, 12, 29, random);
        string formattedLastAppointment = randomLastAppointment.ToString("dd.MM.yyyy");

        DateTime randomNextAppointment = new DateTime(1900, 01, 01);
        while (randomLastAppointment > randomNextAppointment)
        {
            randomNextAppointment = GenerateRandomDate(2025, 2025, 12, 29, random);
        }
        string formattedNextAppointment = randomNextAppointment.ToString("dd.MM.yyyy");

        string randomDiagnosis = diagnosises[random.Next(diagnosises.Length)];
        string randomMedicalHistory = medicalHistories[random.Next(medicalHistories.Length)];

        Patient patient = new Patient
        {
            FirstName = randomFirstName,
            LastName = randomLastName,
            Patronymic = randomPatronymic,
            Passport = randomPassport,
            Birthdate = formattedBirthdate,
            Country = "Russia",
            City = randomCity,
            Street = randomStreet,
            House = randomHouse,
            Apartment = randomApartment,
            PhoneNumber = randomPhoneNumber,
            Email = randomEmail,
            MedicalCardNumber = medicalCard.MedicalCardNumber,
            LastAppointment = formattedLastAppointment,
            NextAppointment = formattedNextAppointment,
            InsuranceNumber = insurance.InsuranceNumber,
            Diagnosis = randomDiagnosis,
            MedicalHistory = randomMedicalHistory,
        };
        dbContext.Patients.Add(patient);
        dbContext.SaveChanges();
        Console.WriteLine($"Inserted new patient");
    }

    static void InsertRandomHospitalization(HospitalContext dbContext, Random random)
    {
        string[] hospitalizationTypes = { "Planned", "Emergency", "Elective" };
        string[] results = { "Positive", "Negative", "Inconclusive" };
        string[] recommendations = { "Take this medicine", "Avoid heavy lifting", "Follow up with your doctor" };

        int randomPatientId = random.Next(1, 101);

        DateTime randomHospitalizationDate = GenerateRandomDate(2022, 2024, 12, 29, random);
        string formattedHospitalizationDate = randomHospitalizationDate.ToString("dd.MM.yyyy");

        int randomDoctorId = random.Next(1, 11);
        string randomHospitalizationType = hospitalizationTypes[random.Next(hospitalizationTypes.Length)];
        int randomProcedureId = random.Next(1, 11);
        string randomResult = results[random.Next(results.Length)];
        string randomRecommendation = recommendations[random.Next(recommendations.Length)];

        Hospitalization hospitalization = new Hospitalization
        {
            PatientId = randomPatientId,
            HospitalizationDate = formattedHospitalizationDate,
            DoctorId = randomDoctorId,
            HospitalizationType = randomHospitalizationType,
            ProcedureId = randomProcedureId,
            Result = randomResult,
            Recommendations = randomRecommendation,
        };
        dbContext.Hospitalizations.Add(hospitalization);
        dbContext.SaveChanges();
        Console.WriteLine($"Inserted new hospitalization");
    }

    static void Main(string[] args)
    {
        Random random = new Random();
        string[] digits = Enumerable.Range(0, 10).Select(i => i.ToString()).ToArray();

        using (HospitalContext dbContext = new HospitalContext())
        {
            for (int i = 0; i <= 100; i++)
            {
                InsertRandomPatient(dbContext, random, digits);
                Console.WriteLine();
                InsertRandomHospitalization(dbContext, random);
            }
        }

        Console.Clear();
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}