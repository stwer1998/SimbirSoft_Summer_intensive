﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_Manager.Interfaces;
using Task_Manager.Models;

namespace Task_Manager.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private MyDbContext db;
        public TaskRepository(MyDbContext db)
        {
            this.db = db;
        }

        public void AddTask(TaskElement taskElement)
        {
            db.TaskElements.Add(taskElement);
            db.Childs.FirstOrDefault(x => x.ChildId == taskElement.ChildId).UpdateDate = DateTime.Now.Date.AddDays(-1);
            db.SaveChanges();
        }

        public void SendTaskElementToArchive(int taskElementId)
        {
            var task = db.TaskElements.FirstOrDefault(x => x.TaskElementId == taskElementId);
            task.EndDate = DateTime.Now.Date.AddDays(-1);
            db.SaveChanges();
        }

        public void EditTask(int taskId,TaskElement taskElement)
        {
            var task = db.TaskElements.FirstOrDefault(x => x.TaskElementId == taskId);
            task.TaskName =taskElement.TaskName;
            task.TaskCategory = taskElement.TaskCategory;
            task.Point = taskElement.Point;
            task.Periodicity = taskElement.Periodicity;
            db.SaveChanges();
        }

        public List<TaskElement> GetChildTaskElements(int childId)
        {
            var result= db.TaskElements.Where(x => x.ChildId == childId && x.EndDate < x.StartDate).ToList();
            if (result == null) { return new List<TaskElement>(); }
            else return result;
        }

        public TaskElement GetTaskElement(int taskElementId)
        {
            return db.TaskElements.FirstOrDefault(x=>x.TaskElementId==taskElementId);
        }
    }
}
