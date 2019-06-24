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
        private IScheduleRepository dbSchedule;
        public HomeController(IUserRepository dbUser,IChildRepository dbChild,ITaskRepository dbTask,
            ITaskForDateRepository dbtaskToday, IScheduleRepository dbSchedule)
        {
            this.dbUser = dbUser;
            this.dbChild = dbChild;
            this.dbTask = dbTask;
            this.dbtaskToday = dbtaskToday;
            this.dbSchedule = dbSchedule;
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

        [HttpGet]
        public IActionResult GetSchedule()
        {
            return View(dbChild
                    .GetUserChilds(
                        dbUser
                        .GetUserId(User.Identity.Name)));
        }

        [HttpPost]
        public IActionResult GetScheduleTable(int childId, DateTime startdate, DateTime endate)
        {
            var a = dbSchedule.GetTable(childId, startdate, endate);
            for (int i = 0; i < a[0].Count; i++)
            {
                a[0][i] = a[0][i].Split(' ')[0];
            }
            return View(a);
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

        public IActionResult SendToDone(int taskId)
        {
            dbtaskToday.SentToDone(taskId);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult SendToMissed(int taskId)
        {
            dbtaskToday.SentToMissed(taskId);
            return RedirectToAction("Index", "Home");
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
