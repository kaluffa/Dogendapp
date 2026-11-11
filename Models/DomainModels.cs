using System.ComponentModel.DataAnnotations;

namespace Dogendapp.Models
{
    public class Dog
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; } = string.Empty;
        public string RegisteredName { get; set; } = string.Empty;
        public string Breed { get; set; } = string.Empty;
        public string MicrochipNumber { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } = "Male";

        public List<Vaccine> Vaccines { get; set; } = new();
        public List<Trophy> Trophies { get; set; } = new();
    }

    public class Vaccine
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime DateAdministered { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int DogId { get; set; }
        public Dog? Dog { get; set; }
    }

    public class Trophy
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty; // e.g., "Best in Show", "CACIB"
        public string ShowName { get; set; } = string.Empty;
        public DateTime DateWon { get; set; }
        public string JudgeName { get; set; } = string.Empty;
        public int DogId { get; set; }
        public Dog? Dog { get; set; }
    }

    public class DogShow
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime RegistrationDeadline { get; set; }
        public string MainJudge { get; set; } = string.Empty;
        public string Category { get; set; } = "National"; // National, International, Championship
        public decimal EntryFee { get; set; }
        public bool IsUserRegistered { get; set; }
    }

    public class Accommodation
    {
        public int Id { get; set; }
        public string HotelName { get; set; } = string.Empty;
        public string ShowName { get; set; } = string.Empty;
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public bool PetFeeIncluded { get; set; }
        public decimal TotalCost { get; set; }
    }

    public class DashboardViewModel
    {
        public List<Dog> Dogs { get; set; } = new();
        public List<DogShow> Shows { get; set; } = new();
        public List<Trophy> RecentTrophies { get; set; } = new();
        public List<Accommodation> Accommodations { get; set; } = new();
    }
}