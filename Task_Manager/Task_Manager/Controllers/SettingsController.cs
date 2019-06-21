using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Task_Manager.Interfaces;
using Task_Manager.Models;

namespace Task_Manager.Controllers
{
    [Authorize]
    public class SettingsController : Controller
    {
        private IDateRepository db;
        public SettingsController(IDateRepository _db)
        {
            db = _db;
        }
        [HttpGet]
        public IActionResult AddChild()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddChild(Child child)
        {
            if (ModelState.IsValid)
            {
                db.AddChild(User.Identity.Name, new Child()
                {
                    Name = child.Name,
                    Surname = child.Surname,
                    MissedTasks = new List<TaskElement>(),
                    TaskForDates = new List<TaskForDate>(),
                    Tasks = new List<TaskType>()
                });
                return View();
            }
            return View();
        }

        [HttpGet]
        public IActionResult AddTask(int childId)
        {
            ViewData["chlildId"] = childId;
            return View();
        }
        [HttpPost]
        public IActionResult AddTask(TaskModel taskModel)
        {
            if (ModelState.IsValid)
            {
                db.AddTask(User.Identity.Name, taskModel);
                return View(ViewData["chlildId"] = taskModel.ChildId);
            }
            else ViewData["chlildId"] = taskModel.ChildId; return View(taskModel);
        }
    }
}