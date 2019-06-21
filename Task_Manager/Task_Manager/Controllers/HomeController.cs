using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Task_Manager.Interfaces;
using Task_Manager.Models;

namespace Task_Manager.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public IDateRepository db;
        public HomeController(IDateRepository _db)
        {
            db = _db;
        }      


        public IActionResult Index()
        {           
            db.UpdateUserDate(User.Identity.Name);
            ViewData["list"]= db.GetTodayTasks(User.Identity.Name);
            return View();
        }

        public IActionResult Settings()
        {
            ViewData["list"] = db.GetChilds(User.Identity.Name);
            return View();
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
