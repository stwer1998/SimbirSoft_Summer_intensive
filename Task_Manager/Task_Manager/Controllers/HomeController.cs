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
        private IUserRepository dbUser;
        private IChildRepository dbChild;
        private ITaskRepository dbTask;

        public HomeController(IUserRepository dbUser,IChildRepository dbChild,ITaskRepository dbTask)
        {
            this.dbUser = dbUser;
            this.dbChild = dbChild;
            this.dbTask = dbTask;
        }      


        public IActionResult Index()
        {          
            return View();
        }

        public IActionResult Settings()
        {
            DtoModelSetings model = new DtoModelSetings();
            model.UserId = dbUser.GetUserId(User.Identity.Name);
            model.Childs = new List<DtoModelChild>();
            var childs= dbChild.GetUserChilds(model.UserId);
            foreach (var item in childs)
            {
                model.Childs.Add(new DtoModelChild()
                {
                    ChildId=item.ChildId,
                    ChildName=item.Name,
                    ChildSurName=item.Surname,
                    taskElements=dbTask.GetChildTaskElements(item.ChildId)
                });
            }

            return View(model);
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
