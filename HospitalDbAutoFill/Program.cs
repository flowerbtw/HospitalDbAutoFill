using HospitalDbAutoFill.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Runtime.ExceptionServices;

namespace HospitalDbAutoFill
{
    class Program
    {
        static readonly string[] results = { "Positive", "Negative", "Inconclusive" };
        static readonly string[] recommendations = { "Take this medicine", "Avoid heavy lifting", "Follow up with your doctor" };

        static string GenerateRandomNumber(int length, Random random, string[] digits)
        {
            return string.Join(string.Empty, Enumerable.Repeat(digits, length).Select(a => a[random.Next(a.Length)]));
        }

        static DateTime GenerateRandomDate(int startYear, int endYear, int endMonth, int endDay, Random random)
        {
            int year = random.Next(startYear, endYear + 1);
            int month = random.Next(1, endMonth + 1);
            int day = random.Next(1, endDay + 1);

            if (day > DateTime.DaysInMonth(year, month))
            {
                day = DateTime.DaysInMonth(year, month);
            }

            return new DateTime(year, month, day);
        }

        static void InsertRandomPatient(HospitalContext dbContext, Random random, string[] digits)
        {
            DateTime randomMedicalcardDateOfIssue = GenerateRandomDate(2025, 2036, 12, 29, random);
            string formattedMedicalCardDateOfIssue = randomMedicalcardDateOfIssue.ToString("dd.MM.yyyy");

            MedicalCard medicalCard = new()
            {
                MedicalCardNumber = GenerateRandomNumber(7, random, digits),
                MedicalCardDateOfIssue = formattedMedicalCardDateOfIssue,
            };
            dbContext.MedicalCards.Add(medicalCard);
            dbContext.SaveChanges();
            Console.WriteLine($"Inserted new medical card");

            DateTime randomInsuranceExpiringDate = GenerateRandomDate(2025, 2036, 12, 29, random);
            string formattedInsuranceExpiringDate = randomInsuranceExpiringDate.ToString("dd.MM.yyyy");

            Insurance insurance = new()
            {
                InsuranceNumber = GenerateRandomNumber(16, random, digits),
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

            string randomEmailDomain = random.Next(2) == 0 ? "@gmail.com" : (random.Next(2) == 0 ? "@yandex.com" : "@mail.ru");
            int randomEmailLength = random.Next(5, 15);
            string randomEmailLocalPart = new(Enumerable.Repeat('a', randomEmailLength).Select(c => (char)random.Next(97, 123)).ToArray());
            string randomEmail = randomEmailLocalPart + randomEmailDomain;

            DateTime randomLastAppointment = GenerateRandomDate(2023, 2023, 12, 29, random);
            string formattedLastAppointment = randomLastAppointment.ToString("dd.MM.yyyy");

            DateTime randomNextAppointment = new(1900, 01, 01);
            while (randomLastAppointment > randomNextAppointment)
            {
                randomNextAppointment = GenerateRandomDate(2025, 2025, 12, 29, random);
            }
            string formattedNextAppointment = randomNextAppointment.ToString("dd.MM.yyyy");

            MedicalCard? existingMedicalCard = dbContext.MedicalCards.FirstOrDefault(mc => mc.MedicalCardNumber == medicalCard.MedicalCardNumber);

            if (existingMedicalCard != null)
            {
                Insurance? existingInsurance = dbContext.Insurances.FirstOrDefault(i => i.InsuranceNumber == insurance.InsuranceNumber);

                if (existingInsurance != null)
                {
                    Patient? existingPatient = dbContext.Patients.FirstOrDefault(p => p.Passport == randomPassport);

                    if (existingPatient == null)
                    {
                        Patient newPatient = new()
                        {
                            FirstName = randomFirstName,
                            LastName = randomLastName,
                            Patronymic = randomPatronymic,
                            Passport = randomPassport,
                            Birthdate = formattedBirthdate,
                            Gender = randomGender,
                            Country = "Russia",
                            City = cities[random.Next(cities.Length)],
                            Street = streets[random.Next(streets.Length)],
                            House = random.Next(1, 100),
                            Apartment = random.Next(1, 100),
                            PhoneNumber = "+" + "7" + GenerateRandomNumber(9, random, digits),
                            Email = randomEmail,
                            MedicalCardNumber = medicalCard.MedicalCardNumber,
                            LastAppointment = formattedLastAppointment,
                            NextAppointment = formattedNextAppointment,
                            InsuranceNumber = insurance.InsuranceNumber,
                            Diagnosis = diagnosises[random.Next(diagnosises.Length)],
                            MedicalHistory = medicalHistories[random.Next(medicalHistories.Length)],
                        };

                        dbContext.Patients.Add(newPatient);
                        dbContext.SaveChanges();
                        Console.WriteLine($"Inserted new patient with id {newPatient.PatientId}");
                    }
                    else
                    {
                        Console.WriteLine($"A patient with passport number {randomPassport} already exists.");
                    }
                }
                else
                {
                    Console.WriteLine($"An insurance with number {insurance.InsuranceNumber} does not exist.");
                }
            }
            else
            {
                Console.WriteLine($"A medical card with number {medicalCard.MedicalCardNumber} does not exist.");
            }
        }

        static void InsertRandomProcedure(HospitalContext dbContext, Random random)
        {
            int randomPatientId = random.Next(1, dbContext.Patients.Count() + 1);
            Patient? randomPatient = dbContext.Patients.FirstOrDefault(p => p.PatientId == randomPatientId);

            DateTime randomProcedureDate = GenerateRandomDate(2022, 2024, 12, 29, random);
            string formattedProcedureDate = randomProcedureDate.ToString("dd.MM.yyyy");

            int randomDoctorId = random.Next(1, 11);
            Doctor? randomDoctor = dbContext.Doctors.FirstOrDefault(d => d.DoctorId == randomDoctorId);

            int randomProcedureNameId = random.Next(1, 11);
            MedicalProceduresName? randomProcedureName = dbContext.MedicalProceduresNames.FirstOrDefault(mpn => mpn.ProcedureNameId == randomProcedureNameId);

            if (randomPatient != null)
            {
                if (randomDoctor != null)
                {
                    if (randomProcedureName != null)
                    {
                        MedicalProcedure newProcedure = new()
                        {
                            PatientId = randomPatientId,
                            ProcedureDate = formattedProcedureDate,
                            DoctorId = randomDoctorId,
                            ProcedureNameId = randomProcedureNameId,
                            ProcedureResults = results[random.Next(results.Length)],
                            ProcedureRecommendations = recommendations[random.Next(recommendations.Length)]
                        };

                        dbContext.MedicalProcedures.Add(newProcedure);
                        dbContext.SaveChanges();
                        Console.WriteLine($"Inserted new procedure with id {newProcedure.ProcedureId}");
                    }
                    else
                    {
                        Console.WriteLine("A required Patient entity does not exist.");
                    }
                }
                else
                {
                    Console.WriteLine("A required Doctor entity does not exist.");
                }
            }
            else
            {
                Console.WriteLine("A required Procedure entity does not exist.");
            }
        }

        static void InsertRandomHospitalization(HospitalContext dbContext, Random random)
        {
            string[] hospitalizationTypes = { "Planned", "Emergency", "Elective" };

            DateTime randomHospitalizationDate = GenerateRandomDate(2022, 2024, 12, 29, random);
            string formattedHospitalizationDate = randomHospitalizationDate.ToString("dd.MM.yyyy");

            int randomProcedureId = random.Next(1, dbContext.MedicalProcedures.Count() + 1);
            MedicalProcedure? randomProcedure = dbContext.MedicalProcedures.FirstOrDefault(p => p.ProcedureId == randomProcedureId);

            int patientId = (int)randomProcedure.PatientId;

            if (randomProcedure != null)
            {
                Hospitalization newHospitalization = new()
                {
                    PatientId = patientId,
                    HospitalizationDate = formattedHospitalizationDate,
                    HospitalizationType = hospitalizationTypes[random.Next(hospitalizationTypes.Length)],
                    ProcedureId = randomProcedureId,
                    HospitalizationResults = results[random.Next(results.Length)],
                    HospitalizationRecommendations = recommendations[random.Next(recommendations.Length)]
                };

                dbContext.Hospitalizations.Add(newHospitalization);
                dbContext.SaveChanges();
                Console.WriteLine($"Inserted new hospitalization with id {newHospitalization.HospitalizationId}");
            }
            else
            {
                Console.WriteLine("A required Procedure entity does not exist.");
            }
        }

        static void Main(string[] args)
        {
            Random random = new();
            string[] digits = Enumerable.Range(0, 10).Select(i => i.ToString()).ToArray();

            using (HospitalContext dbContext = new())
            {
                while (dbContext.Patients.Count() != 100)
                {
                    InsertRandomPatient(dbContext, random, digits);
                    Console.WriteLine();
                }
                dbContext.SaveChanges();

                while (dbContext.MedicalProcedures.Count() != 150)
                {
                    InsertRandomProcedure(dbContext, random);
                    Console.WriteLine();
                }
                dbContext.SaveChanges();

                while (dbContext.Hospitalizations.Count() != 100)
                {
                    InsertRandomHospitalization(dbContext, random);
                    Console.WriteLine();
                }
                dbContext.SaveChanges();
            }
        }
    }
}
