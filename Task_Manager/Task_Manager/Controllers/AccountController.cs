using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Task_Manager.Interfaces;
using Task_Manager.Models;

namespace Task_Manager.Controllers
{
    public class AccountController : Controller
    {
        private IAccountReposirory unitofwork;
        public AccountController(IAccountReposirory unitofwork)
        {
            this.unitofwork = unitofwork;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var user = unitofwork.GetUser(model.Login, model.Password);
            if (user==null)
            {
                ModelState.AddModelError("", "Пользователь с таким логином и паролем не найден");
            }
            if (ModelState.IsValid)
            {
                await Authenticate(user.Login); // аутентификация

                return RedirectToAction("Index", "Home");
            }
            else return View(model);

        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (unitofwork.GetLogin(model.Name))
            {
                ModelState.AddModelError("Name", "Пользователь с таким именим уже есть");
            }
            if (ModelState.IsValid)
            {
                User u = new User { Name = model.Name, Password = model.Password,Login=model.Login,Surname=model.Surname };
                unitofwork.AddUser(u);
                await Authenticate(model.Login);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        private async Task Authenticate(string userName)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}