using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_Manager.Interfaces;
using Task_Manager.Models;

namespace Task_Manager.Repository
{
    public class DateRepository : IDateRepository
    {
        private MyDbContext db;
        public DateRepository(MyDbContext _db)
        {
            db = _db;
        }
        public void AddChild(string login, Child child)
        {
            var user = db.Users.Include(x => x.Childs)
                .FirstOrDefault(x => x.Login == login);
            user.Childs.Add(child);
            user.UpdateTime = DateTime.Now.AddDays(-2).Date;
            db.SaveChanges();
        }

        public void AddTask(string login, TaskModel taskModel)
        {
            var user = db.Users.
                Include(p => p.Childs).
                ThenInclude(o => o.Tasks).
                ThenInclude(i => i.TaskElements).
                FirstOrDefault(x => x.Login == login);
            var child = user.Childs.FirstOrDefault(x => x.ChildId == taskModel.ChildId);
            //var flag = user.Childs
            //    .FirstOrDefault(x => x.ChildId == taskModel.ChildId)
            //    .Tasks.Select(q=>q.Name).ToList()
            //    .Contains(taskModel.TypeTask);
            if (child.Tasks.Select(q => q.Name).ToList()
                .Contains(taskModel.TypeTask))
            {
                child.Tasks.FirstOrDefault(x => x.Name == taskModel.TypeTask).TaskElements.Add(new TaskElement
                {
                    TaskName = taskModel.NameTask,
                    Description = taskModel.Description,
                    Periodicity = taskModel.Periodicity,
                    Point=DateTime.Now.Date
                });
                user.UpdateTime = DateTime.Now.AddDays(-2).Date;
                db.SaveChanges();
            }
            else
            {
                child.Tasks.Add(
                    new TaskType()
                    {
                        Name = taskModel.TypeTask,
                        TaskElements = new List<TaskElement>()
                    { new TaskElement{
                    TaskName = taskModel.NameTask,
                    Description = taskModel.Description,
                    Periodicity = taskModel.Periodicity,
                    Point=DateTime.Now.Date
                }
            }
                    });
                user.UpdateTime = DateTime.Now.AddDays(-2).Date;
                db.SaveChanges();
            }

        }

        public List<Child> GetChilds(string login)
        {
            return db.Users.Include(x => x.Childs).FirstOrDefault(x => x.Login == login).Childs;
        }

        public List<Child> GetTodayTasks(string login)
        {
            var a = db.Users.
                Include(p => p.Childs).
                ThenInclude(o => o.TaskForDates).
                ThenInclude(i=>i.TaskElement).
                FirstOrDefault(x => x.Login == login);

            List<Child> result = new List<Child>();
            foreach (var item in a.Childs)
            {
                var ch = item;ch.Tasks = null;
                ch.TaskForDates = ch.TaskForDates.Where(x => x.Date == DateTime.Now.Date).ToList();
                result.Add(ch);
            }
            return result;
        }

        public void UpdateUserDate(string login)
        {
            var user = db.Users.FirstOrDefault(x=>x.Login==login);
            if (user.UpdateTime < DateTime.Now.Date)
            {
                user=db.Users.Include(p => p.Childs).
                ThenInclude(o => o.Tasks).
                ThenInclude(i => i.TaskElements).
                FirstOrDefault(x => x.Login == login);
                var t= db.Users.Include(p => p.Childs).ThenInclude(o => o.TaskForDates).FirstOrDefault(x => x.Login == login);
                foreach (var item in user.Childs)
                {
                    item.TaskForDates = t.Childs.FirstOrDefault(x => x.ChildId == item.ChildId).TaskForDates;
                }

                foreach (var child in user.Childs)
                {
                    foreach (var tasktype in child.Tasks)
                    {
                        foreach (var item in tasktype.TaskElements)
                        {
                            var flag = child.TaskForDates.FirstOrDefault(x=>x.Date==item.Point.AddDays(item.Periodicity)&&x.TaskElement==item);
                            if (flag==null||flag.TaskElement != item)
                            {
                                child.TaskForDates.Add(new TaskForDate {Date= item.Point.AddDays(item.Periodicity), TaskElement=item });
                                item.Point = DateTime.Now.Date;
                            }
                        }
                    }
                }
                user.UpdateTime = DateTime.Now.Date;
                db.SaveChanges();
            }
        }
    }
}
