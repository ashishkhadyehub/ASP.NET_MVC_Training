using Microsoft.AspNetCore.Mvc;

namespace Training.FirstApp.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult History()
        {
            return View();
        }

    }
}
