using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Training.Models;
using Training.Repositories.Interfaces;

namespace Training.UI.Controllers
{
    public class StateController : Controller
    {
        private readonly ICountryRepo _countryRepo;
        private readonly IStateRepo _stateRepo;

        public StateController(ICountryRepo countryRepo, IStateRepo stateRepo)
        {
            _countryRepo = countryRepo;
            _stateRepo = stateRepo;
        }

        public IActionResult Index()
        {
            var states = _stateRepo.GetAll();
            return View(states);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var countries = _countryRepo.GetAll();
            ViewBag.CountryList = new SelectList(countries, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(State state)
        {
            _stateRepo.Save(state);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var countries = _countryRepo.GetAll();
            ViewBag.CountryList = new SelectList(countries,"Id","Name");
            var state = _stateRepo.GetById(id);
            return View(state);
        }

        [HttpPost]
        public IActionResult Edit(State state)
        {
            _stateRepo.Edit(state);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var state = _stateRepo.GetById(id);
            return View(state);
        }

        [HttpPost]
        public IActionResult Delete(State state)
        {
            _stateRepo.RemoveData(state);
            return RedirectToAction("Index");
        }


    }
}
