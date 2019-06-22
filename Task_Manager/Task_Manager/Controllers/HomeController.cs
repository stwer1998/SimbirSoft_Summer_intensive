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
        private ITaskForDateRepository dbtaskToday;
        public HomeController(IUserRepository dbUser,IChildRepository dbChild,ITaskRepository dbTask, ITaskForDateRepository dbtaskToday)
        {
            this.dbUser = dbUser;
            this.dbChild = dbChild;
            this.dbTask = dbTask;
            this.dbtaskToday = dbtaskToday;
        }      


        public IActionResult Index()
        {
            var model = new DtoForIndex
            {
                Childs = new List<Child>(),
                TasksToday = new Dictionary<Child, List<TaskForDate>>()
            };
            model.Childs.AddRange(
                    dbChild
                    .GetUserChilds(
                        dbUser
                        .GetUserId(User.Identity.Name)));
            foreach (var child in model.Childs)
            {
                dbtaskToday.UpdeteScheduleChild(child.ChildId);
                model.TasksToday.Add(child,new List<TaskForDate>());
                model.TasksToday[child].AddRange(dbtaskToday.GetTodayTaskForUser(child.ChildId));
            }
           
            
            return View(model);
        }

        public IActionResult Settings()
        {
            DtoModelSetings model = new DtoModelSetings
            {
                UserId = dbUser.GetUserId(User.Identity.Name),
                Childs = new List<DtoModelChild>()
            };
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
