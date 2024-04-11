using Microsoft.AspNetCore.Mvc;
using Training.Models;
using Training.Repositories.Interfaces;

namespace Training.UI.Controllers
{
    public class CountryController : Controller
    {
        private readonly ICountryRepo _countryRepo;

        public CountryController(ICountryRepo countryRepo)
        {
            _countryRepo = countryRepo;
        }

        public IActionResult Index()
        {
            var countries = _countryRepo.GetAll();
            return View(countries); 
        }

        [HttpGet]
        public IActionResult Create()
        {
            Country country = new Country();
            country.Name = "";
            return View(country);
        }

        [HttpPost]

        public  IActionResult Create(Country country)
        {
            _countryRepo.Save(country);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var country = _countryRepo.GetById(id);
            return View(country);
        }

        [HttpPost]

        public IActionResult Edit(Country country)
        {
            _countryRepo.Edit(country);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var country = _countryRepo.GetById(id);
            return View(country);
        }

        [HttpPost]
        public IActionResult Delete(Country country)
        {
            _countryRepo.RemoveData(country);
            return RedirectToAction("Index");
        }
    }
}
