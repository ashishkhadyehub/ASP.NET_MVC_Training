using Microsoft.AspNetCore.Mvc;
using Training.Models;
using Training.Repositories.Interfaces;
using Training.UI.ViewModels.CountryViewModel;

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
            List<CountryViewModel> vm = new List<CountryViewModel>();
            var countries = _countryRepo.GetAll();
            foreach (var country in countries)
            {
                vm.Add(new CountryViewModel { Id=country.Id, Name=country.Name});
            }

            return View(vm);

            //var countries = _countryRepo.GetAll();
            //return View(countries);
        }

        [HttpGet]
        public IActionResult Create()
        {
            CreateCountryViewModel country = new CreateCountryViewModel();
            
            return View(country);
        }

        [HttpPost]

        public  IActionResult Create(CreateCountryViewModel vm)
        {
            //var co = new Country();
            //co.Name= vm.Name; ;

            var country = new Country{Name= vm.Name};
            _countryRepo.Save(country);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var country = _countryRepo.GetById(id);
            CountryViewModel vm = new CountryViewModel { Id=country.Id, Name=country.Name};
            return View(vm);
        }

        [HttpPost]

        public IActionResult Edit(CountryViewModel vm)
        {
            var country = new Country { Id = vm.Id, Name = vm.Name };
            _countryRepo.Edit(country);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var country = _countryRepo.GetById(id);
            CountryViewModel vm = new CountryViewModel { Id= country.Id, Name=country.Name};    
            return View(vm);
        }

        [HttpPost]
        public IActionResult Delete(CountryViewModel vm)
        {
            var country = new Country { Id= vm.Id, Name=vm.Name};   
            _countryRepo.RemoveData(country);
            return RedirectToAction("Index");
        }
    }
}
