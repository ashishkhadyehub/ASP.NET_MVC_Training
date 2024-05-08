using EBS.Entities;
using EBS.Repository.Interfaces;
using EBS.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EBS.UI.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventRepo _eventRepo;
        private readonly IVenueRepo _venueRepo;
        private readonly IPlannerRepo _plannerRepo;
        private readonly IUtilityRepo _utilityRepo;

        public EventController(IEventRepo eventRepo, IVenueRepo venueRepo, IPlannerRepo plannerRepo, IUtilityRepo utilityRepo)
        {
            _eventRepo = eventRepo;
            _venueRepo = venueRepo;
            _plannerRepo = plannerRepo;
            _utilityRepo = utilityRepo;
        }

        public async Task<IActionResult> Index()
        {
            var events = await _eventRepo.GetAll();
            var vm = new List<EventViewModel>();
            foreach (var eventvar in events)
            {
                vm.Add(new EventViewModel { Id = eventvar.Id, Name = eventvar.Name, DateTime = eventvar.DateTime, Planner = eventvar.Planner.Name, Venue = eventvar.Venue.Name });
            }

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var planners = await _plannerRepo.GetAll();
            var venues = await _venueRepo.GetAll();
            ViewBag.PlannerList = new SelectList(planners, "Id", "Name");
            ViewBag.VenueList = new SelectList(venues, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEventViewModel vm)
        {
            var eventvar = new Event
            {
                Name = vm.Name,
                Description = vm.Description,
                DateTime = vm.DateTime,
                VenueId = vm.VenueId,
                PlannerId = vm.PlannerId,
            };
            if (vm.ImageUrl != null)
            {
                eventvar.ImageUrl = await _utilityRepo.SaveImage("EventImages", vm.ImageUrl);
            }
            await _eventRepo.Save(eventvar);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var planners = await _plannerRepo.GetAll();
            var venues = await _venueRepo.GetAll();
            ViewBag.PlannerList = new SelectList(planners, "Id", "Name");
            ViewBag.VenueList = new SelectList(venues, "Id", "Name");


            var eventvar = await _eventRepo.GetById(id);
            var vm = new EditEventViewModel
            {
                Id = eventvar.Id,
                Name = eventvar.Name,
                Description = eventvar.Description,
                ImageUrl = eventvar.ImageUrl,
                DateTime = eventvar.DateTime,
                VenueId = eventvar.VenueId,
                PlannerId = eventvar.PlannerId,
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditEventViewModel vm)
        {
            var eventvar = new Event
            {
                Id = vm.Id,
                Name = vm.Name,
                Description = vm.Description,
                DateTime = vm.DateTime,
                PlannerId = vm.PlannerId,
                VenueId = vm.VenueId,
            };
            if (vm.ChooseFile != null)
            {
                eventvar.ImageUrl = await _utilityRepo.EditImage("EventImages", vm.ChooseFile, vm.ImageUrl);
            }
            else
            {
                eventvar.ImageUrl=vm.ImageUrl;
            }
            await _eventRepo.Edit(eventvar);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Delete(int id)
        {
            var eventvar = await _eventRepo.GetById(id);
            await _eventRepo.RemoveData(eventvar);
            return RedirectToAction("Index");
        }


    }
}
