using EMS.Models;
using EMS.Repository.Interfaces;
using EMS.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EMS.UI.Controllers
{
    public class AdminController : Controller
    {
        private readonly IGenericRepo<Branch> _branchRepo;
        private readonly IGenericRepo<Department> _departmentRepo;
        private readonly IAdminRepo _adminRepo;
        public AdminController(IGenericRepo<Branch> branchRepo, IGenericRepo<Department> departmentRepo, IAdminRepo adminRepo)
        {
            _branchRepo = branchRepo;
            _departmentRepo = departmentRepo;
            _adminRepo = adminRepo;
        }

        public async Task<IActionResult> Index()
        {
            var vm = new List<EmployeeViewModel>();
            var employees = await _adminRepo.GetAll();
            foreach (var employee in employees)
            {
                vm.Add(new EmployeeViewModel { Id = employee.Id, Name = employee.Name, Contact = employee.Contact, Email = employee.Email, Address = employee.Address, EmpBranch = employee.Branch, EmpDepartment = employee.Department, RegisterDate = employee.RegisterDate, DbPath = employee.PhotoURL });
            }
            return View(vm);
        }

        public async Task<IActionResult> ApplicationList()
        {
            var vm = new List<LeaveApplicationListViewModel>();
            var applications = await _adminRepo.GetAllApplications();
            foreach (var app in applications)
            {
                vm.Add(new LeaveApplicationListViewModel { Id = app.Id, EmployeeName = app.Employee.Name, BranchName = app.Employee.Branch, DeptName = app.Employee.Department, Category = app.Category, FromDate = app.FromDate, ToDate = app.ToDate, Description = app.Description, ApplicationDate = app.ApplicationDate, EmployeeId = app.EmployeeId, Status = app.Status });
            }
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var app = await _adminRepo.GetById(id);
            var vm = new LeaveApplicationListViewModel
            {
                Id = app.Id,
                EmployeeName = app.Employee.Name,
                BranchName = app.Employee.Branch,
                DeptName = app.Employee.Department,
                Category = app.Category,
                FromDate = app.FromDate,
                ToDate = app.ToDate,
                Description = app.Description,
                EmployeeId = app.Employee.Id,
                ApplicationDate = app.ApplicationDate,
                Status = app.Status
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> ApproveApp(LeaveApplicationListViewModel vm)
        {
            var app = new LeaveApplication
            {
                Id = vm.Id,


            };
            await _adminRepo.UpdateApplication(app.Id, "Approved");
            return RedirectToAction("ApplicationList");

        }

        public async Task<IActionResult> RejectApp(LeaveApplicationListViewModel vm)
        {
            var app = new LeaveApplication
            {
                Id = vm.Id,


            };
            await _adminRepo.UpdateApplication(app.Id, "Rajected");
            return RedirectToAction("ApplicationList");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(AdminLoginViewModel vm)
        {
            if (vm.UserName == "admin" && vm.Password == "admin")
            {
                HttpContext.Session.SetString("Admin", "True");
                return RedirectToAction("BranchList");
            }
            else
            {
                ViewData["Message"] = "Invalid Login";
                return View();
            }

        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        public async Task<IActionResult>  BranchList()
        {
            var branches = await _branchRepo.GetAll();
            var vm = new List<BranchViewModel>();
            foreach (var branch in branches)
            {
                vm.Add(new BranchViewModel { Id=branch.Id,BranchName=branch.BranchName,BranchHead=branch.BranchHead,Address=branch.Address });
            }

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> CreateBranch()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBranch(BranchViewModel vm)
        {
            var branch = new Branch
            {
                BranchName = vm.BranchName,
                BranchHead = vm.BranchHead,
                Address = vm.Address


            };
            await _branchRepo.Save(branch);
            TempData["Message"] = "True";
            return RedirectToAction("BranchList");
        }

        [HttpGet]
        public async Task<IActionResult> EditBranch(int id)
        {
            var branch = await _branchRepo.GetById(id);
            var vm = new BranchViewModel { Id = branch.Id, BranchName = branch.BranchName, BranchHead = branch.BranchHead, Address = branch.Address };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> EditBranch(BranchViewModel vm)
        {
            var branch = new Branch
            {
                Id = vm.Id,
                BranchName = vm.BranchName,
                BranchHead = vm.BranchHead,
                Address = vm.Address,
            };

            await _branchRepo.Edit(branch);
            return RedirectToAction("BranchList");


        }

        public async Task<IActionResult> DeleteBranch(BranchViewModel vm)
        {
            var branch = new Branch
            {
                Id = vm.Id,
                BranchName = vm.BranchName,
                BranchHead = vm.BranchHead,
                Address = vm.Address,
            };
            await _branchRepo.RemoveData(branch);
            return RedirectToAction("BranchList");
        }

        public async Task<IActionResult> DeptList()
        {
            var departments = await _departmentRepo.GetAll();
            var vm = new List<DepartmentViewModel>();
            foreach (var department in departments)
            {
                vm.Add(new DepartmentViewModel { Id = department.Id, Name = department.Name });
            }
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> CreateDept()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateDept(DepartmentViewModel vm)
        {
            var dept = new Department
            {
                Id = vm.Id,
                Name = vm.Name,

            };

            await _departmentRepo.Save(dept);
            return RedirectToAction("DeptList");


        }

        [HttpGet]
        public async Task<IActionResult> EditDept(int id)
        {
            var dept = await _departmentRepo.GetById(id);
            var vm = new DepartmentViewModel { Id = dept.Id, Name = dept.Name };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> EditDept(DepartmentViewModel vm)
        {
            var dept = new Department
            {
                Id = vm.Id,
                Name = vm.Name,

            };

            await _departmentRepo.Edit(dept);
            return RedirectToAction("DeptList");


        }

        public async Task<IActionResult> DeleteDept(DepartmentViewModel vm)
        {
            var dept = new Department
            {
                Id = vm.Id,
                Name = vm.Name,
            };
            await _departmentRepo.RemoveData(dept);
            return RedirectToAction("DeptList");
        }

       


    }
}
