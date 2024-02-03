using HospitalDbAutoFill.Database;
using System;
using System.Runtime.ExceptionServices;

Random random = new Random();

string[] digits = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };

static void InsertRandomPatient(HospitalContext dbContext, Random random, string[] digits)
{
    string randomMedicalCardNumber = new string(digits[random.Next(digits.Length)]) + new string(digits[random.Next(digits.Length)]) + new string(digits[random.Next(digits.Length)]) +
                               new string(digits[random.Next(digits.Length)]) + new string(digits[random.Next(digits.Length)]) + new string(digits[random.Next(digits.Length)]) +
                               new string(digits[random.Next(digits.Length)]);

    DateTime randomMedicalcardDateOfIssue = new DateTime(random.Next(2025, 2036), random.Next(1, 13), random.Next(1, 29));
    string formattedMedicalCardDateOfIssue = randomMedicalcardDateOfIssue.ToString("dd.MM.yyyy");

    MedicalCard medicalCard = new MedicalCard
    {
        MedicalCardNumber = randomMedicalCardNumber,
        MedicalCardDateOfIssue = formattedMedicalCardDateOfIssue,
    };
    dbContext.MedicalCards.Add(medicalCard);
    dbContext.SaveChanges();
    Console.WriteLine($"Inserted new medical card");

    string randomInsuranceNumber = new string(digits[random.Next(digits.Length)]) + new string(digits[random.Next(digits.Length)]) + new string(digits[random.Next(digits.Length)]) +
                           new string(digits[random.Next(digits.Length)]) + new string(digits[random.Next(digits.Length)]) + new string(digits[random.Next(digits.Length)]) +
                           new string(digits[random.Next(digits.Length)]) + new string(digits[random.Next(digits.Length)]) + new string(digits[random.Next(digits.Length)]) +
                           new string(digits[random.Next(digits.Length)]) + new string(digits[random.Next(digits.Length)]) + new string(digits[random.Next(digits.Length)]) +
                           new string(digits[random.Next(digits.Length)]) + new string(digits[random.Next(digits.Length)]) + new string(digits[random.Next(digits.Length)]) +
                           new string(digits[random.Next(digits.Length)]);

    DateTime randomInsuranceExpiringDate = new DateTime(random.Next(2025, 2036), random.Next(1, 13), random.Next(1, 29));
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

    string randomPassport = new string(digits[random.Next(digits.Length)]) + new string(digits[random.Next(digits.Length)]) + new string(digits[random.Next(digits.Length)]) +
                               new string(digits[random.Next(digits.Length)]) + new string(digits[random.Next(digits.Length)]) + new string(digits[random.Next(digits.Length)]) +
                               new string(digits[random.Next(digits.Length)]) + new string(digits[random.Next(digits.Length)]) + new string(digits[random.Next(digits.Length)]) +
                               new string(digits[random.Next(digits.Length)]) + new string(digits[random.Next(digits.Length)]);

    DateTime randomBirthdate = new DateTime(random.Next(1950, 2007), random.Next(1, 13), random.Next(1, 29));
    string formattedBirthdate = randomBirthdate.ToString("dd.MM.yyyy");

    string randomCity = cities[random.Next(cities.Length)];
    string randomStreet = streets[random.Next(streets.Length)];
    int randomHouse = random.Next(1, 100);
    int randomApartment = random.Next(1, 100);

    string randomPhoneNumber = "+" + "7" + new string(digits[random.Next(digits.Length)]) + new string(digits[random.Next(digits.Length)]) + new string(digits[random.Next(digits.Length)]) +
                               new string(digits[random.Next(digits.Length)]) + new string(digits[random.Next(digits.Length)]) + new string(digits[random.Next(digits.Length)]) +
                               new string(digits[random.Next(digits.Length)]) + new string(digits[random.Next(digits.Length)]) + new string(digits[random.Next(digits.Length)]);

    string randomEmailDomain = random.Next(2) == 0 ? "gmail.com" : (random.Next(2) == 0 ? "yandex.com" : "mail.ru");
    int randomEmailLength = random.Next(5, 15);
    string randomEmailLocalPart = new string(Enumerable.Repeat('a', randomEmailLength).Select(c => (char)random.Next(97, 123)).ToArray());
    string randomEmail = randomEmailLocalPart + randomEmailDomain;

    DateTime randomLastAppointment = new DateTime(2023, random.Next(1, 13), random.Next(1, 29));
    string formattedLastAppointment = randomLastAppointment.ToString("dd.MM.yyyy");

    DateTime randomNextAppointment = new DateTime(1900, 01, 01);
    while (randomLastAppointment > randomNextAppointment)
    {
        randomNextAppointment = new DateTime(2024, random.Next(1, 13), random.Next(1, 29));
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

static void InsertRandomHospitalization(HospitalContext dbContext)
{

}

static void Main(string[] args, Random random, string[] digits)
{
    using (HospitalContext dbContext = new HospitalContext())
    {
        for (int i = 0; i <= 100; i++)
        {
            InsertRandomPatient(dbContext, random, digits);
            Console.WriteLine();
            InsertRandomHospitalization(dbContext);
        }
    }

    Console.Clear();
    Console.WriteLine("Press any key to exit...");
    Console.ReadKey();
}