using Microsoft.AspNetCore.Mvc;
using Training.Models;
using Training.Repositories.Interfaces;
using Training.UI.ViewModels.UserInfoViewModels;

namespace Training.UI.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserRepo _userRepo;

        public AuthController(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserInfoViewModel vm)
        {
            var user = new UserInfo { UserName = vm.UserName,Password=vm.Password};
            await _userRepo.RegisterUser(user);
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserInfoViewModel vm)
        {
            var userInfo = await _userRepo.GetUserInfo(vm.UserName,vm.Password);
            HttpContext.Session.SetInt32("userId",userInfo.UserId);
            HttpContext.Session.SetString("userName",userInfo.UserName);
            return RedirectToAction("Index","Country");
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
