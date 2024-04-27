using EMS.Models;
using EMS.Repository.Interfaces;
using EMS.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EMS.UI.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepo _employeeRepo;
        private readonly IUtilityRepo _utilityRepo;
        private readonly IGenericRepo<Branch> _branchRepo;
        private readonly IGenericRepo<Department> _departmentRepo;

        public EmployeeController(IEmployeeRepo employeeRepo, IUtilityRepo utilityRepo, IGenericRepo<Branch> branchRepo, IGenericRepo<Department> departmentRepo)
        {
            _employeeRepo = employeeRepo;
            _utilityRepo = utilityRepo;
            _branchRepo = branchRepo;
            _departmentRepo = departmentRepo;
        }

        public IActionResult Home()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            var branchlist = await _branchRepo.GetAll();
            ViewBag.BranchList = new SelectList(branchlist, "BranchName", "BranchName");

            var deptlist = await _departmentRepo.GetAll();
            ViewBag.DeptList = new SelectList(deptlist, "Name", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(EmployeeViewModel vm)
        {


            var employee = new Employee
            {
                Name = vm.Name,
                Contact = vm.Contact,
                Email = vm.Email,
                Address = vm.Address,
                Branch = vm.EmpBranch,
                Department = vm.EmpDepartment,
                Password = vm.Password
            };
            if (vm.PhotoURL != null)
            {
                string photoPath = await _utilityRepo.SaveImage("EmployeePhotos", vm.PhotoURL);
                employee.PhotoURL = photoPath;
                employee.RegisterDate = DateTime.Now;

            }
            await _employeeRepo.RegisterEmployee(employee);
            TempData["Message"] = "You can login now";
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel vm)
        {
            var userInfo = await _employeeRepo.GetUserInfo(vm.Email, vm.Password);
            if (userInfo != null)
            {
                HttpContext.Session.SetInt32("userId", userInfo.Id);
                HttpContext.Session.SetString("userName", userInfo.Name);
                return RedirectToAction("Profile", "Employee");
            }
            else
            {
                ViewData["Message"] = "Invalid Login";
                return View();
            }

        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        [HttpGet]
        public async Task<IActionResult> Profile()
        {

            if (HttpContext.Session.GetInt32("userId") != null)
            {
                var branchlist = await _branchRepo.GetAll();
                ViewBag.BranchList = new SelectList(branchlist, "BranchName", "BranchName");

                var deptlist = await _departmentRepo.GetAll();
                ViewBag.DeptList = new SelectList(deptlist, "Name", "Name");


                var profile = await _employeeRepo.GetById((int)HttpContext.Session.GetInt32("userId"));
                var vm = new EmployeeViewModel
                {
                    Id = profile.Id,
                    Name = profile.Name,
                    Contact = profile.Contact,
                    Email = profile.Email,
                    Address = profile.Address,
                    EmpBranch = profile.Branch,
                    EmpDepartment = profile.Department,
                    Password = profile.Password,
                    DbPath = profile.PhotoURL
                };

                return View(vm);
            }
            return RedirectToAction("Login");
        }

        [HttpPost]
        public async Task<IActionResult> Profile(EmployeeViewModel vm)
        {
            var employee = new Employee
            {
                Id = vm.Id,
                Name = vm.Name,
                Contact = vm.Contact,
                Email = vm.Email,
                Address = vm.Address,
                Branch = vm.EmpBranch,
                Department = vm.EmpDepartment,
                Password = vm.Password
            };
            if (vm.PhotoURL != null)
            {
                string photoPath = await _utilityRepo.EditImage("EmployeePhotos", vm.PhotoURL, vm.DbPath);
                employee.PhotoURL = photoPath;
                employee.RegisterDate = DateTime.Now;

            }
            else
            {
                employee.PhotoURL = vm.DbPath;
            }

            await _employeeRepo.UpdateEmployee(employee);
            return RedirectToAction("Home");
        }

        [HttpGet]
        public IActionResult Application()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Application(LeaveApplicationViewModel vm)
        {
            var application = new LeaveApplication
            {
                Category = vm.Category,
                FromDate = vm.FromDate,
                ToDate = vm.ToDate,
                Description = vm.Description,
                ApplicationDate = DateTime.Now,
                EmployeeId = (int)HttpContext.Session.GetInt32("userId"),
                Status = "Submitted"
            };

            await _employeeRepo.SubmitApplication(application);
            return RedirectToAction("Home");
        }

        public async Task<IActionResult> AppList()
        {
            var vm = new List<LeaveApplicationViewModel>();
            var apps = await _employeeRepo.GetApplications((int)HttpContext.Session.GetInt32("userId"));
            foreach (var app in apps)
            {
                vm.Add(new LeaveApplicationViewModel { Id = app.Id, Category = app.Category, FromDate = app.FromDate.Date, ToDate = app.ToDate.Date, Description = app.Description, EmployeeId = app.EmployeeId, Status = app.Status, ApplicationDate = app.ApplicationDate.Date });
            }
            return View(vm);
        }


    }
}
