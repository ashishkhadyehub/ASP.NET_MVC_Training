using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Training.Models;
using Training.Repositories.Interfaces;
using Training.UI.ViewModels.DistrictViewModel;

namespace Training.UI.Controllers
{
    public class DistrictController : Controller
    {
        private readonly IDistrictRepo _districtRepo;
        private readonly IStateRepo _stateRepo;

        public DistrictController(IDistrictRepo districtRepo, IStateRepo stateRepo)
        {
            _districtRepo = districtRepo;
            _stateRepo = stateRepo;
        }

        public async Task<IActionResult> Index()
        {
            List<DistrictViewModel> vm = new List<DistrictViewModel>();
            var districts = await _districtRepo.GetAll();
            foreach (var district in districts)
            {
                vm.Add(new DistrictViewModel { Id=district.Id,DistrictName=district.Name,StateName=district.State.Name,CountryName=district.State.Country.Name});
            }
            return View(vm);
        }
        [HttpGet]
        public async Task<IActionResult>  Create()
        {
            var states = await _stateRepo.GetAll();
            ViewBag.StateList = new SelectList(states,"Id","Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateDistrictViewModel vm)
        {
            var district = new District
            {
                Name=vm.DistrictName,
                StateId=vm.StateId
            };
            await _districtRepo.Save(district);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult>  Edit(int id)
        {
            var states = await _stateRepo.GetAll();
            ViewBag.StateList = new SelectList(states,"Id","Name");
            var district = await _districtRepo.GetById(id);
            var vm = new EditDistrictViewModel
            {
                Id=district.Id,
                DistrictName=district.Name,
                StateId =district.StateId
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditDistrictViewModel vm)
        {
            var district = new District
            {
                Id = vm.Id,
                Name=vm.DistrictName,
                StateId=vm.StateId
            };
            await _districtRepo.Edit(district);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var district = await _districtRepo.GetById(id);
            var vm = new DistrictViewModel
            {
                Id = district.Id,
                DistrictName = district.Name

            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DistrictViewModel vm)
        {
            var district =  new District { Id = vm.Id,Name=vm.DistrictName };
            await _districtRepo.RemoveData(district);
            return RedirectToAction("Index");
        }

    }
}
