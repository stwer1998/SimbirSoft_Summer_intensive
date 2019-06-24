using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Task_Manager.Interfaces;
using Task_Manager.Models;

namespace Task_Manager.Controllers
{
    [Authorize]
    public class SettingsController : Controller
    {
        private IChildRepository dbChild;
        private IUserRepository dbuser;
        private ITaskRepository dbTask;
        public SettingsController(IChildRepository dbChild, IUserRepository dbuser,ITaskRepository dbTask)
        {
            this.dbChild = dbChild;
            this.dbuser = dbuser;
            this.dbTask = dbTask;
        }
        [HttpGet]
        public IActionResult AddChild()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddChild(Child child)
        {
            if (!dbChild.GetNameSurnameChild(dbuser.GetUserId(User.Identity.Name), child))
            {
                ModelState.AddModelError("Name", "У вас уже есть ребёнок с такими параметрами");
            }
            if (ModelState.IsValid)
            {
                dbChild.AddChild(new Child()
                {
                    Name = child.Name,
                    Surname = child.Surname,
                    RegisterDate = DateTime.Now.Date,
                    UpdateDate = DateTime.Now.Date.AddDays(-1),
                    UserId = dbuser.GetUserId(User.Identity.Name)
                });
                return RedirectToAction("Settings", "Home");
            }
            return View(child);
        }

       
        

        [HttpGet]
        public IActionResult DeleteChild(int childId)
        {
            dbChild.DeleteChild(dbuser.GetUserId(User.Identity.Name),childId);
            return RedirectToAction("Settings", "Home");
        }

        [HttpGet]
        public IActionResult EditChild(int childId)
        {
            return View(dbChild.GetChild(childId));
        }

        [HttpPost]
        public IActionResult EditChild(int ChildId1, Child child)
        {
            if (ModelState.IsValid)
            {
                dbChild.EditChild(ChildId1, child);
                return RedirectToAction("Settings", "Home");
            }
            else
            {                
                return View(dbChild.GetChild(ChildId1));
            }
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
            if (taskModel.StartDate < DateTime.Now.AddDays(-1))
            {
                ModelState.AddModelError("StartDate", "Укажите текущую или будущую дату.");
            }
            if (ModelState.IsValid)
            {
                var task = new TaskElement()
                {
                    ChildId = taskModel.ChildId,
                    TaskCategory = taskModel.TypeTask,
                    TaskName = taskModel.NameTask,
                    Periodicity = taskModel.Periodicity,
                    StartDate = taskModel.StartDate.Date,
                    Point = taskModel.StartDate.Date
                };
                dbTask.AddTask(task);
                return RedirectToAction("Settings", "Home");
            }
            else ViewData["chlildId"] = taskModel.ChildId; return View(taskModel);
        }

        [HttpGet]
        public IActionResult DeleteTask(int taskId)
        {
            dbTask.SendTaskElementToArchive(taskId);
            return RedirectToAction("Settings", "Home");

        }

        [HttpGet]
        public IActionResult EditTask(int taskId)
        {
            ViewData["taskId"] = taskId;
            return View(dbTask.GetTaskElement(taskId));
        }

        [HttpPost]
        public IActionResult EditTask(int taskId, TaskElement task)
        {
            if (ModelState.IsValid)
            {
                dbTask.EditTask(taskId, task);
                return RedirectToAction("Settings", "Home");
            }
            else
            {
                ViewData["taskId"] = taskId;
                return View(dbTask.GetTaskElement(taskId));
            }
        }
    }
}