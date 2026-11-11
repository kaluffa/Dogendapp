using Dogendapp.Models;

namespace Dogendapp.Data
{
    public class InMemoryDataStore
    {
        public List<Dog> Dogs { get; set; } = new();
        public List<Vaccine> Vaccines { get; set; } = new();
        public List<Trophy> Trophies { get; set; } = new();
        public List<DogShow> DogShows { get; set; } = new();
        public List<Accommodation> Accommodations { get; set; } = new();

        public InMemoryDataStore()
        {
            SeedData();
        }

        private void SeedData()
        {
            var apollo = new Dog
            {
                Id = 1,
                Name = "Apollo",
                RegisteredName = "Ch. Starlight's Golden Sun",
                Breed = "Golden Retriever",
                Gender = "Male",
                MicrochipNumber = "981020000394812",
                DateOfBirth = new DateTime(2023, 4, 15)
            };

            var freya = new Dog
            {
                Id = 2,
                Name = "Freya",
                RegisteredName = "Nordic Wind's Valkyrie",
                Breed = "Siberian Husky",
                Gender = "Female",
                MicrochipNumber = "981020000511209",
                DateOfBirth = new DateTime(2024, 1, 20)
            };

            var vac1 = new Vaccine
            {
                Id = 1,
                DogId = 1,
                Dog = apollo,
                Name = "Rabies + DHPP",
                DateAdministered = new DateTime(2026, 2, 10),
                ExpirationDate = new DateTime(2027, 2, 10)
            };

            var vac2 = new Vaccine
            {
                Id = 2,
                DogId = 2,
                Dog = freya,
                Name = "Rabies + Bordetella",
                DateAdministered = new DateTime(2026, 5, 1),
                ExpirationDate = new DateTime(2027, 5, 1)
            };

            apollo.Vaccines.Add(vac1);
            freya.Vaccines.Add(vac2);
            Vaccines.AddRange(new[] { vac1, vac2 });

            var trophy1 = new Trophy
            {
                Id = 1,
                DogId = 1,
                Dog = apollo,
                Title = "Best of Breed (BOB)",
                ShowName = "Madrid Spring Classic",
                DateWon = new DateTime(2026, 5, 14),
                JudgeName = "Elena Rostova"
            };

            var trophy2 = new Trophy
            {
                Id = 2,
                DogId = 1,
                Dog = apollo,
                Title = "CACIB - International Cert",
                ShowName = "Pyrenees Cup",
                DateWon = new DateTime(2026, 8, 22),
                JudgeName = "Marcello Rossi"
            };

            var trophy3 = new Trophy
            {
                Id = 3,
                DogId = 2,
                Dog = freya,
                Title = "Best Junior in Show",
                ShowName = "Mediterranean Canine Expo",
                DateWon = new DateTime(2026, 9, 10),
                JudgeName = "Arthur Pendelton"
            };

            apollo.Trophies.AddRange(new[] { trophy1, trophy2 });
            freya.Trophies.Add(trophy3);
            Trophies.AddRange(new[] { trophy1, trophy2, trophy3 });

            Dogs.AddRange(new[] { apollo, freya });

            DogShows.AddRange(new[]
            {
                new DogShow
                {
                    Id = 1,
                    Name = "Barcelona International Canine Expo",
                    Location = "Fira de Barcelona, Spain",
                    StartDate = new DateTime(2026, 12, 12),
                    RegistrationDeadline = new DateTime(2026, 11, 28),
                    MainJudge = "Dr. Hans Von Berg",
                    Category = "International (CACIB)",
                    EntryFee = 55.00m,
                    IsUserRegistered = true
                },
                new DogShow
                {
                    Id = 2,
                    Name = "Winter Iberian Championship",
                    Location = "Valencia, Spain",
                    StartDate = new DateTime(2027, 1, 18),
                    RegistrationDeadline = new DateTime(2026, 12, 30),
                    MainJudge = "Claire Dubois",
                    Category = "Championship",
                    EntryFee = 45.00m,
                    IsUserRegistered = false
                },
                new DogShow
                {
                    Id = 3,
                    Name = "Southern Europe Working & Pastoral Cup",
                    Location = "Lyon, France",
                    StartDate = new DateTime(2027, 2, 14),
                    RegistrationDeadline = new DateTime(2027, 1, 25),
                    MainJudge = "Kenneth O'Connor",
                    Category = "National",
                    EntryFee = 40.00m,
                    IsUserRegistered = false
                }
            });

            Accommodations.Add(new Accommodation
            {
                Id = 1,
                HotelName = "Hotel Porta Fira (Pet Friendly Suite)",
                ShowName = "Barcelona International Canine Expo",
                CheckIn = new DateTime(2026, 12, 11),
                CheckOut = new DateTime(2026, 12, 14),
                PetFeeIncluded = true,
                TotalCost = 340.00m
            });
        }
    }
}