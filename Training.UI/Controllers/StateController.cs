using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Training.Models;
using Training.Repositories.Interfaces;
using Training.UI.ViewModels.StateViewModels;

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

        public async Task<IActionResult> Index()
        {
            var vm = new List<StateViewModel>();
            var states = await _stateRepo.GetAll();
            foreach (var state in states)
            {
                vm.Add(new StateViewModel {Id=state.Id,StateName=state.Name,CountryName=state.Country.Name });
            }
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var countries = await _countryRepo.GetAll();
            ViewBag.CountryList = new SelectList(countries, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateStateViewModel vm)
        {
            var state = new State
            {
                Name=vm.StateName,
                CountryId=vm.CountryId
            };
            await _stateRepo.Save(state);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult>  Edit(int id)
        {
            var countries = await _countryRepo.GetAll();
            ViewBag.CountryList = new SelectList(countries,"Id","Name");
            var state = await _stateRepo.GetById(id);
            var vm = new EditStateViewModel
            {
                Id=state.Id,
                StateName=state.Name,
                CountryId=state.CountryId,
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult>  Edit(EditStateViewModel vm)
        {
            var state = new State
            {
                Id=vm.Id,
                Name=vm.StateName,
                CountryId=vm.CountryId

            };
            await _stateRepo.Edit(state);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult>  Delete(int id)
        {
            var state = await _stateRepo.GetById(id);
            var vm = new StateViewModel
            {
                Id = state.Id,
                StateName = state.Name
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult>  Delete(StateViewModel vm)
        {
            var state = new State { Id = vm.Id,Name=vm.StateName };
            await _stateRepo.RemoveData(state);
            return RedirectToAction("Index");
        }


    }
}
