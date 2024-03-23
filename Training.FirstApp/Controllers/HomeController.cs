using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Training.FirstApp.Models;


namespace Training.FirstApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //to pass int value
            //int a = 70;
            //return View(a);

            //to pass string
            //string b = "test";
            //return View("Index",b);

            //to pass Model class
            //Student student = new Student();
            //student.Id = 1;
            //student.Name = "Ram";
            //student.City = "Pune";
            //return View(student);


            List<Student> students = new List<Student>();
            students.Add(new Student{ Id=1,Name="Ram",City="Pune"});
            students.Add(new Student { Id = 2, Name = "Shree", City = "Mumbai" });
            students.Add(new Student { Id = 3, Name = "Subhash", City = "Kolkata" });
            students.Add(new Student { Id = 4, Name = "Narendra", City = "Chennai" });

            return View(students);
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
