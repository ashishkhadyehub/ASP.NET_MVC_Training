using EBS.Entities;
using EBS.Repository.Interfaces;
using EBS.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EBS.UI.Controllers
{
    public class PlannerController : Controller
    {
        private readonly IPlannerRepo _plannerRepo;
        private readonly IUtilityRepo _utilityRepo;

        public PlannerController(IPlannerRepo plannerRepo, IUtilityRepo utilityRepo)
        {
            _plannerRepo = plannerRepo;
            _utilityRepo = utilityRepo;
        }

        public async Task<IActionResult> Index()
        {

            List<PlannerViewModel> vm = new List<PlannerViewModel>();
            var planners = await _plannerRepo.GetAll();
            foreach (var planner in planners)
            {
                vm.Add(new PlannerViewModel { Id = planner.Id, Name = planner.Name, Description = planner.Description, ImageUrl = planner.ImageUrl });
            }
            return View(vm);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePlannerViewModel vm)
        {
            var planner = new EventPlanner
            {
                Name = vm.Name,
                Description = vm.Description,

            };
            if (vm.ImageUrl != null)
            {
                planner.ImageUrl = await _utilityRepo.SaveImage("PlannerLogos", vm.ImageUrl);
            }
            await _plannerRepo.Save(planner);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var planner = await _plannerRepo.GetById(id);
            EditPlannerViewModel vm = new EditPlannerViewModel { Id = planner.Id, Name = planner.Name, Description = planner.Description, ImageUrl = planner.ImageUrl };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditPlannerViewModel vm)
        {
            var planner = new EventPlanner
            {
                Id = vm.Id,
                Name = vm.Name,
                Description = vm.Description,


            };
            if (vm.ChooseImage != null)
            {
                planner.ImageUrl = await _utilityRepo.EditImage("PlannerLogos", vm.ChooseImage, vm.ImageUrl);
            }
            await _plannerRepo.Edit(planner);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Delete(int id)
        {
            var planner = await _plannerRepo.GetById(id);
            await _plannerRepo.RemoveData(planner);
            return RedirectToAction("Index");
        }
    }
}
