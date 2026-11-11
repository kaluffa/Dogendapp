using Microsoft.AspNetCore.Mvc;
using Dogendapp.Data;
using Dogendapp.Models;

namespace Dogendapp.Controllers
{
    public class DashboardController : Controller
    {
        private readonly InMemoryDataStore _store;

        public DashboardController(InMemoryDataStore store)
        {
            _store = store;
        }

        public IActionResult Index()
        {
            var viewModel = new DashboardViewModel
            {
                Dogs = _store.Dogs,
                Shows = _store.DogShows.OrderBy(s => s.StartDate).ToList(),
                RecentTrophies = _store.Trophies.OrderByDescending(t => t.DateWon).ToList(),
                Accommodations = _store.Accommodations.OrderBy(a => a.CheckIn).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddDog(Dog dog, string InitialVaccineName, DateTime? VaccineExpDate)
        {
            if (ModelState.IsValid)
            {
                dog.Id = _store.Dogs.Any() ? _store.Dogs.Max(d => d.Id) + 1 : 1;

                if (!string.IsNullOrWhiteSpace(InitialVaccineName) && VaccineExpDate.HasValue)
                {
                    var vaccine = new Vaccine
                    {
                        Id = _store.Vaccines.Any() ? _store.Vaccines.Max(v => v.Id) + 1 : 1,
                        DogId = dog.Id,
                        Dog = dog,
                        Name = InitialVaccineName,
                        DateAdministered = DateTime.Today,
                        ExpirationDate = VaccineExpDate.Value
                    };
                    dog.Vaccines.Add(vaccine);
                    _store.Vaccines.Add(vaccine);
                }

                _store.Dogs.Add(dog);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult AddShow(DogShow show)
        {
            if (ModelState.IsValid)
            {
                show.Id = _store.DogShows.Any() ? _store.DogShows.Max(s => s.Id) + 1 : 1;
                _store.DogShows.Add(show);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult AddTrophy(Trophy trophy)
        {
            if (ModelState.IsValid)
            {
                trophy.Id = _store.Trophies.Any() ? _store.Trophies.Max(t => t.Id) + 1 : 1;
                var dog = _store.Dogs.FirstOrDefault(d => d.Id == trophy.DogId);
                if (dog != null)
                {
                    trophy.Dog = dog;
                    dog.Trophies.Add(trophy);
                }
                _store.Trophies.Add(trophy);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult AddAccommodation(Accommodation accommodation)
        {
            if (ModelState.IsValid)
            {
                accommodation.Id = _store.Accommodations.Any() ? _store.Accommodations.Max(a => a.Id) + 1 : 1;
                _store.Accommodations.Add(accommodation);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult ToggleShowRegistration(int id)
        {
            var show = _store.DogShows.FirstOrDefault(s => s.Id == id);
            if (show != null)
            {
                show.IsUserRegistered = !show.IsUserRegistered;
            }
            return RedirectToAction(nameof(Index));
        }
    }
}