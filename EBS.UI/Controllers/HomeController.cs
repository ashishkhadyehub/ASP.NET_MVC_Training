using EBS.Repository.Interfaces;
using EBS.UI.Models;
using EBS.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EBS.UI.Controllers
{
    public class HomeController : Controller
    {
       private readonly IEventRepo _eventRepo;

        public HomeController(IEventRepo eventRepo)
        {
            _eventRepo = eventRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> EventList()
        {
            DateTime today = DateTime.Today;
            var events = await _eventRepo.GetAll();
            var vm = events.Where(x => x.DateTime >= today).Select(x => new EventListViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Image = x.ImageUrl,
                DateTime = x.DateTime,
                Venue = x.Venue.Name,
                Planner = x.Planner.Name,
                Description = x.Description.Substring(0,100)
            }).ToList();
            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
