using Microsoft.AspNetCore.Mvc;

namespace Training.UI.Controllers
{
    public class ConceptsController : Controller
    {
        public IActionResult Index()
        {

            //ViewBag.Message = "This data is coming from Viewbag";

            //ViewData["Message"] = "This data is coming from Viewdata";

            TempData["Message"] = "This data is coming from Tempdata";
            return View();
        }

        public IActionResult NextPage()
        {

            string tempdata = TempData["Message"].ToString();
            return View("NextPage", tempdata);
        }
    }
}
